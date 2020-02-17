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
using Java.Lang;

namespace FB_DataApp.Adapter
{
   public  class ViewHolder : Java.Lang.Object
    { 
       public TableRow Row { get; set; }
        public TextView Name { get; set; }
        public TextView ID { get; set; }
        public TextView CKT { get; set; }

       
    }
}