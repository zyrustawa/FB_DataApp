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
    class Client
    {
        [PrimaryKey, AutoIncrement]

        public String ClientID { get; set; }
        public String Name { get; set; }
        public String Age { get; set; }
        public String Gender { get; set; }
        public String Date { get; set; }
        public String Status { get; set; }


    }
}