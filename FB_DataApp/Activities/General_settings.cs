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
using FB_DataApp.Database.Crud;

namespace FB_DataApp.Activities
{
    [Activity(Label = "General_settings")]
    public class General_settings : AppCompatActivity
    {
        String District = "", backup="";
        TextView dis = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.General_settings);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Data-Collect: General Settings";

            Spinner sp1 = FindViewById<Spinner>(Resource.Id.spinner1);
            sp1.ItemSelected += Sp1_ItemSelected;
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.District, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            sp1.Adapter = adapter;

            //save button
            Button save = FindViewById<Button>(Resource.Id.button1);
            save.Click += Save_Click;
             dis = FindViewById<TextView>(Resource.Id.District1243);
            dis.Text = Helpers.Settings.District;
            //Reset Button
            Button reset = FindViewById<Button>(Resource.Id.button2);
            reset.Click += Reset_Click;
            //set general settings

            EditText id = FindViewById<EditText>(Resource.Id.clinicid);
            Switch sw = FindViewById<Switch>(Resource.Id.switch1);
            sw.CheckedChange += Sw_CheckedChange;
            bool abc = (Helpers.Settings.BackUp.ToLower() == "true") ? true : false;
            sw.Checked = abc;
           // Toast.MakeText(this, "backup " + abc + " " + Helpers.Settings.BackUp, ToastLength.Long).Show();
            
            EditText cname = FindViewById<EditText>(Resource.Id.clinicname);
            EditText wkpid = FindViewById<EditText>(Resource.Id.wkpid);
            EditText wkpname = FindViewById<EditText>(Resource.Id.wkpname);
            id.Text = Helpers.Settings.ClinicId;
            cname.Text = Helpers.Settings.ClinicName;
            wkpid.Text = Helpers.Settings.Workplace;
            wkpname.Text = Helpers.Settings.WkpName;
            
           

        }

        private void Sw_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            backup = e.IsChecked.ToString();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            EditText id = FindViewById<EditText>(Resource.Id.clinicid);
            EditText cname = FindViewById<EditText>(Resource.Id.clinicname);
            EditText wkpid = FindViewById<EditText>(Resource.Id.wkpid);
            EditText wkpname = FindViewById<EditText>(Resource.Id.wkpname);
            String[] clinic = { id.Text, cname.Text, District, "0" };
            String[] workplace = { wkpid.Text, wkpname.Text };
            Select abc = new Select();
            int a = abc.CheckClinic(clinic);
            int b = abc.CheckWorkPlace(workplace);
            // Toast.MakeText(this, "Cannot find the saved general settings,l", ToastLength.Long).Show();
            try
            {
                
                if(a==200 && b==200)
                {
                    Helpers.Settings.ClinicId = id.Text;
                    Helpers.Settings.ClinicName = cname.Text;
                    Helpers.Settings.District = District;
                    Helpers.Settings.WkpName = wkpname.Text;
                    Helpers.Settings.Workplace = wkpid.Text;
                    Helpers.Settings.BackUp = backup;
                    dis.Text = Helpers.Settings.District;
                    Toast.MakeText(this, "General settings set", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Cannot find the saved general settings, Please save the details and proceed", ToastLength.Long).Show();
                }
            }
            catch(Exception ex)
            {
                Toast.MakeText(this, "error-gs-reset "+ex.Message, ToastLength.Long).Show();

            }
            finally
            {
                //Toast.MakeText(this, "Cannot find the saved general settings, "+a+ " "+b, ToastLength.Long).Show();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {

            EditText id = FindViewById<EditText>(Resource.Id.clinicid);
            EditText cname = FindViewById<EditText>(Resource.Id.clinicname);
            EditText wkpid = FindViewById<EditText>(Resource.Id.wkpid);
            EditText wkpname = FindViewById<EditText>(Resource.Id.wkpname);
            try
            {
                if (int.Parse(id.Text)<1 || int.Parse(id.Text) > 36)
                {
                    Toast.MakeText(this, "Invalid clinic id", ToastLength.Long).Show();
                }
                else if(cname.Text=="")
                 {
                    Toast.MakeText(this, "Enter the clinic name to proceed", ToastLength.Long).Show();
                }
                else if (District== "Select District")
                {
                    Toast.MakeText(this, "Select the district name to proceed", ToastLength.Long).Show();
                }
                else if (int.Parse(wkpid.Text) < 1 || int.Parse(wkpid.Text) > 36)
                { 
                    Toast.MakeText(this, "Invalid Workplace Id", ToastLength.Long).Show();
                }
                else if (wkpname.Text == "")
                {
                    Toast.MakeText(this, "Enter the Work place name to proceed", ToastLength.Long).Show();
                }
                else
                {
                    //save general settings
                    String[] clinic = { id.Text, cname.Text, District, "0" };
                    String[] workplace = { wkpid.Text, wkpname.Text };
                    Insert abc = new Insert();
                    int a = abc.Clinic(clinic);
                    int b = abc.WorkPlace(workplace);
                    if (a == 100 && b == 100)
                    {
                        Toast.MakeText(this, "General settings saved", ToastLength.Long).Show();
                    }
                    else if (a == 201 || b == 201)
                    {
                        Toast.MakeText(this, "Database error while saving general settings", ToastLength.Long).Show();

                    }
                    else if (a == 200 || b == 200)
                    {
                        Toast.MakeText(this, "Details already exists", ToastLength.Long).Show();

                    }
                    else
                    {
                        Toast.MakeText(this, "Unknown error-a " + a +" b "+b, ToastLength.Long).Show();

                    }
                }
            }
            catch(Exception ex)
            {
                Toast.MakeText(this, "Error-save-general-settings "+ex.Message, ToastLength.Long).Show();
            }
            finally
            {

            }
            
            
        }


        private void Sp1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner sp = (Spinner)sender;
            District = string.Format("{0}", sp.GetItemAtPosition(e.Position));
            dis.Text = Helpers.Settings.District;
        }
    }
}