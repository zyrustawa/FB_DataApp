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
    class MyCustomListAdapter : BaseAdapter<User>

    {
        List<User> users;
        public MyCustomListAdapter(List<User> users)
        {
            this.users = users;
        }
        public override User this[int position]
            {
            get
            {
                return users[position];
            }
            }
        public override int Count
        {
            get
            {
                return users.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
   // public override User this[int position] => throw new NotImplementedException();

       // public override int Count => throw new NotImplementedException();

      

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if(view==null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.userRow, parent, false);
                var row = view.FindViewById<TableRow>(Resource.Id.tableRow1);
                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var id = view.FindViewById<TextView>(Resource.Id.IdTextView);
                var ckt = view.FindViewById<TextView>(Resource.Id.CKTTextView);
                 view.Tag = new ViewHolder() {Row=row,Name=name,CKT=ckt,ID= id};
            }
            var holder = (ViewHolder)view.Tag;
           // holder.Photo.SetImageDrawable(ImageManager.Get(parent.Context, users[position].ImageUrl));
           
            holder.Name.Text = users[position].Name;
            holder.ID.Text = users[position].ID;
            holder.CKT.Text = users[position].Ckt;
        
            
            return view;
        }
    }
}