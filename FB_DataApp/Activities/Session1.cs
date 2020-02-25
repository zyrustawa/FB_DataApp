using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using FB_DataApp.Fragment;
using Java.Util;

namespace FB_DataApp.Activities
{
    [Activity(Label = "Session1")]
    public class Session1 : FragmentActivity
    {
        EditText name;
        EditText surname;
       // RadioGroup gender;
       // EditText age;
        //EditText location;
        Button btngivepid;

       AddPidFragment addPidFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_session1);
            name = FindViewById<EditText>(Resource.Id.name);
            surname = FindViewById<EditText>(Resource.Id.surname);
           // gender = FindViewById<RadioGroup>(Resource.Id.gender);
           // age = FindViewById<EditText>(Resource.Id.age);
           btngivepid = FindViewById<Button>(Resource.Id.btngivepid);

           btngivepid.Click += Givepid_Click;
        }

       private void Givepid_Click(object sender, EventArgs e)
        {
            
           // HashMap newsessionInfo = new HashMap();
           // newsessionInfo.Put("name", name);
          //  newsessionInfo.Put("surname", surname);
            


            addPidFragment = new AddPidFragment();
           var trans = SupportFragmentManager.BeginTransaction();
           addPidFragment.Show(trans, "new Pid");
       }
    }
}