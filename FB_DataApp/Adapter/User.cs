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

namespace FB_DataApp.Adapter
{
   public class User
    {
        public int ClId { get; set; }
        public string Name { get; set; }
       
        public string ID { get; set; }
        public string Ckt { get; set; }
        public override string ToString()
        {
            return ClId.ToString();  
        }
    }
}