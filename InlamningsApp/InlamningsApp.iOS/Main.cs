using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin;

namespace InlamningsApp.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            Insights.HasPendingCrashReport += (sender, isStartupCrash) =>
            {
                if (isStartupCrash)
                {
                    Insights.PurgePendingCrashReports().Wait();
                }
            };
            Insights.Initialize("326d0dddbabfe133f26293d8c82f4f25113ddc7f");
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
            AdvancedTimer.Forms.Plugin.iOS.AdvancedTimerImplementation.Init();
            
        }
    }
}
