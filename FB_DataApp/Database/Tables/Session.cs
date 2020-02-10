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
    class Session
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public String SessionID { get; set; }// clientid+date when the session was done
        public String SessionNumber { get; set; }
        public String WorkPlaceID { get; set; }
        public String ClientID { get; set; }
        public String LayHealthWorkerID { get; set; }
        public String Status { get; set; }
    }
}