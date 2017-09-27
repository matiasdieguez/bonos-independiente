using Android.App;
using Android.Content;

namespace BonosCaiApp.Droid.Services
{
    [BroadcastReceiver]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    internal class BootCompletedBroadcastMessageReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if ((intent.Action != null) && intent.Action == Intent.ActionBootCompleted)
                context.ApplicationContext.StartService(new Intent(context, typeof(CaiService)));
        }
    }
}