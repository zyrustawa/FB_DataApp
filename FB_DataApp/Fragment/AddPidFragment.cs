using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FB_DataApp.Fragment
{
    public class AddPidFragment : Android.Support.V4.App.DialogFragment
    {
        Button btnsave;
        Button btncancel;
       // TextView pid;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.Give_PID, container, false);
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            //  pid = (TextView)view.FindViewById<TextView>(Resource.Id.pid);
            btncancel = (Button)view.FindViewById(Resource.Id.btncancel);
            btnsave = (Button)view.FindViewById(Resource.Id.btnsave);

            btncancel.Click += Btncancel_Click;
            btnsave.Click += Btnsave_Click;
            return view;
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
           
        }

        private void Btncancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}