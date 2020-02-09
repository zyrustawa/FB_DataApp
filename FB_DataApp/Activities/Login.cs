using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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
            SetContentView(Resource.Layout.activity_login);
            Button signinBtn = FindViewById<Button>(Resource.Id.btnsignin);
            signinBtn.Click += SignInBtnClicked;
        }
        void SignInBtnClicked(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.WelcomePage);
        }
    }
}