using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONExtractor
{
    class Interpolator
    {
        SortedDictionary<double, double> data;
        readonly List<double> x;
        readonly double firstX;
        readonly double lastX;

        int pixels = 0;
        int pos = 0; // where the interpolation state currently sits in xaxis (lower bound)

        Logger logger = Logger.getInstance();
        static int count = 0;

        // assumes x are sorted, and y in same order
        public Interpolator(List<double> x, List<double> y)
        {
            if (x == null) throw new Exception("x null");
            if (y == null) throw new Exception("y null");
            if (x.Count < 1) throw new Exception("x empty");
            if (y.Count < 1) throw new Exception("y empty");
            if (x.Count != y.Count) throw new Exception($"x.dim != y.dim ({x.Count} != {y.Count})");

            this.x = x;
            pixels = x.Count;

            if (pixels < 1)
                throw new Exception("no pixels");

            firstX = x.First();
            lastX = x.Last();

            data = new SortedDictionary<double, double>();
            for (int i = 0; i < pixels; i++)
                data.Add(x[i], y[i]);
        }

        // NOTE: this method will execute much more efficiently if called with 
        // sequentially increasing x values (though it should still work
        // if used as "random access" into the data, just more slowly)
        public double interpolate(double newX)
        {
            // handle corner-cases fast (leave 'pos' where it is) - no misleadingly cute extrapolation, 
            // just treat first and last values as infinite series
            if (newX <= firstX)         return data[firstX]; 
            if (newX >= lastX)          return data[lastX]; 
            if (data.ContainsKey(newX)) return data[newX];

            // this shouldn't happen if caller follows the "sequential" guidance (i.e.
            // each subsequent method call is invoked with an increasing x value)
            if (x[pos] > newX)
                pos = 0;

            // pos should now be an index SOMEWHERE BELOW the requested x;
            // advance until it is the index DIRECTLY BELOW the requested x 
            while (pos < pixels - 2)
            {
                if (x[pos + 1] > newX)
                    break;
                pos++;
            }

            // pos should now be DIRECTLY BELOW requested x (don't worry
            // about running off the end...handled by initial corner-case)

            // lookup bracketing xaxis
            double x0 = x[pos];
            double x1 = x[pos + 1];
        
            // lookup associated bracketing y values
            double y0 = data[x0];
            double y1 = data[x1];
        
            // perform linear interpolation between those two points
            double newY = (((newX - x0) / (x1 - x0)) * (y1 - y0)) + y0;

            if (count % 100 == 0)
                logger.debug($"interpolator: interpolated old x0 {x0:f2}, x1 {x1:f2} and y0 {y0:f2}, y1 {y1:f2} to new x {newX:f2}, y {newY:f2}");
            count++;

            return newY;
        }
    }
}