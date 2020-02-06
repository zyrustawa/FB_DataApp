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

        public String SessionID { get; set; }
        public bool Qsn1 { get; set; }
        public bool Qsn2 { get; set; }
        public bool Qsn3 { get; set; }
        public bool Qsn4 { get; set; }
        public bool Qsn5 { get; set; }
        public bool Qsn6 { get; set; }
        public bool Qsn8 { get; set; }
        public bool Qsn9 { get; set; }
        public bool Qsn10 { get; set; }
        public bool Qsn11 { get; set; }
        public bool Qsn12 { get; set; }
        public bool Qsn13 { get; set; }
        public bool Qsn14 { get; set; }
        public String Date1 { get; set; }
        public String Status { get; set; }
    }
}