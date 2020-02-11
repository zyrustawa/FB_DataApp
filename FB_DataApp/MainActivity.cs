using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Content;
using Android.Views;
using FB_DataApp.Activities;
using System;
using Android.Util;
using FB_DataApp.Classes;

namespace FB_DataApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Data-Collect";
            new TestConnection();
            //click event for logo
            ImageView image = FindViewById<ImageView>(Resource.Id.imageView2);
            image.Click += Image_Click;
            //click event for new client
            TextView client = FindViewById<TextView>(Resource.Id.newclient);
            client.Click += Client_Click;

            //click event for follow up client
            TextView followup = FindViewById<TextView>(Resource.Id.followup);
            followup.Click += Followup_Click;

            //click event for returning client
            TextView returnre = FindViewById<TextView>(Resource.Id.newproblem);
            returnre.Click += Returnre_Click;
            //click event for CKT Register
            TextView reg = FindViewById<TextView>(Resource.Id.cktreg);
            reg.Click += Reg_Click;
            //String sid = DateTime.Now.ToShortDateString();
          

        }

        private void Reg_Click(object sender, EventArgs e)
        {
            try
            {
                Intent intent = new Intent(this, typeof(CKTRegister));
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                Log.Error("Image click", "Error " + ex.Message);
            }
            finally
            {

            }
        }

        private void Returnre_Click(object sender, EventArgs e)
        {
            try
            {
                Intent intent = new Intent(this, typeof(FollowUpSession));
                intent.PutExtra("arg","1");//0 for a follow up of the different issue
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                Log.Error("Image click", "Error " + ex.Message);
            }
            finally
            {

            }
        }

        private void Followup_Click(object sender, EventArgs e)
        {
            try
            {
                Intent intent = new Intent(this, typeof(FollowUpSession));
                intent.PutExtra("arg", "0");// same issue
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                Log.Error("Image click", "Error " + ex.Message);
            }
            finally
            {

            }
        }

        private void Client_Click(object sender, EventArgs e)
        {
            try
            {
                Intent intent = new Intent(this, typeof(Session1));
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                Log.Error("Image click", "Error " + ex.Message);
            }
            finally
            {

            }
        }

        private void Image_Click(object sender, System.EventArgs e)
        {
           try
            {
                Intent intent = new Intent(this, typeof(Activity1));
                StartActivity(intent);
            }
            catch(Exception ex)
            {
                Log.Error("Image click", "Error " + ex.Message);
            }
            finally
            {

            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            // shona=FindViewById<IMenuItem>(menu.FindItem)
            return base.OnCreateOptionsMenu(menu);

        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.nav_home:
                    {
                        Intent homeIntent = new Intent(this, typeof(Login));
                        StartActivity(homeIntent);
                        return true;
                    }
                case Resource.Id.nav_about:
                    {
                        Intent homeIntent = new Intent(this, typeof(About));
                        StartActivity(homeIntent);
                        return true;
                    }
                case Resource.Id.nav_help:
                    {
                        Intent homeIntent = new Intent(this, typeof(Help));
                        StartActivity(homeIntent);
                        return true;
                    }
                case Resource.Id.nav_Support:
                    {
                        Intent homeIntent = new Intent(this, typeof(Login));
                        StartActivity(homeIntent);
                        return true;
                    }
                case Resource.Id.nav_general:
                    {
                        Intent homeIntent = new Intent(this, typeof(General_settings));
                        StartActivity(homeIntent);
                        return true;
                    }
                case Resource.Id.nav_admin:
                    {
                        Intent homeIntent = new Intent(this, typeof(Admin_settings));
                        StartActivity(homeIntent);
                        return true;
                    }


            }
            return base.OnOptionsItemSelected(item);
        }
    }
}