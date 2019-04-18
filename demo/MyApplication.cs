using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Tencent.Smtt.Sdk;
using static Com.Tencent.Smtt.Sdk.QbSdk;

namespace X5WebDemo
{
    [Application]
    public class MyApplication : Application
    {

        /// <summary>
        /// Base constructor which must be implemented if it is to successfully inherit from the Application
        /// class.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="transfer"></param>
        public MyApplication(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
            // do any initialisation you want here (for example initialising properties)
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Java.Util.Logging.Logger.Global.Warning("app is inited");
            Com.Tencent.Smtt.Sdk.QbSdk.InitX5Environment(this.ApplicationContext, new InitCallback());
        }
    }

    public class InitCallback : Java.Lang.Object, IPreInitCallback
    {
        public void OnCoreInitFinished()
        {
            Java.Util.Logging.Logger.Global.Warning("init webview core");
        }

        public void OnViewInitFinished(bool p0)
        {
            Java.Util.Logging.Logger.Global.Warning("init webview view");
            Log.Warn("app", " onViewInitFinished is " + p0);
        }
    }
}