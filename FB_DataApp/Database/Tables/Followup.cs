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
    class Followup
    {
        [PrimaryKey]
        public int Id { get; set; }
        public String FupId { get; set; }
        public String SessionID { get; set; }
        public String status { get; set; }
    }
}