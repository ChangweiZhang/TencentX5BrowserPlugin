using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;

namespace X5WebDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private X5WebView mWebView;
        const string HOME_URL = "https://bing.com";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            mWebView = FindViewById<X5WebView>(Resource.Id.full_web_webview);
            var btn = FindViewById<Button>(Resource.Id.test_btn);
            var backBtn = FindViewById<Button>(Resource.Id.test_btn_back);
            var forwardBtn = FindViewById<Button>(Resource.Id.test_btn_forward);
            backBtn.Click += BackBtn_Click;
            btn.Click += Btn_Click;
            forwardBtn.Click += ForwardBtn_Click;

            mWebView.LoadUrl(HOME_URL);
        }
        

        private void ForwardBtn_Click(object sender, System.EventArgs e)
        {
            if (mWebView.CanGoForward())
            {
                mWebView.GoForward();
            }
        }

        private void BackBtn_Click(object sender, System.EventArgs e)
        {
            if (mWebView.CanGoBack())
            {
                mWebView.GoBack();
            }
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            mWebView.LoadUrl(HOME_URL);
            mWebView.RequestFocus();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}