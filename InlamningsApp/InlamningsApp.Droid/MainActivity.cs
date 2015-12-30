using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin;

namespace InlamningsApp.Droid
{
    [Activity(Label = "InlamningsApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Insights.HasPendingCrashReport += (sender, isStartupCrash) =>
            {
                if (isStartupCrash)
                {
                    Insights.PurgePendingCrashReports().Wait();
                }
            };
            Insights.Initialize("326d0dddbabfe133f26293d8c82f4f25113ddc7f", ApplicationContext);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            AdvancedTimer.Forms.Plugin.Droid.AdvancedTimerImplementation.Init();
            

            LoadApplication(new App());
        }
    }
}

