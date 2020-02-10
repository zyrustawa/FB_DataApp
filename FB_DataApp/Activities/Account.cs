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
using FB_DataApp.Database.Crud;

namespace FB_DataApp.Activities
{
    [Activity(Label = "Account")]
    public class Account : Activity
    {
        private String gender = "";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Account);
            // Create your application here
            Button save = FindViewById<Button>(Resource.Id.button1);

            save.Click += Save_Click;
            // //ssq1
            RadioGroup answer1 = FindViewById<RadioGroup>(Resource.Id.rbtngender);
            answer1.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer1.CheckedRadioButtonId).Text;
                gender = option;
            };
        }
       

        private void Save_Click(object sender, EventArgs e)
        {
            EditText name = FindViewById<EditText>(Resource.Id.name);
            EditText surname = FindViewById<EditText>(Resource.Id.surname);
            EditText username = FindViewById<EditText>(Resource.Id.username);
            EditText address = FindViewById<EditText>(Resource.Id.email);
            EditText contact = FindViewById<EditText>(Resource.Id.contact);
            EditText dob = FindViewById<EditText>(Resource.Id.dob);
            EditText pass1 = FindViewById<EditText>(Resource.Id.pass1);
            EditText pass2 = FindViewById<EditText>(Resource.Id.pass2);
            EditText natid = FindViewById<EditText>(Resource.Id.natid);
            

             if(name.Text=="")
            {
                Toast.MakeText(this, "Please enter name", ToastLength.Short).Show();
            }
            else if (surname.Text == "")
            {
                Toast.MakeText(this, "Please enter surname", ToastLength.Short).Show();
            }
            else if (username.Text == "")
            {
                Toast.MakeText(this, "Please enter Lay Health Worker Id", ToastLength.Short).Show();
            }
            else if (address.Text == "")
            {
                Toast.MakeText(this, "Please enter physical address", ToastLength.Short).Show();
            }
            else if (contact.Text == "")
            {
                Toast.MakeText(this, "Please enter contact number", ToastLength.Short).Show();
            }
            else if (dob.Text == "")
            {
                Toast.MakeText(this, "Please enter date of birth", ToastLength.Short).Show();
            }
            else if (natid.Text == "")
            {
                Toast.MakeText(this, "Please enter national id", ToastLength.Short).Show();
            }
            else if (pass1.Text == "")
            {
                Toast.MakeText(this, "Please enter password", ToastLength.Short).Show();
            }
            else if (pass2.Text == "")
            {
                Toast.MakeText(this, "Please re-enter password", ToastLength.Short).Show();
            }
            else if (pass1.Text != pass2.Text)
            {
                Toast.MakeText(this, "Password mismatch", ToastLength.Short).Show();
            }
            else if (pass2.Text.Length<6)
            {
                Toast.MakeText(this, "Please enter a strong password", ToastLength.Short).Show();
            }
            else
            {
                String[] list = { username.Text, name.Text, surname.Text, address.Text, contact.Text, dob.Text, pass1.Text, gender, "clinic", "workplace", natid.Text };
                Insert abc = new Insert();
                int a = abc.Lhw(list);
                if(a==100)
                {
                    Toast.MakeText(this, "Lay health worker information saved " , ToastLength.Short).Show();
                }
                else if(a== 200)
                {
                    Toast.MakeText(this, "Error while saving data ", ToastLength.Short).Show();
                }
                else if(a== 201 || a==0)
                {
                    Toast.MakeText(this, "Internal error", ToastLength.Short).Show();
                }
                else if(a== 2)
                {
                    Toast.MakeText(this, "Account exists", ToastLength.Short).Show();
                }
                else if(a== 3)
                {
                    Toast.MakeText(this, "Layhealth worker ID already in use for the clinic", ToastLength.Short).Show();
                }
                else if(a== 4)
                {
                    Toast.MakeText(this, "Layhealth worker details already in use", ToastLength.Short).Show();
                }
                else if(a== 5)
                {
                    Toast.MakeText(this, "Layhealth worker national already in use", ToastLength.Short).Show();
                }

                else
                {
                    Toast.MakeText(this, "Unknown error ", ToastLength.Short).Show();
                }
            }
           
        }
    }
}