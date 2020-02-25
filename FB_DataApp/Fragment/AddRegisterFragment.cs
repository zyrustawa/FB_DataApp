using System;
using System.Collections.Generic;

using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using FB_DataApp.Helpers;
using Firebase.Database;
using FR.Ganfra.Materialspinner;
using Java.Util;

namespace FB_DataApp.Fragment
{
    public class AddRegisterFragment : Android.Support.V4.App.DialogFragment
    {
        TextInputLayout nameText;
        TextInputLayout surnameText;
        TextInputLayout idText;
        TextInputLayout contactText;
        TextInputLayout addressText;
        TextInputLayout passwordText;
        TextInputLayout cpasswordText;
        MaterialSpinner genderspinner;
        MaterialSpinner workplacespinner;
        Button registerBtn;

        List<string> genderlist;
        List<string> workplacelist;
        ArrayAdapter<string> adapter;
        ArrayAdapter<string> adapter1;
        string gender;
        string workplace;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.Account, container, false);
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            nameText = (TextInputLayout)view.FindViewById(Resource.Id.nameText);
            surnameText = (TextInputLayout)view.FindViewById(Resource.Id.surnameText);
            idText = (TextInputLayout)view.FindViewById(Resource.Id.idText);
            contactText = (TextInputLayout)view.FindViewById(Resource.Id.contactText);
            addressText = (TextInputLayout)view.FindViewById(Resource.Id.addressText);
            passwordText = (TextInputLayout)view.FindViewById(Resource.Id.passwordText);
            cpasswordText = (TextInputLayout)view.FindViewById(Resource.Id.cpasswordText);
            genderspinner = (MaterialSpinner)view.FindViewById(Resource.Id.genderspinner);
            workplacespinner = (MaterialSpinner)view.FindViewById(Resource.Id.workplacespinner);
            registerBtn = (Button)view.FindViewById(Resource.Id.btnregister);

            registerBtn.Click += RegisterBtn_Click;
            SetUpGenderSpinner();
            SetUpWorkplaceSpinner();

            return view;
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            string name = nameText.EditText.Text;
            string surname = surnameText.EditText.Text;
            string id = idText.EditText.Text;
            string contact = contactText.EditText.Text;
            string address = addressText.EditText.Text;
            string password = passwordText.EditText.Text;
            string cpassword = cpasswordText.EditText.Text;

            
                
                HashMap registerInfo = new HashMap();
                registerInfo.Put("name", name);
                registerInfo.Put("surname", surname);
                registerInfo.Put("id", id);
                registerInfo.Put("contact", contact);
                registerInfo.Put("gender", gender);
                registerInfo.Put("workplace", workplace);
                registerInfo.Put("address", address);
                registerInfo.Put("password", password);

                Android.Support.V7.App.AlertDialog.Builder saveDataAlert = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                saveDataAlert.SetTitle("SAVE REGISTER INFORMATION");
                saveDataAlert.SetMessage("Are you sure?");
                saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
                {
                    DatabaseReference newUserRef = AppDataHelper.GetDatabase().GetReference("user").Push();
                    newUserRef.SetValue(registerInfo);
                    this.Dismiss();
                });
                saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    saveDataAlert.Dispose();
                });
            
        }

        public void SetUpGenderSpinner()
        {
            genderlist = new List<string>
            {
                "Female",
                "Male"
            };

            adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, genderlist);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            genderspinner.Adapter = adapter;
            genderspinner.ItemSelected += Genderspinner_ItemSelected;
        }

        private void Genderspinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if(e.Position != -1)
            {
                gender = genderlist[e.Position];
            }
            
        }

        public void SetUpWorkplaceSpinner()
        {
            workplacelist = new List<string>
            {
                "Belvedere",
                "Dz Rujeko",
                "Rutsanana",
                "Warren Park",
                "Western Triangle"
            };

            adapter1 = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, workplacelist);
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            workplacespinner.Adapter = adapter1;
            workplacespinner.ItemSelected += Workplacespinner_ItemSelected;
        }

        private void Workplacespinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                workplace = workplacelist[e.Position];
            }
            
        }
    }
}