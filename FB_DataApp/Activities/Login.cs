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
using MySql.Data.MySqlClient;
using System.Data;

namespace FB_DataApp.Activities
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        private EditText xtUsername , xtPassword;
        private Button btnSignin;
        private Button btnRegister;
        private Button btnForgotPass;
        private TextView SysLog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_login);
            xtUsername = FindViewById<EditText>(Resource.Id.txtusername);
            xtPassword = FindViewById<EditText>(Resource.Id.txtpassword);
            SysLog = FindViewById<TextView>(Resource.Id.syslog);
            btnSignin = FindViewById<Button>(Resource.Id.btnsignin);
            btnRegister = FindViewById<Button>(Resource.Id.btngotoregister);
            btnForgotPass = FindViewById<Button>(Resource.Id.btnforgotpassword);

            btnSignin.Click += SignInBtnClicked;
            btnRegister.Click += GoToRegisterBtnClicked;
            btnForgotPass.Click += ForgotPassBtnClicked;
        }
        private void SignInBtnClicked(object sender, EventArgs e)
        {
                     
           StartActivity(typeof(WelcomePage));
        }
       
        void GoToRegisterBtnClicked(object sender, EventArgs e)
        {
            StartActivity(typeof(Account));
        }
        void ForgotPassBtnClicked(object sender, EventArgs e)
        {
            StartActivity(typeof(ForgotPassword));
        }
       
    }
}