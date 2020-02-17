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
using FB_DataApp.Database.Crud;
using FB_DataApp.Database.Tables;

namespace FB_DataApp.Adapter
{
    public  class UserData
    {
        public  List<User> Users { get; private set; }
        private List<Client> mList, list;
        public UserData()
        {
            var temp = new List<User>();

            AddUser(temp);
           // AddUser(temp);
           // AddUser(temp);

            Users = temp.OrderBy(i => i.Name).ToList();
            Console.WriteLine("number of users " + Users.Count);
        }

         void AddUser(List<User> users)
        {
            
            Select select = new Select();
            list = select.AllClients();
            // Toast.MakeText(this, " count " + mList.ToString(), ToastLength.Long).Show();
            List<Client> obj = new List<Client>();
            foreach (Client a in list)
            {
                if (a.ClientID != "")
                    obj.Add(new Client
                    {
                        ClientID = a.ClientID,
                        Name = a.Name,
                        Dob = a.Dob,
                        Gender = a.Gender,
                        Date = a.Date,
                        Status = a.Status
                       

                    });
                users.Add(new User()
                {
                    Name = a.Name,
                    ID = a.ClientID,
                    Ckt = a.Id.ToString(),
                    ClId=a.Id
                });

            }
        }
    }
}