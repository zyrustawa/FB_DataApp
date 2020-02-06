using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FB_DataApp.Database.Tables
{
    class CKTRegister
    {
        [PrimaryKey, AutoIncrement]

        public String ClientID { get; set; }
        public String SessionID { get; set; }
        public String WorkPlaceID { get; set; }
        public String Status { get; set; }
    }
}