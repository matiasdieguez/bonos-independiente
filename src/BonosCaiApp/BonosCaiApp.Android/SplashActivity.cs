using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using BonosCaiApp.Droid.Services;
using Android.Util;

namespace BonosCaiApp.Droid
{
    [Activity(Theme = "@style/MainTheme.Splash", 
        MainLauncher = true, 
        NoHistory = true, 
        Label = "CAI App", 
        Icon = "@drawable/icon",
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class SplashActivity : Activity
    {
        private IEnumerable<string> GetRunningServices()
        {
            var manager = (ActivityManager)GetSystemService(ActivityService);
            return manager.GetRunningServices(int.MaxValue).Select(service => service.Service.ClassName).ToList();
        }

        protected override void OnResume()
        {
            base.OnResume();

            var startupWork = new Task(() =>
            {
                try
                {
                    var manager = (ActivityManager)GetSystemService(ActivityService);
                    var runningServices = manager.GetRunningServices(int.MaxValue).Select(service => service.Service.ClassName).ToList();
                    if (!runningServices.Any(s => s.ToLower().Equals(typeof(CaiService).ToString().ToLower())))
                        StartService(new Intent(this, typeof(CaiService)));
                }
                catch
                {
                    Log.Debug("x:CaiService", "Can't start CaiService");
                }
            });

            startupWork.ContinueWith(t => { StartActivity(new Intent(Application.Context, typeof(MainActivity))); }, 
                                     TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }

    }
}