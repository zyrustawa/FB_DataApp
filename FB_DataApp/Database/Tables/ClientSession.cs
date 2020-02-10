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

namespace FB_DataApp.Database
{
    class ClientSession
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String SessionID { get; set; }
        public String Qsn1 { get; set; }
        public String Qsn2 { get; set; }
        public String Qsn3 { get; set; }
        public String Qsn4 { get; set; }
        public String Qsn5 { get; set; }
        public String Qsn6 { get; set; }
        public String Qsn7 { get; set; }

        public String Qsn8 { get; set; }
        public String Qsn9 { get; set; }
        public String Qsn10 { get; set; }
        public String Qsn11 { get; set; }
        public String Qsn12 { get; set; }
        public String Qsn13 { get; set; }
        public String Qsn14 { get; set; }
        public String Date1 { get; set; }
        public String Status { get; set; }
    }
}