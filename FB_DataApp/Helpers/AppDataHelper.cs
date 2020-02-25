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
using Firebase.Database;
using Firebase;


namespace FB_DataApp.Helpers
{
    public static class AppDataHelper
    {
        public static FirebaseDatabase GetDatabase()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseDatabase database;
            if(app == null)
            {
                var option = new Firebase.FirebaseOptions.Builder()
                    .SetApplicationId("fbscaleupdata")
                    .SetApiKey("AIzaSyCvwXA7kfWfDUhXe7tsYhN8envitIpY99I")
                    .SetDatabaseUrl("https://fbscaleupdata.firebaseio.com")
                    .SetStorageBucket("fbscaleupdata.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, option);
                database = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                database = FirebaseDatabase.GetInstance(app);
            }
            return database;
        }
    }
}