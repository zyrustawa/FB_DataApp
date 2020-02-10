using Android.Util;
using SQLite;
using System;
using System.IO;

namespace FB_DataApp.Database
{
    class MyDB
    {
        //private String DbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Fbdb.db3");
        public SQLiteConnection MyConn()
        {
            var dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "FbSessiondb.sqlite");
            if(File.Exists(dbpath))
            {
                Log.Error("FBdatabase","file exists ");
            }
            else
            {
                Log.Error("FBdatabase", "file does not exist");
            }
            return new SQLiteConnection(dbpath, true);
        }
    }
}