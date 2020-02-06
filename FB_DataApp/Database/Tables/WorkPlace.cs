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
    class WorkPlace
    {
        [PrimaryKey, AutoIncrement]
        public string WorkPlaceID { get; set; }
        public string WorkPlaceName { get; set; }
    }
}