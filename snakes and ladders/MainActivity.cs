using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace snakes_and_ladders
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button two;
        Button three;
        Button four;
        Button start;
        LinearLayout ll1;
        LinearLayout ll2;
        LinearLayout ll3;
        LinearLayout ll4;
        TextView tv1;
        TextView tv2;
        TextView tv3;
        TextView tv4;
        int player_number;
        public static int red;
        public static int blue;
        public static int green;
        public static int purple;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            two = FindViewById<Button>(Resource.Id.two);
            three = FindViewById<Button>(Resource.Id.three);
            four = FindViewById<Button>(Resource.Id.four);
            start = FindViewById<Button>(Resource.Id.start);
            ll1 = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            ll2 = FindViewById<LinearLayout>(Resource.Id.linearLayout2);
            ll3 = FindViewById<LinearLayout>(Resource.Id.linearLayout3);
            ll4 = FindViewById<LinearLayout>(Resource.Id.linearLayout4);
            tv1 = FindViewById<TextView>(Resource.Id.red);
            tv2 = FindViewById<TextView>(Resource.Id.blue);
            tv3 = FindViewById<TextView>(Resource.Id.green);
            tv4 = FindViewById<TextView>(Resource.Id.purple);
            player_number = 2;
            two.Click += Two_Click;
            three.Click += Three_Click;
            four.Click += four_Click;
            start.Click += Start_Click;
            red = 0;
            blue = 0;
            green = 0;
            purple = 0;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Activity1));
            i.PutExtra("players", player_number);
            StartActivityForResult(i, 0);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 0)
            {
                ll1.Visibility = ll2.Visibility = ll3.Visibility = ll4.Visibility = Android.Views.ViewStates.Visible;
                tv1.Text = "" + red;
                tv2.Text = "" + blue;
                tv3.Text = "" + green;
                tv4.Text = "" + purple;
            }
        }

        private void four_Click(object sender, EventArgs e)
        {
            player_number = 4;
        }

        private void Three_Click(object sender, EventArgs e)
        {
            player_number = 3;
        }

        private void Two_Click(object sender, System.EventArgs e)
        {
            player_number = 2;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}