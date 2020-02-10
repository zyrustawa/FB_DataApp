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
    class Clinic
    {
        [PrimaryKey]
        public int Id { get; set; }
        public String Clinicid { get; set; }
        public String Clinicname { get; set; }
        public String District { get; set; }
        public String Status { get; set; }


    }
}