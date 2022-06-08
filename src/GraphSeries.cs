using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace JSONExtractor
{
    public class GraphSeries
    {
        public Series series;
        public CheckBox checkBox;
        public bool intendedCheckState;

        public override string ToString()
        {
            var cnt = series.Points.Count;
            if (cnt == 0)
                return $"GraphSeries< name {series.Name}, {series.Points.Count} points >";
            else
                return $"GraphSeries< name {series.Name}, {series.Points.Count} points ({series.Points[0].XValue:f2}, {series.Points[cnt-1].XValue:f2}) >";
        }
    }
}
