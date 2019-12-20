using CoreGraphics;
using Foundation;
using Syncfusion.SfChart.iOS;
using System;
using UIKit;

namespace SfChartMultipleTrackball
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        ChartExt chart;
        ChartTrackballBehaviorExt trackballBehavior1, trackballBehavior2;
      
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            TrackballViewModel viewModel = new TrackballViewModel();

            //Initialize the Chart with required frame. This frame can be any rectangle, which bounds inside the view.
            chart = new ChartExt();
            chart.Frame = this.View.Frame;
            chart.Title.Text = "Average sales for person";
            chart.ColorModel.Palette = SFChartColorPalette.Natural;

            SFDateTimeAxis primaryAxis = new SFDateTimeAxis();
            primaryAxis.Title.Text = new NSString("Year");
            primaryAxis.PlotOffset = 5;
            primaryAxis.AxisLineOffset = 5;
            primaryAxis.ShowMajorGridLines = false;
            primaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
            primaryAxis.Interval = new NSNumber(1);
            primaryAxis.IntervalType = SFChartDateTimeIntervalType.Years;
            primaryAxis.AxisLineStyle.LineWidth = 1;
            primaryAxis.AxisLineStyle.LineColor = UIColor.FromRGB(64, 64, 65);
            primaryAxis.LabelStyle.LabelFormatter = new NSDateFormatter() { DateFormat = "yyyy" };
            chart.PrimaryAxis = primaryAxis;

            SFNumericalAxis secondaryAxis = new SFNumericalAxis();
            secondaryAxis.Title.Text = new NSString("Revenue");
            secondaryAxis.Minimum = new NSNumber(10);
            secondaryAxis.Maximum = new NSNumber(80);
            secondaryAxis.Interval = new NSNumber(10);
            secondaryAxis.MajorTickStyle.LineWidth = 0;
            secondaryAxis.AxisLineStyle.LineWidth = 0;
            chart.SecondaryAxis = secondaryAxis;

            SFLineSeries series = new SFLineSeries();
            series.ItemsSource = viewModel.LineSeries1;
            series.XBindingPath = "Date";
            series.YBindingPath = "Value";
            series.LegendIcon = SFChartLegendIcon.Circle;
            series.DataMarker.ShowMarker = true;
            series.DataMarker.MarkerColor = UIColor.White;
            series.DataMarker.ShowLabel = false;
            series.DataMarker.MarkerBorderWidth = 2;
            series.DataMarker.MarkerBorderColor = UIColor.FromRGB(0, 189, 174);
            series.DataMarker.MarkerHeight = 6;
            series.DataMarker.MarkerWidth = 6;

            SFLineSeries series1 = new SFLineSeries();
            series1.ItemsSource = viewModel.LineSeries2;
            series1.XBindingPath = "Date";
            series1.YBindingPath = "Value";
            series1.LegendIcon = SFChartLegendIcon.Circle;
            series1.DataMarker.ShowMarker = true;
            series1.DataMarker.MarkerColor = UIColor.White;
            series1.DataMarker.ShowLabel = false;
            series1.DataMarker.MarkerBorderWidth = 2;
            series1.DataMarker.MarkerBorderColor = UIColor.FromRGB(64, 64, 65);
            series1.DataMarker.MarkerHeight = 6;
            series1.DataMarker.MarkerWidth = 6;

            chart.Series.Add(series);
            chart.Series.Add(series1);

            trackballBehavior1 = new ChartTrackballBehaviorExt();
            trackballBehavior1.LineStyle.LineWidth = 3;
            trackballBehavior1.ActivationMode = SFChartTrackballActivationMode.None;
            chart.Behaviors.Add(trackballBehavior1);

            trackballBehavior2 = new ChartTrackballBehaviorExt();
            trackballBehavior2.LineStyle.LineWidth = 3;
            trackballBehavior2.ActivationMode = SFChartTrackballActivationMode.None;
            chart.Behaviors.Add(trackballBehavior2);

            this.View.AddSubview(chart);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            trackballBehavior1.Show(new CGPoint(chart.PointForValue(new DateTime(2000, 9, 14).ToOADate(), chart.PrimaryAxis), chart.PointForValue(55, chart.SecondaryAxis)));
            trackballBehavior2.Show(new CGPoint(chart.PointForValue(new DateTime(2005, 2, 11).ToOADate(), chart.PrimaryAxis), chart.PointForValue(60, chart.SecondaryAxis)));
        }
    }
}