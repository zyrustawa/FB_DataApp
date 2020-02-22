using Android.Util;
using SQLite;
using System;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;

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
        public MySqlConnection Myconn()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "db4free.net";
            conn_string.Port = 3306;
            conn_string.UserID = "progdev";
            conn_string.Password = "progdev";
            conn_string.Database = "progdevdb";
            MySqlConnection conn= new MySqlConnection("Server=db4free.net;Port=3306;database=information_schema;User Id=dzydz123;Password=r147112h;charset=utf8");
            //MySqlConnection conn= new MySqlConnection(conn_string.ToString());
                return conn;
          
        }
    }
}