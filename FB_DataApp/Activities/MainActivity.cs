using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FB_DataApp.Activities
{
   [Activity(Label = "@string/app_name", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        private Button btnNewClient;
        private Button btnFollowUpClient;
        private Button btnReturningClient;
        private Button btnCktAttendance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnNewClient = FindViewById<Button>(Resource.Id.newclient);
            btnFollowUpClient = FindViewById<Button>(Resource.Id.followupclient);
            btnReturningClient = FindViewById<Button>(Resource.Id.returningclient);
            btnCktAttendance = FindViewById<Button>(Resource.Id.cktregister);

            btnNewClient.Click += OnNewClientClicked;
            btnFollowUpClient.Click += OnFollowUpClientClicked;
            btnReturningClient.Click += OnReturningClientClicked;
            btnCktAttendance.Click += OnCktAttendance;
        }
        void OnNewClientClicked(object sender, EventArgs e)
        {
            StartActivity(typeof(Session1));
        }
        void OnFollowUpClientClicked(object sender, EventArgs e)
        {
            StartActivity(typeof(FollowUpSession));
        }
        void OnReturningClientClicked(object sender, EventArgs e)
        {
            StartActivity(typeof(FollowUpSession));
        }
        void OnCktAttendance(object sender, EventArgs e)
        {
            StartActivity(typeof(CKTRegister));
        }
}
}