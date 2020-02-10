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
    [Activity(Label = "WelcomePage")]
    public class WelcomePage : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.WelcomePage);
            Button mainmenu = FindViewById<Button>(Resource.Id.btnmainmenu);
            mainmenu.Click += GoToMainMenuBtnClicked;
        }
        void GoToMainMenuBtnClicked(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }

}