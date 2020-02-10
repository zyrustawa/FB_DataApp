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
using FB_DataApp.Database.Crud;

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
            TextView textView1 = FindViewById<TextView>(Resource.Id.forg);
            textView1.Click += TextView1_Click;
            Button btn1 = FindViewById<Button>(Resource.Id.login);
            btn1.Click += Btn1_Click;
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            EditText username = FindViewById<EditText>(Resource.Id.username);
            EditText password1 = FindViewById<EditText>(Resource.Id.password);
            if(username.Text=="" || password1.Text=="")
            {
                Toast.MakeText(this, "Please provide layhealth worker id and password to proceed", ToastLength.Short).Show();
            }
            else
            {
                String [] abc = {username.Text,password1.Text};
                Select select = new Select();
                int code = select.Login(abc);
                if(code==100)
                {
                    Toast.MakeText(this, "Login successfull", ToastLength.Short).Show();
                    Intent intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                }
                else if(code== 200)
                {
                    Toast.MakeText(this, "Login error, please re-enter your details", ToastLength.Short).Show();
                }
                else if(code== 1)
                {
                    Toast.MakeText(this, "No layhealth worker details found, create account", ToastLength.Short).Show();
                }
               
                else
                {
                    Toast.MakeText(this, "connection error", ToastLength.Short).Show();
                }
            }
        }

        private void TextView1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TextView_Click(object sender, EventArgs e)
        {
            Intent abc = new Intent(this, typeof(Account));
            StartActivity(abc);
        }
    }
}