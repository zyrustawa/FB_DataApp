using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace FB_DataApp.Activities
{
    [Activity(Label = "Account")]
    public class Account : Activity
    {
        
        Button register;
        Button existingaccount;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Account);
            // Create your application here
            register = FindViewById<Button>(Resource.Id.btnregister);

            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.workplace_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
           

            
            existingaccount.Click += ExistingAccount_OnClick;
            register.Click += Register_OnClick;
        }
        
        private void Register_OnClick(object sender, EventArgs e)
        {
           

         
        }
        private void ExistingAccount_OnClick(object sender, EventArgs e)
        {
            StartActivity(typeof(Login));
        }
    }
}