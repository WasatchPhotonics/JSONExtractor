﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace JSONExtractor
{
    public class Logger
    {
        public enum LogLevel { DEBUG, INFO, ERROR, NEVER };

        ////////////////////////////////////////////////////////////////////////
        // Private attributes
        ////////////////////////////////////////////////////////////////////////

        static readonly Logger instance = new Logger();

        const int MAX_ERRORS = 100; // how many to queue for retrieval by getErrors()
        LinkedList<string> errors = new LinkedList<string>();
        int errorCount;

        TextBox textBox = null;
        StreamWriter outfile;
        public bool initializationComplete;

        ////////////////////////////////////////////////////////////////////////
        // Public attributes
        ////////////////////////////////////////////////////////////////////////

        public LogLevel level 
        {
            get => _level;
            set
            {
                if (null != Environment.GetEnvironmentVariable("WASATCHNET_LOGGER_FORCE"))
                    return;

                _level = value;
            }
        } 
        LogLevel _level = LogLevel.INFO;

        static public Logger getInstance()
        {
            return instance;
        }

        public void setTextBox(TextBox tb)
        {
            textBox = tb;
        }

        public void setPathname(string path)
        {
            if (null != Environment.GetEnvironmentVariable("WASATCHNET_LOGGER_FORCE"))
            {
                debug($"Logger.setPathname({path}): ignoring due to WASATCHNET_LOGGER_FORCE");
                return;
            }

            try
            {
                outfile = new StreamWriter(path);
                info($"log path set to {path}");
            }
            catch (Exception e)
            {
                outfile = null;
                error("Can't set log pathname: {0}", e);
            }
        }

        public void close()
        {
            lock (instance)
            {
                textBox = null;
                if (outfile != null)
                {
                    outfile.Flush();
                    outfile.Close();
                    outfile = null;
                }
            }
        }

        public bool debugEnabled()
        {
            return level <= LogLevel.DEBUG;
        }

        public string getLastError()
        {
            lock (instance)
            {
                if (errorCount > 0)
                {
                    errorCount--;
                    string msg = errors.Last.ToString();
                    errors.RemoveLast();
                    return msg;
                }
                else
                    return null;
            }
        }

        public List<string> getErrors()
        {
            lock (instance)
            {
                if (errorCount > 0)
                {
                    List<string> retval = new List<string>(errors);
                    errors.Clear();
                    errorCount = 0;
                    return retval;
                }
                return null;
            }
        }

        public bool hasError()
        {
            lock (instance)
                return errorCount > 0;
        }

        public bool error(string fmt, params Object[] obj)
        {
            lock (instance)
            {
                // you'd think there'd be a standard collection that does this (size-limited queue/buffer)
                if (obj.Length > 0)
                    errors.AddLast(String.Format(fmt, obj));
                else
                    errors.AddLast(fmt);
                errorCount++;
                while (errorCount > MAX_ERRORS)
                {
                    errors.RemoveFirst();
                    errorCount--;
                }
            }

            if (level <= LogLevel.ERROR)
                log(LogLevel.ERROR, fmt, obj);

            return false; // convenient for many cases
        }

        public void info(string fmt, params Object[] obj)
        {
            if (level <= LogLevel.INFO)
                log(LogLevel.INFO, fmt, obj);
        }

        public void debug(string fmt, params Object[] obj)
        {
            if (level <= LogLevel.DEBUG)
                log(LogLevel.DEBUG, fmt, obj);
        }

        public void header(string fmt, params Object[] obj)
        {
            if (level <= LogLevel.DEBUG)
            {
                debug("");
                debug("=========================================================");
                debug(fmt, obj);
                debug("=========================================================");
                debug("");
            }
        }

        public void logString(LogLevel lvl, string msg)
        {
            if (level <= lvl)
                log(lvl, msg);
        }

        public void save(string pathname)
        {
            if (textBox == null)
            {
                error("can't save a log without a TextBox");
                return;
            }

            try
            {
                TextWriter tw = new StreamWriter(pathname);
                tw.WriteLine(textBox.Text);
                tw.Close();
            }
            catch (Exception e)
            {
                error("can't write {0}: {1}", pathname, e.Message);
            }
        }

        public void hexdump(byte[] buf, string prefix = "")
        {
            string line = "";
            for (int i = 0;  i < buf.Length; i++)
            {
                if (i % 16 == 0)
                {
                    if (i > 0)
                    {
                        debug("{0}{1}", prefix, line);
                        line = "";
                    }
                    line += String.Format("{0:x4}:", i);
                }
                line += String.Format(" {0:x2}", buf[i]);
            }
            if (line.Length > 0)
                debug("{0}{1}", prefix, line);
        }

        ////////////////////////////////////////////////////////////////////////
        // Private methods
        ////////////////////////////////////////////////////////////////////////

        private Logger()
        {
            var envLevel = Environment.GetEnvironmentVariable("WASATCHNET_LOGGER_LEVEL");
            if (envLevel != null)
            {
                envLevel = envLevel.ToUpper();
                     if (envLevel.Contains("DEBUG")) _level = LogLevel.DEBUG;
                else if (envLevel.Contains("INFO" )) _level = LogLevel.INFO;
                else if (envLevel.Contains("ERR"  )) _level = LogLevel.ERROR;
                else if (envLevel.Contains("NEVER")) _level = LogLevel.NEVER;
            }

            var envPathname = Environment.GetEnvironmentVariable("WASATCHNET_LOGGER_PATHNAME");
            if (envPathname != null)
            { 
                // object isn't sufficiently constructed enough to use setPathname()?
                try
                {
                    outfile = new StreamWriter(envPathname);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Can't set log pathname: {e}");
                }
            }
        }

        string getTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture);
        }

        void log(LogLevel lvl, string fmt, params Object[] obj)
        {
            string threadName = null;
            if (Thread.CurrentThread.Name != null)
                threadName = $"[{Thread.CurrentThread.Name}] ";
            else if (Task.CurrentId != null)
                threadName = $"[Task 0x{Task.CurrentId:x4}] ";

            string txt = obj.Length > 0 ? string.Format(fmt, obj) : fmt;
            string msg = $"{getTimestamp()}: {threadName}{lvl}: {txt}";

            lock (instance)
            {
                // Console.WriteLine(msg); .NET 4.x
                System.Diagnostics.Debug.WriteLine(msg);

                if (outfile != null && outfile.BaseStream != null)
                {
                    outfile.WriteLine(msg);
                    outfile.Flush();
                }

                if (textBox != null && initializationComplete)
                    textBox.BeginInvoke(new MethodInvoker(delegate { if (textBox != null) textBox.AppendText(msg + Environment.NewLine); }));
            }
        }
    }
}
