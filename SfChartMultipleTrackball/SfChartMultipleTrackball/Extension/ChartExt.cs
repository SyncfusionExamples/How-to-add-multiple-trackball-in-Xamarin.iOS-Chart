using System;
using Syncfusion.SfChart.iOS;

namespace SfChartMultipleTrackball
{
    public class ChartExt : SFChart
    {
        // Used to activate the first trackball, if multiple trackballs are placed in the same position.
        internal bool IsTrackballSelected { get; set; } = false;

        public ChartExt()
        {

        }
    }
}
