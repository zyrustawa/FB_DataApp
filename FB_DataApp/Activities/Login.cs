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
using FB_DataApp.Fragment;
using Android.Support.V4.App;

namespace FB_DataApp.Activities
{
    [Activity(Label = "Login")]
    public class Login : FragmentActivity
    {
      //  private EditText xtUsername , xtPassword;
        private Button btnSignin;
        private Button btnRegister;
        private Button btnForgotPass;
      //  private TextView SysLog;

        AddRegisterFragment addRegisterFragment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_login);
          //  xtUsername = FindViewById<EditText>(Resource.Id.txtusername);
           // xtPassword = FindViewById<EditText>(Resource.Id.txtpassword);
           // SysLog = FindViewById<TextView>(Resource.Id.syslog);
            btnSignin = FindViewById<Button>(Resource.Id.btnsignin);
            btnRegister = FindViewById<Button>(Resource.Id.btngotoregister);
            btnForgotPass = FindViewById<Button>(Resource.Id.btnforgotpassword);

            btnSignin.Click += BtnSignin_Click;
            btnRegister.Click += GoToRegisterBtnClicked;
            btnForgotPass.Click += ForgotPassBtnClicked;
        }

        private void BtnSignin_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(WelcomePage));
        }
       
        void GoToRegisterBtnClicked(object sender, EventArgs e)
        {
            addRegisterFragment = new AddRegisterFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            addRegisterFragment.Show(trans,"new User");
        }
        void ForgotPassBtnClicked(object sender, EventArgs e)
        {
            StartActivity(typeof(ForgotPassword));
        }
       
    }
}