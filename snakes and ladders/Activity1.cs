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

namespace snakes_and_ladders
{
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        Board b;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.board);
            b = new Board(this, Intent.GetIntExtra("players", 2));
            FindViewById<FrameLayout>(Resource.Id.frame).AddView(b);
        }
    }
}