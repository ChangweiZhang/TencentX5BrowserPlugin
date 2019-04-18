using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Annotation;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Tencent.Smtt.Export.External.Interfaces;
using Com.Tencent.Smtt.Sdk;
using Java.Lang;
using static Com.Tencent.Smtt.Sdk.WebSettings;

namespace X5WebDemo
{
    public class X5WebViewClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView p0, string p1)
        {
            var res = false;
            if (URLUtil.IsHttpsUrl(p1) || URLUtil.IsHttpUrl(p1))
            {
                res = true;
            }
            p0.LoadUrl(p1);
            return res;
        }
    }
    public class X5WebView : WebView
    {
        private X5WebViewClient client = new X5WebViewClient { };
        [SuppressLint(Value = new string[] { "SetJavaScriptEnabled" })]
        public X5WebView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }
        [SuppressLint(Value = new string[] { "SetJavaScriptEnabled" })]
        public X5WebView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.WebViewClient = client;
            InitWebViewSettings();
        }

        protected override bool DrawChild(Canvas canvas, View child, long drawingTime)
        {
            bool ret = base.DrawChild(canvas, child, drawingTime);
            canvas.Save();
            Paint paint = new Paint();
            paint.Color = Color.Red;
            paint.TextSize = (24.0f);
            paint.AntiAlias = (true);
            if (X5WebViewExtension != null)
            {
                canvas.DrawText(this.Context.PackageName + "-pid:"
                        + Android.OS.Process.MyPid(), 10, 50, paint);
                canvas.DrawText(
                        "X5  Core:" + QbSdk.GetTbsVersion(this.Context), 10,
                        100, paint);
            }
            else
            {
                canvas.DrawText(this.Context.PackageName + "-pid:"
                        + Android.OS.Process.MyPid(), 10, 50, paint);
                canvas.DrawText("Sys Core", 10, 100, paint);
            }
            canvas.DrawText(Build.Manufacturer, 10, 150, paint);
            canvas.DrawText(Build.Model, 10, 200, paint);
            canvas.Restore();
            return ret;
        }
        void InitWebViewSettings()
        {
            WebSettings webSetting = this.Settings;
            webSetting.JavaScriptEnabled = (true);
            webSetting.JavaScriptCanOpenWindowsAutomatically = (true);
            webSetting.AllowFileAccess = (true);
            webSetting.SetLayoutAlgorithm(LayoutAlgorithm.NarrowColumns);
            webSetting.SetSupportZoom(true);
            webSetting.BuiltInZoomControls = (true);
            webSetting.UseWideViewPort = (true);
            webSetting.SetSupportMultipleWindows(true);
            // webSetting.LoadWithOverviewMode(true);
            webSetting.SetAppCacheEnabled(true);
            // webSetting.DatabaseEnabled(true);
            webSetting.DomStorageEnabled = (true);
            webSetting.SetGeolocationEnabled(true);
            webSetting.SetAppCacheMaxSize(Long.MaxValue);
            // webSetting.PageCacheCapacity(IX5WebSettings.DEFAULT_CACHE_CAPACITY);
            webSetting.SetPluginState(WebSettings.PluginState.OnDemand);
            // webSetting.RenderPriority(WebSettings.RenderPriority.HIGH);
            webSetting.CacheMode = (WebSettings.LoadNoCache);

            // this.getSettingsExtension().PageCacheCapacity(IX5WebSettings.DEFAULT_CACHE_CAPACITY);//extension
            // settings 的设计
        }
    }
}