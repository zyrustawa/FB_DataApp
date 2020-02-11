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
    class Insert
    {

        //insert lhw information
        int status = 0;
        //private List<LayHealthWorker> mList, list;
        private SQLiteConnection db = null;
        public Insert()
        {
            try
            {
                db = new MyDB().MyConn();
                //db.CreateTables<LayHealthWorker, CKTRegister>;
                
                db.CreateTable<LayHealthWorker>();
                db.CreateTable<CKTRegister>();
                db.CreateTable<Client>();
                db.CreateTable<ClientSession>();
                db.CreateTable<Session>();
                db.CreateTable<WorkPlace>();
                db.CreateTable<Clinic>();
            }
            catch (Exception ex)
            {
                Log.Error("database", "error " + ex.Message);
            }


        }
        public int Lhw(String []args)

        { 
            Select select = new Select();
            int ex = select.Exists(args);
            try
            {
                if (args.Length == 11)
                {

                    if (ex == 100 || ex==1)
                    {
                        var maxPk = db.Table<LayHealthWorker>().OrderByDescending(c => c.Id).FirstOrDefault();
                        LayHealthWorker abc = new LayHealthWorker()
                        {

                            Id = (maxPk == null ? 1 : maxPk.Id + 1),

                            LHWid = args[0],
                            Name = args[1],
                            Surname = args[2],
                            Address = args[3],
                            Contact = args[4],
                            Dob = args[5],
                            Password = args[6],
                            Gender = args[7],
                            Clinic = args[8],
                            WorkplaceID = args[9],
                            Natid = args[10]
                        };
                        int a = db.Insert(abc);
                        if (a == 1)
                        {
                            status = 100;//saved data
                        }
                        else
                        {
                            status = 200;// error while saving data
                        }
                    }
                    else
                    {
                        status = ex;
                    }
                }
                else
                {
                    status = 0;
                }

        }
            catch(Exception x)
            {
                status = 201;
                Log.Error("Savedata", "Error " + x.Message);
            }
            return status;
        }
        public int Client(String [] args)
        {
            try
            {
                Select select = new Select();
                int ex = select.CheckClient(args);
                if(args.Length==6)
                {
                    if(ex==1 || ex==100)
                    {
                        var maxPk = db.Table<Client>().OrderByDescending(c => c.Id).FirstOrDefault();
                        Client abc = new Client()
                        {

                            Id = (maxPk == null ? 1 : maxPk.Id + 1),

                            ClientID = args[0],
                            Name = args[1],
                            Dob = args[2],
                            Gender = args[3],
                            Date = args[4],
                             Status = args[5]
                           
                        };
                        int a = db.Insert(abc);
                        if (a == 1)
                        {
                            status = 100;//saved data
                        }
                        else
                        {
                            status = 200;// error while saving data
                        }
                    }
                    else
                    {
                        status = ex;

                    }
                }
                else
                {
                    status = 0;
                }
            }
            catch(Exception ex)
            {
                status = 201;
                Log.Error("Savedata", "Error " + ex.Message);
            }
            return status;
        }
        public int Session(String[] args)
        {
            try
            {
                Select select = new Select();
                int ex = select.ChecKSession(args);
                if (args.Length == 6)
                {
                    if (ex == 1 || ex == 100)
                    {
                        var maxPk = db.Table<Session>().OrderByDescending(c => c.Id).FirstOrDefault();
                        Session abc = new Session()
                        {

                            Id = (maxPk == null ? 1 : maxPk.Id + 1),

                            SessionID = args[0],
                            SessionNumber = args[1],
                            WorkPlaceID = args[2],
                            ClientID = args[3],
                            LayHealthWorkerID = args[4],
                            Status = args[5]

                        };
                        int a = db.Insert(abc);
                        if (a == 1)
                        {
                            status = 100;//saved data
                        }
                        else
                        {
                            status = 200;// error while saving data
                        }
                    }
                    else
                    {
                        status = ex;
                    }
                }
                else
                {
                    status = 0;
                }
            }
            catch (Exception ex)
            {
                status = 201;
                Log.Error("Savedata", "Error " + ex.Message);
            }
            return status;
        }
        public int ClientSession(String[] args)
        {
            try
            {
                Select select = new Select();
                int ex = select.CheckClientSession(args);
                if (args.Length == 17)
                {
                    if (ex == 1 || ex == 100)
                    {
                        var maxPk = db.Table<ClientSession>().OrderByDescending(c => c.Id).FirstOrDefault();
                        ClientSession abc = new ClientSession()
                        {

                            Id = (maxPk == null ? 1 : maxPk.Id + 1),

                            SessionID = args[0],
                            Qsn1 = args[1],
                            Qsn2 = args[2],
                            Qsn3 = args[3],
                            Qsn4 = args[4],
                            Qsn5 = args[5],
                            Qsn6 = args[6],
                            Qsn7 = args[7],
                            Qsn8 = args[8],
                            Qsn9 = args[9],
                            Qsn10 = args[10],
                            Qsn11 = args[11],
                            Qsn12 = args[12],
                            Qsn13 = args[13],
                            Qsn14 = args[14],
                            Date1 = args[15],
                            Status = args[16]

                        };
                        int a = db.Insert(abc);
                        if (a == 1)
                        {
                            status = 100;//saved data
                        }
                        else
                        {
                            status = 200;// error while saving data
                        }
                    }
                    else
                    {
                        status = ex;
                    }
                }
                else
                {
                    status = 0;
                }
            }
            catch (Exception ex)
            {
                status = 201;
                Log.Error("Savedata", "Error " + ex.Message);
            }
            return status;
        }
    }
}