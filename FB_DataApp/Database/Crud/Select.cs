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
                            code = 3;// client id already in use
                        }
                        else if (a.Name == args[1] && a.Dob == args[2] && a.Gender==args[3])
                        {
                            code = 2;//client already in the database
                         
                        }
                        
                        else
                        {
                            code = 100;
                        }
                       
                    }
                }
                else
                {
                    code = 1;// client details in the database
                }
                //Log.Info("client-count", "number of client " + mList.Count);

            }
            catch (Exception e)
            {
                code = 0;//Error while processing the transaction
                Log.Error("Database-CheckClient-Error", "Error " + e.Message);
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
                        // Console.WriteLine("check-error-200a sn " + a.SessionNumber+" arg "+args[1]+" cl "+ a.ClientID+" arg "+args[3]);
                        if (a.SessionNumber.Equals(args[1]) && a.ClientID.Equals(args[3]) &&a.Status==args[5])
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
                Log.Error("Database-ChecKSession-Error", "Error " + e.Message);
            }
            return code;
        }
        public List<Client> AllClients()
        {
            List<Client> abc=new List<Client>();
            try
            {
                abc=db.Query<Client>("SELECT * FROM Client");
               // abc = db.Table<Client>().OrderBy(x => x.Id).ToList();
               //var li= db.Query<Client>("SELECT Client.ClientID,Client.Name,CKTRegister.Status,CKTRegister.Status From CKTRegister,Client,Session WHERE Client.ClientID=CKTRegister.ClientID and Client.ClientID=Session.ClientID ");
                //abc=li;
                
            }
            catch (Exception e)
            {
                code = 0;//Error while processing the transaction
                Log.Error("Database-ChecKSession-Error", "Error " + e.Message);
            }
            return abc;
        }
        public int CheckClientSession(String[] args)
        {

            try
            {
                List<ClientSession> abc = db.Table<ClientSession>().OrderBy(x => x.Id).ToList();
                if (abc.Count > 0)
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
                Log.Error("Database-CheckClientSession-Error", "Error " + e.Message);
            }
            return code;
        }
        public int CheckStatus(String table, String clientid, string column)
        {

            try
            {
                List<Session> abc = db.Query<Session>("select * from "+table+" where "+column+"=?",clientid).OrderBy(x => x.Id).ToList();
                return code = abc.Count;

            }
            catch (Exception e)
            {
                code = 0;//Error while processing the transaction
                Log.Error("Database-CheckClientSession-Error", "Error " + e.Message);
            }
            return code;
        }
        public int CheckClinic(String[] args)
        {

            try
            {
                List<Clinic> abc = db.Table<Clinic>().OrderBy(x => x.Id).ToList();
                if (abc.Count > 0)
                {

                    foreach (Clinic a in abc)
                    {
                        if (a.Clinicid == args[0] && a.Clinicname == args[1] && a.District == args[2] && a.Status == args[3])
                        {
                            code = 200;//clinic already captured
                        }
                        else if (a.Clinicid == args[0] && a.Clinicname == args[1] && a.District == args[2] && a.Status != args[3])
                        {
                            code = 6;//clinic deactivated
                        }
                         else if (a.Clinicid == args[0] && a.Clinicname == args[1] && a.District == args[2])
                        {
                            code = 2;//clinic exists
                        }
                        else if (a.Clinicid == args[0] && a.Clinicname == args[1])
                        {
                            code = 3;//clinic exists please verify district
                        }
                        else if (a.Clinicid == args[0])
                        {
                            code = 4;//clinic id occupied
                        }
                        else if (a.Clinicname == args[0])
                        {
                            code = 5;//clinic name already exists
                        }
                        else
                        {
                            code = 100;
                        }

                    }
                }
                else
                {
                    code = 1;//no clinic details in the database
                }

            }
            catch (Exception e)
            {
                code = 0;//Error while processing the transaction
                Log.Error("Database-CheckClientSession-Error", "Error " + e.Message);
            }
            return code;
        }
        public int CheckWorkPlace(String[] args)
        {

            try
            {
                List<WorkPlace> abc = db.Table<WorkPlace>().OrderBy(x => x.Id).ToList();
                if (abc.Count > 0)
                {

                    foreach (WorkPlace a in abc)
                    {
                        if (a.WorkPlaceID == args[0]&& a.WorkPlaceName==args[1])
                        {
                            code = 200;//workplace details already captured
                        }
                        else if(a.WorkPlaceID == args[0])
                        {
                            code = 2;// id occupied
                        }
                        else if (a.WorkPlaceName == args[1])
                        {
                            code = 3;// Workplace already exists
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
                Log.Error("Database-CheckClientSession-Error", "Error " + e.Message);
            }
            return code;
        }
        public List<Client> MyClient(String value, String column)
        {
            List<Client> client = new List<Client>();
            try
            {
               // var stocksStartingWithA = db.Query<Client>("SELECT * FROM Client WHERE "+column+" = ?", value);
                var stocksStartingWithA = db.Query<Client>("SELECT * FROM Client WHERE "+column+" = ?", value);
                if (stocksStartingWithA.Count == 1)
                {
                    foreach (var s in stocksStartingWithA)
                    {
                        Console.WriteLine("id=" + s.Id);
                    }
                    client = stocksStartingWithA;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("error-query " + ex.Message);
            }
            return client;
        }
        public List<Client> MyClient1(String value, String column)
        {
            List<Client> client = new List<Client>();
            try
            {
                var stocksStartingWithA = db.Query<Client>("SELECT * FROM Client WHERE "+column+" = ?", value);
                //var stocksStartingWithA = db.Query<Client>("SELECT * FROM Client");
               // if (stocksStartingWithA.Count = 1)
                    foreach (var s in stocksStartingWithA)
                    {
                        Console.WriteLine("id=" + s.Id);
                    }
                client = stocksStartingWithA;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error-query " + ex.Message);
            }
            return client;
        }
        public int MySessions(String value, string column)
        {
            int zero=0;
            String sessionid = "";
            List<Client> client = new List<Client>();
            try
            {
                // var stocksStartingWithA = db.Query<Client>("SELECT * FROM Client WHERE "+column+" = ?", value);
                var stocksStartingWithA = db.Query<Session>("SELECT * FROM Session WHERE "+column+"= ?", value);
                zero = stocksStartingWithA.Count;


            }
            catch (Exception ex)
            {
                Console.WriteLine("error-query " + ex.Message);
            }
            return zero;
        }

        public int CheckCKT(String[] args)
        {

            try
            {
                List<CKTRegister> abc = db.Query<CKTRegister>("select * from CKTRegister").OrderBy(x => x.Id).ToList();
                if (abc.Count > 0)
                {

                    foreach (CKTRegister a in abc)
                    {
                        if (a.ClientID == args[0] && a.SessionID == args[1] && a.WorkPlaceID == args[2] && a.Status == args[3])
                        {
                            code = 200;//workplace details already captured
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
                Log.Error("Database-CheckClientSession-Error", "Error " + e.Message);
            }
           Log.Error("no-error", "Error se " + code);
            return code;
        }
    }
}