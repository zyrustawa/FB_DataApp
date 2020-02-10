using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FB_DataApp.Database;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using FB_DataApp.Database.Tables;

namespace FB_DataApp.Classes
{
    class TestConnection
    {
        private SQLiteConnection db = null;
        public TestConnection()
        {
            // db = new MyDB().MyConn();
            //db.CreateTable<Client>();
        }

    }
}