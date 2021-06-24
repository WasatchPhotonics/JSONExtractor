using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace JSONExtractor
{
    public partial class Form1 : Form
    {
        IDictionary<string, object> treeRoot;
        Logger logger = Logger.getInstance();

        public Form1()
        {
            InitializeComponent();
            logger.setTextBox(textBoxEventLog);
            logger.level = Logger.LogLevel.DEBUG;
        }

        private void buttonLoadSample_Click(object sender, EventArgs e)
        {
            treeRoot = null;
            treeViewJSON.Nodes.Clear();
            toolTip1.SetToolTip(buttonLoadSample, null);

            var result = openFileDialogSample.ShowDialog();
            if (result != DialogResult.OK)
                return;

            var samplePathname = openFileDialogSample.FileName;
            try
            {
                logger.info($"loading {samplePathname}");
                var jsonText = File.ReadAllText(samplePathname);
                treeRoot = JsonConvert.DeserializeObject<IDictionary<string, object>>(jsonText, new DictionaryConverter());
                toolTip1.SetToolTip(buttonLoadSample, samplePathname);
            }
            catch(Exception ex)
            {
                logger.error($"failed to load and parse {samplePathname}: {ex}");
                return;
            }

            treeViewJSON.Nodes.Add("Document");

            treeViewJSON.BeginUpdate();
            populateTreeView(treeRoot, treeViewJSON.Nodes[0]);
            treeViewJSON.EndUpdate();
        }

        // traverse down the loaded JSON object tree starting at jsonNode, populating
        // the contents into the TreeView branch at treeNode
        void populateTreeView(IDictionary<string, object> jsonNode, TreeNode treeNode)
        {
            foreach (string key in jsonNode.Keys)
            {
                object value = jsonNode[key];

                string type = value.GetType().ToString();
                if (value is IDictionary<string, object> dict)
                {
                    logger.debug($"recursing into {key}");
                    var node = treeNode.Nodes.Add(key);
                    populateTreeView(dict, node);
                }
                else if (value is List<object>)
                {
                    treeNode.Nodes.Add(key + "[]").Tag = value;
                }
                else
                {
                    logger.debug($"added scalar of type {type}");
                    treeNode.Nodes.Add(key).Tag = value;
                }
            }
        }
    }
}
