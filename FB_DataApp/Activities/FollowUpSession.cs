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
using FB_DataApp.Database.Crud;
using FB_DataApp.Database.Tables;

namespace FB_DataApp.Activities
{
    [Activity(Label = "FollowUpSession")]
    public class FollowUpSession : AppCompatActivity
    {
       
        private String slocation, qsn1, qsn2, qsn3, qsn4, qsn5, qsn6, qsn7, qsn8, qsn9, qsn10, qsn11, qsn12, qsn13, qsn14;
        String lhwid = "",f_up="";
    
        int status = 0,stat=0;
        Select select = new Select();
        static string[] COUNTRIES;
        EditText id, dob, dos, number,gender;
        AutoCompleteTextView cname;
        RadioGroup radioGroup;
        Button abc;
        public FollowUpSession()
        {
            //f_up = Intent.GetStringExtra("arg");
            //EditText id = FindViewById<EditText>(Resource.Id.account3);
            //id.Text = f_up;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.FollowUpSession);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Data-Collect: Follow-Up Session";
            COUNTRIES = LoadNames();
            //click save
             abc = FindViewById<Button>(Resource.Id.button1);
            abc.Click += Abc_Click;
          
            //gender
            //RadioGroup radioGroup = FindViewById<RadioGroup>(Resource.Id.rbtngender);
            //radioGroup.CheckedChange += delegate {
            //    var option = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId).Text;
            //    gender = option;
            //};
            //location
            RadioGroup loc = FindViewById<RadioGroup>(Resource.Id.radioGroup2);
            loc.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(loc.CheckedRadioButtonId).Text;
                slocation = option;
            };
            //ssq1
            RadioGroup answer1 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn1);
            answer1.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer1.CheckedRadioButtonId).Text;
                qsn1 = option;
            };
            //ssq2

            RadioGroup answer2 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn2);
            answer2.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer2.CheckedRadioButtonId).Text;
                qsn2 = option;
            };
            //ssq3
            RadioGroup answer3 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn3);
            answer3.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer3.CheckedRadioButtonId).Text;
                qsn3 = option;
            };
            //ssq4
            RadioGroup answer4 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn4);
            answer4.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer4.CheckedRadioButtonId).Text;
                qsn4 = option;
            };
            //ssq5
            RadioGroup answer5 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn5);
            answer5.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer5.CheckedRadioButtonId).Text;
                qsn5 = option;
            };
            //ssq6
            RadioGroup answer6 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn6);
            answer6.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer6.CheckedRadioButtonId).Text;
                qsn6 = option;
            };
            //ssq7
            RadioGroup answer7 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn7);
            answer7.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer7.CheckedRadioButtonId).Text;
                qsn7 = option;
            };
            //ssq8
            RadioGroup answer8 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn8);
            answer8.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer8.CheckedRadioButtonId).Text;
                qsn8 = option;
            };
            //ssq9
            RadioGroup answer9 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn9);
            answer9.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer9.CheckedRadioButtonId).Text;
                qsn9 = option;
            };
            //ssq10
            RadioGroup answer10 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn1);
            answer10.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer10.CheckedRadioButtonId).Text;
                qsn10 = option;
            };
            //ssq11
            RadioGroup answer11 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn1);
            answer11.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer11.CheckedRadioButtonId).Text;
                qsn11 = option;
            };
            //ssq12
            RadioGroup answer12 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn12);
            answer12.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer12.CheckedRadioButtonId).Text;
                qsn12 = option;
            };
            //ssq13
            RadioGroup answer13 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn13);
            answer13.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer13.CheckedRadioButtonId).Text;
                qsn13 = option;
            };
            //ssq14
            RadioGroup answer14 = FindViewById<RadioGroup>(Resource.Id.rbtnqsn14);
            answer14.CheckedChange += delegate {
                var option = FindViewById<RadioButton>(answer14.CheckedRadioButtonId).Text;
                qsn14 = option;
            };
            id = FindViewById<EditText>(Resource.Id.account3);
            cname = FindViewById<AutoCompleteTextView>(Resource.Id.name);
            dob = FindViewById<EditText>(Resource.Id.dob);
            dos = FindViewById<EditText>(Resource.Id.dos);
            number = FindViewById<EditText>(Resource.Id.number);
            gender = FindViewById<EditText>(Resource.Id.gender);
            //clinic and lhw id 

            EditText cl = FindViewById<EditText>(Resource.Id.account1);
            cl.Text = Helpers.Settings.ClinicId;
            EditText lh = FindViewById<EditText>(Resource.Id.account2);
            lh.Text = Helpers.Settings.LHWID;
            // search
            //id
         
            //name 
             
            AutoCompleteTextView textView = cname;
            var adapter = new ArrayAdapter<String>(this, Resource.Layout.list_item, COUNTRIES);
            textView.Adapter = adapter;
            
            textView.TextChanged += TextView_TextChanged;
       
            //id.TextChanged += Id_TextChanged;
        }

        private void TextView_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            int ses = select.MySessions(id.Text, "ClientID") + 1;
            List<Client> clients = select.MyClient1(cname.Text.Trim(), "Name");
            //Toast.MakeText(this, "count " + clients.Count, ToastLength.Short).Show();
            if(clients.Count==1)
            {
                number.Text = ses.ToString();
                id.Text = clients[0].ClientID;
                dob.Text = clients[0].Dob;
                gender.Text = clients[0].Gender;
                abc.Enabled = true;
            }
            else
            {
                id.Text = "";
                dob.Text ="";
                number.Text ="";
                gender.Text = "";
                abc.Enabled = false;
            }
        }

        private void Cname_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {

           

        }

        private void Id_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            int ses = select.MySessions(id.Text, "ClientID")+1;
            List<Client> clients = select.MyClient(id.Text, "Id");
           if(clients.Count==1 && cname.Text=="")
            {
                number.Text = ses.ToString();
               
                    cname.Text = clients[0].Name;
                    dob.Text = clients[0].Dob;
                abc.Enabled = true;
            }
            else
            {
                number.Text = "0";
                cname.Text = "";
                dob.Text = "";
                abc.Enabled = true;
            }
        }

        private void Abc_Click(object sender, EventArgs e)
        {
            try
            {
                 id = FindViewById<EditText>(Resource.Id.account3);
                 cname = FindViewById<AutoCompleteTextView>(Resource.Id.name);
                 dob = FindViewById<EditText>(Resource.Id.dob);
                 dos = FindViewById<EditText>(Resource.Id.dos);
                 gender = FindViewById<EditText>(Resource.Id.gender);
                 number = FindViewById<EditText>(Resource.Id.number);
                if (id.Text == "")
                {
                    Toast.MakeText(this, "Enter client id", ToastLength.Short).Show();
                }
                else if (cname.Text == "")
                {
                    Toast.MakeText(this, "Enter client name", ToastLength.Short).Show();
                }
                else if (gender.Text == "")
                {
                    Toast.MakeText(this, "select client gender", ToastLength.Short).Show();
                }
                else if (dob.Text == "")
                {
                    Toast.MakeText(this, "Enter date of birth of client", ToastLength.Short).Show();
                }
                else if (dos.Text == "")
                {
                    Toast.MakeText(this, "Enter date when the session was done", ToastLength.Short).Show();
                }
                else if (number.Text == "")
                {
                    Toast.MakeText(this, "Enter session number", ToastLength.Short).Show();
                }
                else if (qsn1 == "")
                {
                    Toast.MakeText(this, "Select answer for question 1", ToastLength.Short).Show();
                }
                else if (qsn2 == "")
                {
                    Toast.MakeText(this, "Select answer for question 2", ToastLength.Short).Show();
                }
                else if (qsn3 == "")
                {
                    Toast.MakeText(this, "Select answer for question 3", ToastLength.Short).Show();
                }
                else if (qsn4 == "")
                {
                    Toast.MakeText(this, "Select answer for question 4", ToastLength.Short).Show();
                }
                else if (qsn5 == "")
                {
                    Toast.MakeText(this, "Select answer for question 5", ToastLength.Short).Show();
                }
                else if (qsn6 == "")
                {
                    Toast.MakeText(this, "Select answer for question 6", ToastLength.Short).Show();
                }
                else if (qsn7 == "")
                {
                    Toast.MakeText(this, "Select answer for question 7", ToastLength.Short).Show();
                }
                else if (qsn8 == "")
                {
                    Toast.MakeText(this, "Select answer for question 8", ToastLength.Short).Show();
                }
                else if (qsn9 == "")
                {
                    Toast.MakeText(this, "Select answer for question 9", ToastLength.Short).Show();
                }
                else if (qsn10 == "")
                {
                    Toast.MakeText(this, "Select answer for question 10", ToastLength.Short).Show();
                }
                else if (qsn11 == "")
                {
                    Toast.MakeText(this, "Select answer for question 11", ToastLength.Short).Show();
                }
                else if (qsn12 == "")
                {
                    Toast.MakeText(this, "Select answer for question 12", ToastLength.Short).Show();
                }
                else if (qsn13 == "")
                {
                    Toast.MakeText(this, "Select answer for question 13", ToastLength.Short).Show();
                }
                else if (qsn14 == "")
                {
                    Toast.MakeText(this, "Select answer for question 14", ToastLength.Short).Show();
                }
                else
                {
                    String sid = DateTime.Now.ToShortDateString() + id.Text;
                    String date = DateTime.Now.ToShortTimeString();
                    string[] client = { id.Text, cname.Text, dob.Text, gender.Text, date, "0" };
                   
                    Insert abc = new Insert();
                    Select sel = new Select();
                    status = sel.CheckStatus("Session", id.Text, "ClientID")+1;
                    string[] session = { sid, number.Text, slocation, id.Text, lhwid, status.ToString()};
                    string[] clientsession = { sid, qsn1, qsn2, qsn3, qsn4, qsn5, qsn6, qsn7, qsn8, qsn9, qsn10, qsn11, qsn12, qsn13, qsn14, date, stat.ToString() };
                    int a = sel.CheckClient(client);
                    int b = abc.Session1(session), c = abc.ClientSession(clientsession);
                    if (a == 2 || a==3)
                    {
                        if (c == 100)
                        {
                            if(b == 100)
                            {
                                Toast.MakeText(this, "client data saved successfully ", ToastLength.Short).Show();
                            }
                                
                        }
                        else if (b == 200 || c == 200)
                        {
                            Toast.MakeText(this, "The information already exists for this session a "+a +" b "+b+" c "+c, ToastLength.Short).Show();
                            //rollback from here
                        }
                        else if (b == 0 || c == 0)
                        {
                            Toast.MakeText(this, "Database connection error", ToastLength.Short).Show();
                        }
                        else if (a== 100)
                        {
                            Toast.MakeText(this, "Client does not exist", ToastLength.Short).Show();
                        }
                        else
                        {
                            Toast.MakeText(this, "Unable to save data", ToastLength.Short).Show();
                            //rollback from here
                        }
                    }
                   
                    else if (a == 201 || a == 0)
                    {
                        Toast.MakeText(this, "Database error ", ToastLength.Short).Show();
                    }
                    else if (a == 1)
                    {
                        Toast.MakeText(this, "no client details in the database ", ToastLength.Short).Show();
                    }
                   
                    else
                    {
                        Toast.MakeText(this, "Unknown error "+a, ToastLength.Short).Show();
                    }
                    //Toast.MakeText(this, "c "+a+" s "+b+" cs "+c, ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Error-session1 " + ex.Message, ToastLength.Short).Show();
            }
        }
        string[] LoadNames()
        {
            
            List<Client> ab = select.MyClient1("0", "Status");
            string[] an;
            int i = 0;
            if(ab.Count>0)
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