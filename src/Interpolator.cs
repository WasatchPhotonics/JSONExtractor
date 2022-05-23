using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONExtractor
{
    /// <summary>
    /// Linear interpolation of a set of y-values from one x-axis to another.
    /// </summary>
    /// <remarks>
    /// It seems weird that I should have to create this from scratch.  I tried 
    /// using MathNET.Numerics.Interpolation, but for the life of me none of them
    /// seemed to work for my data.  StepInterpolation was closest, but it 
    /// introduced large "stair-steps" into the output data.  Others kept 
    /// generating NaN or double.Max, or required pre-computed inputs that I 
    /// don't have.
    /// </remarks>
    /// <see href="https://numerics.mathdotnet.com/api/MathNet.Numerics.Interpolation"/>
    class Interpolator
    {
        SortedDictionary<double, double> data;
        readonly List<double> oldX;
        readonly double firstX;
        readonly double lastX;

        int pixels = 0;
        int pos = 0; // where the interpolation state currently sits in xaxis (lower bound)

        Logger logger = Logger.getInstance();

        /// <summary>
        /// Construct a new Interpolator.
        /// </summary>
        /// <param name="oldX">the original x-axis (e.g. wavelengths or wavenumbers)</param>
        /// <param name="oldY">the original y-axis (e.g. spectrum intensity)</param>
        /// <remarks>
        /// assumes x is sorted, and y is in the same order
        /// </remarks>
        public Interpolator(List<double> oldX, List<double> oldY)
        {
            if (oldX == null) throw new Exception("oldX null");
            if (oldY == null) throw new Exception("oldY null");
            if (oldX.Count < 1) throw new Exception("oldX empty");
            if (oldY.Count < 1) throw new Exception("oldY empty");
            if (oldX.Count != oldY.Count) throw new Exception($"oldX.dim {oldY.Count} != oldY.dim {oldY.Count}");

            this.oldX = oldX;
            pixels = oldX.Count;

            if (pixels < 1)
                throw new Exception("no pixels");

            firstX = oldX.First();
            lastX = oldX.Last();

            // trade space for time and store as a lookup for speed
            data = new SortedDictionary<double, double>();
            for (int i = 0; i < pixels; i++)
                data.Add(oldX[i], oldY[i]);
        }

        /// <summary>
        /// Interpolate the dataset to the provided new x-axis.
        /// </summary>
        /// <param name="newX">the new x-axis to which we should interpolate the stored y values</param>
        /// <returns></returns>
        public List<double> interpolate(List<double> newX)
        {
            List<double> newY = new();
            foreach (var x in newX)
                newY.Add(interpolate(x));
            return newY;
        }

        /// <summary>
        /// Interpolate a single value to the specified x coordinate.
        /// </summary>
        /// <remarks>
        /// For efficiency call this method with sequentially increasing x
        /// values. It should still work if used as "random access" into the
        /// data, just more slowly
        /// </remarks>
        public double interpolate(double newX)
        {
            // handle corner-cases fast (leave 'pos' where it is) - no misleadingly cute extrapolation, 
            // just treat first and last values as infinite series
            if (newX <= firstX)         return data[firstX]; 
            if (newX >= lastX)          return data[lastX]; 
            if (data.ContainsKey(newX)) return data[newX];

            // this shouldn't happen if caller follows the "sequential" guidance (i.e.
            // each subsequent method call is invoked with an increasing x value)
            if (oldX[pos] > newX)
                pos = 0;

            // pos should now be an index SOMEWHERE BELOW the requested x;
            // advance until it is the index DIRECTLY BELOW the requested x 
            while (pos < pixels - 2)
            {
                if (oldX[pos + 1] > newX)
                    break;
                pos++;
            }

            // pos should now be DIRECTLY BELOW requested x (don't worry
            // about running off the end...handled by initial corner-case)

            // lookup bracketing xaxis
            double x0 = oldX[pos];
            double x1 = oldX[pos + 1];
        
            // lookup associated bracketing y values
            double y0 = data[x0];
            double y1 = data[x1];
        
            // perform linear interpolation between those two points (newY)
            return (((newX - x0) / (x1 - x0)) * (y1 - y0)) + y0;
        }

        public class Axis
        {
            public List<double> newX;
            public Axis(List<double> newX) { this.newX = newX; }
            public Axis(int start, int end, double incr)
            {
                newX = new();
                for (double x = start, steps = 0; x < end; steps++)
                    newX.Add(x = start + steps * incr);
            }
        }
    }
}