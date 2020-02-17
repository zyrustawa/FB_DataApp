using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using FB_DataApp.Adapter;
using FB_DataApp.Database.Crud;
using FB_DataApp.Database.Tables;

namespace FB_DataApp.Activities
{
    [Activity(Label = "CKTRegister")]
    public class CKTRegister : AppCompatActivity
    {
        String ClId = "";
        EditText cid, LHWid, pid,gender,dob,da;
        ListView mylist;
        AutoCompleteTextView name;
        Select select = new Select();
        static string[] COUNTRIES;
        UserData abc = new UserData();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CKTRegister);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Data-Collect: Circle Kubatana Tose";
            name = FindViewById<AutoCompleteTextView>(Resource.Id.name);
            cid = FindViewById<EditText>(Resource.Id.account1);
            da = FindViewById<EditText>(Resource.Id.Date2);
            cid.Text = Helpers.Settings.ClinicId;
             LHWid = FindViewById<EditText>(Resource.Id.account2);
            LHWid.Text = Helpers.Settings.LHWID;
             pid = FindViewById<EditText>(Resource.Id.account3);
            gender = FindViewById<EditText>(Resource.Id.gender);
            dob = FindViewById<EditText>(Resource.Id.Date1);
            
            mylist = FindViewById<ListView>(Resource.Id.listView1);
            mylist.Adapter = new MyCustomListAdapter(abc.Users);
            mylist.ItemClick += Mylist_ItemClick;
            
          //  Toast.MakeText(this, "count " + new Select().AllClients(), ToastLength.Long).Show();

            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;

            cid.TextChanged += Cid_TextChanged;
            pid.TextChanged += Pid_TextChanged;
            name.TextChanged += Name_TextChanged;
            COUNTRIES = LoadNames();
            AutoCompleteTextView textView = name;
            var adapter = new ArrayAdapter<String>(this, Resource.Layout.list_item, COUNTRIES);
            textView.Adapter = adapter;

            name.TextChanged += Name_TextChanged;

            da.Text = DateTime.Today.ToShortDateString();
        }


        private void Mylist_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            name.Text = "";
            pid.Text = "";
            gender.Text = "";
            dob.Text = "";
            ClId = abc.Users[e.Position].ToString();

            List<Client> clients = new List<Client>();

            Select select = new Select();
            clients = select.MyClient(ClId, "Id");
            if (clients.Count == 1)
            {
                name.Text = clients[0].Name;
                pid.Text = clients[0].ClientID;
                gender.Text = clients[0].Gender;
                dob.Text = clients[0].Dob;
            }
        }
        

        private void Name_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<Client> clients = new List<Client>();

            Select select = new Select();
            clients = select.MyClient(name.Text, "Name");
            if(clients.Count==1)
            {
                pid.Text = clients[0].ClientID;
                gender.Text = clients[0].Gender;
                dob.Text= clients[0].Dob;

            }
            else
            {
                pid.Text = "";
                gender.Text = "";
                dob.Text = "";
            }

        }

        private void Pid_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<Client> client = new List<Client>();

            Select select = new Select();
           client= select.MyClient(pid.Text, "ClientID");
          
              //  Toast.MakeText(this, "client id "+client.Count, ToastLength.Long).Show();
           
           
        }

        private void Cid_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
             dob = FindViewById<EditText>(Resource.Id.Date1);
             da = FindViewById<EditText>(Resource.Id.Date2);
            try
            {
                if(int.Parse(cid.Text)<0 || int.Parse(cid.Text) > 36)
                {
                    Toast.MakeText(this, "Invalid Clinic Id ", ToastLength.Long).Show();
                }
                else if (int.Parse(LHWid.Text) < 0)
                {
                    Toast.MakeText(this, "Invalid Lay Health Worker Id ", ToastLength.Long).Show();
                }
               else if (int.Parse(pid.Text) < 0)
                {
                    Toast.MakeText(this, "Invalid Client Id ", ToastLength.Long).Show();
                }
                else if (name.Text=="")
                {
                    Toast.MakeText(this, "Invalid client name ", ToastLength.Long).Show();
                }
                else if (gender.Text=="")
                {
                    Toast.MakeText(this, "Select the gender ", ToastLength.Long).Show();
                }
                else if (dob.Text == "")
                {
                    Toast.MakeText(this, "Select the gender ", ToastLength.Long).Show();
                }
                else if (da.Text == "")
                {
                    Toast.MakeText(this, "Select the gender ", ToastLength.Long).Show();
                }
                else
                {
                    Select select = new Select();
                    Insert insert = new Insert();
                    string[] ckt = { cid.Text + "-" + LHWid.Text + "-" + pid.Text, da.Text, "Community", "1" };
                    int isa = insert.CktRegister(ckt);
                    int check = select.CheckCKT(ckt);
                    if(isa.Equals(100))
                    {
                        Toast.MakeText(this, "CKT data saved", ToastLength.Long).Show();
                    }
                    else if(isa.Equals(200) || check.Equals(200))
                    {
                        Toast.MakeText(this, "Data already exits for this person", ToastLength.Long).Show();
                    }
                    else if (isa.Equals(0))
                    {
                        Toast.MakeText(this, "Invalid method arguments", ToastLength.Long).Show();
                    }
                    else if (check.Equals(0) || isa.Equals(201))
                    {
                        Toast.MakeText(this, "Database Error", ToastLength.Long).Show();
                    }

                    else
                    {
                        Toast.MakeText(this, "Uknown error "+isa, ToastLength.Long).Show();
                    }
                }
            }
            catch(Exception ex)
            {
                Toast.MakeText(this, "Error " + ex.Message, ToastLength.Long).Show();
            }
        }
        string[] LoadNames()
        {

            List<Client> ab = select.MyClient1("0", "Status");
            string[] an;
            int i = 0;
            if (ab.Count > 0)
            {
                an = new string[ab.Count];
                foreach (Client c in ab)
                {
                    an[i] = c.Name;
                    i++;
                }
            }
            else
            {
                an = new string[1];
                an[0] = "";
            }
            return an;
        }
    }
}