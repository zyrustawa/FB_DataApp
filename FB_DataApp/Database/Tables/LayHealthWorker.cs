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
using SQLite;

namespace FB_DataApp.Database.Tables
{
    class LayHealthWorker
    {
       [PrimaryKey]
        public String LHWid { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Contact { get; set; }
        public String Address { get; set; }
        public String Dob { get; set; }//dob=date of birth
        public String Clinic { get; set; }
        public String Gender { get; set; }
        public String WorkplaceID { get; set; }
        public String Password { get; set; }




    }
}