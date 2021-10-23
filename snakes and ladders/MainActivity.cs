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
        int player_number;

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
            player_number = 2;
            two.Click += Two_Click;
            three.Click += Three_Click;
            four.Click += four_Click;
            start.Click += Start_Click;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Activity1));
            i.PutExtra("players", player_number);
            StartActivity(i);
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