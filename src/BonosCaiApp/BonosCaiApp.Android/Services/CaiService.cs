using System;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;

namespace BonosCaiApp.Droid.Services
{
    /// <summary>
    /// CaiService
    /// </summary>
    [Service]
    public class CaiService : Service
    {
        /// <summary>
        /// Tag
        /// </summary>
        private static readonly string Tag = "X:CaiService";

        /// <summary>
        /// _timer
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// OnStartCommand
        /// </summary>
        /// <param name="intent">intent</param>
        /// <param name="flags">flags</param>
        /// <param name="startId">startId</param>
        /// <returns>StartCommandResult</returns>
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            try
            {
                Log.Debug(Tag, "CaiService.OnStartCommand called at {2}, flags={0}, startid={1}", flags, startId, DateTime.UtcNow);
                _timer = new Timer(MainTimerCallback, null, TimeSpan.FromMilliseconds(0), TimeSpan.FromMinutes(1));
            }
            catch (Exception ex)
            {
                Log.Debug(Tag, ex.Message);
            }

            return StartCommandResult.Sticky;
        }

        /// <summary>
        /// MainTimerCallback
        /// </summary>
        /// <param name="state">state</param>
        private void MainTimerCallback(object state)
        {
            try
            {

            }
            catch
            {
                Log.Debug(Tag, "No se pudo controlar la venta de bonos.", DateTime.UtcNow);
            }

        }

        /// <summary>
        /// OnDestroy
        /// </summary>
        public override void OnDestroy()
        {
            base.OnDestroy();

            try
            {
                _timer.Dispose();
                _timer = null;
            }
            catch 
            {
                Log.Debug(Tag, "Can't destroy CaiService at {0}.", DateTime.UtcNow);
            }

            Log.Debug(Tag, "CaiService destroyed at {0}.", DateTime.UtcNow);
        }

        /// <summary>
        /// OnBind
        /// </summary>
        /// <param name="intent">intent</param>
        /// <returns>IBinder</returns>
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }
}