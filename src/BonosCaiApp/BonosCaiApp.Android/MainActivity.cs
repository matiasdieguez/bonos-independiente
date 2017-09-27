
using Android.App;
using Android.Content.PM;
using Android.OS;
using BonosCaiApp.Droid.Services;
using Android.Content;
using System.Linq;
using Android.Util;

namespace BonosCaiApp.Droid
{
    [Activity(Label = "CAI App", Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            StartService();
            LoadApplication(new App());
        }

        private void StartService()
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
        }
    }
}

