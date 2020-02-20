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
    [Activity(Label = "Account")]
    public class Account : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Button existingaccount = FindViewById<Button>(Resource.Id.btnexistingaccount);
            existingaccount.Click += ExistingAccountClicked;
        }
        void ExistingAccountClicked(object sender, EventArgs e)
        {
            StartActivity(typeof(Login));
        }
    }
}