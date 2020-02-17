using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace FB_DataApp.Activities
{
    [Activity(Label = "Admin_settings")]
    public class Admin_settings : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Admin_settings);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Data-Collect: Admin Settings";

            EditText url = FindViewById<EditText>(Resource.Id.url);
            url.Text = Helpers.Settings.URL;
            EditText username = FindViewById<EditText>(Resource.Id.username);
            username.Text = Helpers.Settings.UrlUsername;
            EditText password = FindViewById<EditText>(Resource.Id.password);
            password.Text = Helpers.Settings.UrlPassword;

            Button button = FindViewById<Button>(Resource.Id.button2);
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            EditText url = FindViewById<EditText>(Resource.Id.url);
            EditText username = FindViewById<EditText>(Resource.Id.username);
            EditText password = FindViewById<EditText>(Resource.Id.password);
            if(url.Text=="")
            {
                Toast.MakeText(this, "Enter URL to proceed", ToastLength.Long).Show();
            }
            else if (username.Text == "")
            {
                Toast.MakeText(this, "Enter Username to proceed", ToastLength.Long).Show();
            }
            else if (password.Text == "")
            {
                Toast.MakeText(this, "Enter Password to proceed", ToastLength.Long).Show();
            }
            else
            {
                Helpers.Settings.URL = url.Text;
                Helpers.Settings.UrlUsername = username.Text;
                Helpers.Settings.UrlPassword = password.Text;
                Toast.MakeText(this, "Admin settings saved", ToastLength.Long).Show();
            }
        }
    }
}