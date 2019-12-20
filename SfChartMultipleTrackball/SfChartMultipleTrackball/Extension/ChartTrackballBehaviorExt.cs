using System;
using CoreGraphics;
using Foundation;
using Syncfusion.SfChart.iOS;
using UIKit;

namespace SfChartMultipleTrackball
{
    public class ChartTrackballBehaviorExt : SFChartTrackballBehavior
    {
        bool isActivated = false;

        public override void TouchesBegan(NSSet touches, UIEvent uiEvent)
        {
            var chart = (Chart as ChartExt);
            if (!chart.IsTrackballSelected && touches?.AnyObject is UITouch touch)
            {
                CGPoint location = touch.LocationInView(Chart);
                if (HitTest((float)location.X, (float)location.Y))
                {
                    isActivated = true;
                    base.TouchesBegan(touches, uiEvent);
                    chart.IsTrackballSelected = true;
                }
            }
        }

        public override void TouchesMoved(NSSet touches, UIEvent uiEvent)
        {
            if (isActivated)
            {
                if (touches?.AnyObject is UITouch touch)
                {
                    CGPoint location = touch.LocationInView(Chart);
                    Show(location);
                    base.TouchesMoved(touches, uiEvent);
                }
            }
        }

        public override void TouchesEnded(NSSet touches, UIEvent uiEvent)
        {
            isActivated = false;
            (Chart as ChartExt).IsTrackballSelected = false;
        }
    }
}