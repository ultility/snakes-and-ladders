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
using Android.Graphics;

namespace snakes_and_ladders
{
    public enum Colors
    {
        RED,
        BLUE,
        GREEN,
        PURPLE,
        AMOUNT
    }
    class Player
    {
        public int x { get; set; }
        public int y { get; set; }

        public Player()
        {
            x = 0;
            y = 0;
        }
    }
}