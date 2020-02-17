using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FB_DataApp.Adapter
{
   public static class ImageManager
    {
        static Dictionary<string, Drawable> cache = new Dictionary<string, Drawable>();

        public static Drawable Get(Context context, string url)
        {
            try
            {
                if (!cache.ContainsKey(url))
                {
                    var drawable = Drawable.CreateFromStream(context.Assets.Open(url), null);

                    cache.Add(url, drawable);
                }

                return cache[url];
            }
            catch(Exception ex)
            {
                //Toast.MakeText(this, "Error " + ex.Message, ToastLength.Short).Show();
                Log.Error("Image Manager", "Error " + ex.Message);
                return null;
            }
        }
    }
}