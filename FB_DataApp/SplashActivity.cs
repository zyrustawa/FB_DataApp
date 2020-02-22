using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using FB_DataApp.Activities;

namespace FB_DataApp
{
    [Activity(Label = "FB ScaleUp", Icon = "@drawable/splashscreen", Theme = "@style/AppTheme", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
           
            
            StartActivity(typeof(Login));
        }
    }
}