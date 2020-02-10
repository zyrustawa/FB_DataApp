using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using FB_DataApp.Database.Tables;
using SQLite;

namespace FB_DataApp.Database.Crud
{
    class Select
    {
        private SQLiteConnection db = null;
        int code = 0;
        private List<LayHealthWorker> mList, list;
        public Select()
        {
            db = new MyDB().MyConn();
            new Insert();
        }
        public int Exists(String [] args)
        {

            try
            {
                list = db.Table<LayHealthWorker>().OrderBy(x => x.Name).ToList();
                if (list.Count > 0)
                {

                    foreach (LayHealthWorker a in list)
                    {
                        if (a.LHWid==args[0] && a.Name==args[1] && a.Surname== args[2] && a.Clinic== args[8] && a.Natid == args[10])
                        {
                            code = 2;//account exists
                        }
                        else if (a.LHWid == args[0] && a.Clinic == args[8])
                        {
                            code = 3;//layhealth worker id for the clinic already used
                        }
                        else if (a.Name == args[1] && a.Surname == args[2] && a.Natid == args[10])
                        {
                            code = 4;//name and national id for the lay health worker used
                        }
                        else if (a.Natid == args[10])
                        {
                            code = 5;// national id already in use
                        }
                        else
                        {
                            code = 100;
                        }
                        
                    }
                }
                else
                {
                    code = 1;//no Layhealthworker details in the database
                }

            }
            catch (Exception e)
            {
                code = 0;//Error while processing the transaction
                Log.Error("Database-Error", "Error " + e.Message);
            }
            return code;
        }
        public int Login(String[] args)
        {

            try
            {
                list = db.Table<LayHealthWorker>().OrderBy(x => x.Id).ToList();
                if (list.Count > 0)
                {

                    foreach (LayHealthWorker a in list)
                    {
                        if (a.LHWid == args[0] && a.Password==args[1])
                        {
                            code = 100;//account exists
                        }
                       
                        else
                        {
                            code = 200;
                        }

                    }
                }
                else
                {
                    code = 1;//no Layhealthworker details in the database
                }

            }
            catch (Exception e)
            {
                code = 0;//Error while processing the transaction
                Log.Error("Database-Error", "Error " + e.Message);
            }
            return code;
        }
        public int CheckClient(String[] args)
        {

            try
            {
                List<Client> mList = db.Table<Client>().OrderBy(x => x.Id).ToList();
                if (mList.Count > 0)
                {

                    foreach (Client a in mList)
                    {
                        if(a.ClientID==args[0])
                        {
                            code = 200;// client id already in use
                        }
                        else if (a.Name == args[1] && a.Dob == args[2] && a.Gender==args[3])
                        {
                            code = 201;//client already in the database
                        }
                        
                        else
                        {
                            code = 100;
                        }

                    }
                }
                else
                {
                    code = 1;//no client details in the database
                }

            }
            catch (Exception e)
            {
                code = 0;//Error while processing the transaction
                Log.Error("Database-Error", "Error " + e.Message);
            }
            return code;
        }

        public int ChecKSession(String[] args)
        {

            try
            {
               List<Session> abc = db.Table<Session>().OrderBy(x => x.Id).ToList();
                if (abc.Count > 0)
                {

                    foreach (Session a in abc)
                    {
                        if (a.SessionNumber == args[1] && a.ClientID == args[3])
                        {
                            code = 200;//details exists
                        }

                        else
                        {
                            code = 100;//no duplicate 
                        }

                    }
                }
                else
                {
                    code = 1;//no Session details in the database
                }

            }
            catch (Exception e)
            {
                code = 0;//Error while processing the transaction
                Log.Error("Database-Error", "Error " + e.Message);
            }
            return code;
        }
        public int CheckClientSession(String[] args)
        {

            try
            {
                List<ClientSession> abc = db.Table<ClientSession>().OrderBy(x => x.Id).ToList();
                if (list.Count > 0)
                {

                    foreach (ClientSession a in abc)
                    {
                        if (a.SessionID == args[0])
                        {
                            code = 200;//session already captured
                        }

                        else
                        {
                            code = 100;
                        }

                    }
                }
                else
                {
                    code = 1;//no Layhealthworker details in the database
                }

            }
            catch (Exception e)
            {
                code = 0;//Error while processing the transaction
                Log.Error("Database-Error", "Error " + e.Message);
            }
            return code;
        }
    }
}