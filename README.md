# How to add multiple trackball in Xamarin.iOS Chart (SfChart)?

This example demonstrates how to add the multiple trackball to a single chart and drag them independently to view the information of different data points at the same time in Xamarin.iOS chart.

SFChart allows you add multiple trackballs to a single chart and drag them independently to view the information of different data points at the same time.

The following steps describe how to add multiple trackballs to SFChart.

**Step 1:** Create a custom ChartTrackballBehaviorExt class, which is inherited from **SFChartTrackballBehavior**.
```
public class ChartTrackballBehaviorExt : SFChartTrackballBehavior
{
}
```

**Step 2:** Create an instance of ChartTrackballBehaviorExt and add it to the **Behaviors** collection.
```
ChartTrackballBehaviorExt trackballBehavior1 = new ChartTrackballBehaviorExt();
ChartTrackballBehaviorExt trackballBehavior2 = new ChartTrackballBehaviorExt();
chart.Behaviors.Add(trackballBehavior1);
chart.Behaviors.Add(trackballBehavior2);
```

**Step 3:** Activate the multiple trackballs at load time using the **[Show](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFChartTrackballBehavior.html#Syncfusion_SfChart_iOS_SFChartTrackballBehavior_Show_CoreGraphics_CGPoint_)** method.
```
public override void ViewDidAppear(bool animated)
{
    base.ViewDidAppear(animated);
 
    trackballBehavior1.Show(pointX, pointY);
    trackballBehavior2.Show(pointX, pointY);
}
```

**Step 4:** Set [ActivationMode](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFChartTrackballBehavior.html#Syncfusion_SfChart_iOS_SFChartTrackballBehavior_ActivationMode) to [None](https://help.syncfusion.com/cr/Syncfusion.SfChart.iOS.SFChartTrackballActivationMode.html) to restrict the default movement of the trackball behavior.
```
trackballBehavior1.ActivationMode = SFChartTrackballActivationMode.None;
trackballBehavior2.ActivationMode = SFChartTrackballActivationMode.None;
```

**Step 5:** Interact with multiple trackballs by overriding the touch methods of SFChartTrackballBehavior class and the [HitTest](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFChartTrackballBehavior.html#Syncfusion_SfChart_iOS_SFChartTrackballBehavior_HitTest_System_Single_System_Single_) method. The HitTest method is used to find the trackball that is currently activated by user.
```
public class ChartTrackballBehaviorExt : SFChartTrackballBehavior
{
    bool isActivated = false;
 
    public override void TouchesBegan(NSSet touches, UIEvent uiEvent)
    {
        if (touches?.AnyObject is UITouch touch)
        {
            CGPoint location = touch.LocationInView(Chart);
            if (HitTest((float)location.X, (float)location.Y))
            {
                isActivated = true;
                base.TouchesBegan(touches, uiEvent);
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
    }
}
```

**Step 6:** Tap and drag each trackball separately to view the data points at different positions simultaneously.

## Output:

![Multiple trackball in Xamarin.iOS Chart](https://user-images.githubusercontent.com/53489303/200624559-4d790a1d-35fb-4aa6-b977-028186b2b56c.gif)

KB article - [How to add multiple trackball in Xamarin.iOS Chart?](https://www.syncfusion.com/kb/10839/how-to-add-multiple-trackball-in-xamarin-ios-chart)

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
