using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;

namespace FB_DataApp.Activities
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);
            TextView textView = FindViewById<TextView>(Resource.Id.account1);
            textView.Click += TextView_Click; 
        }

        private void TextView_Click(object sender, EventArgs e)
        {
            Intent abc = new Intent(this, typeof(Account));
            StartActivity(abc);
        }
    }
}