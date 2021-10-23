using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace snakes_and_ladders
{
    public class Board : View
    {
        Player[] players;
        Bitmap[] bitmaps;
        Tunnel[] tunnels;
        Random rng;
        int turn;
        public Board(Context context, int NumberOfPlayers) : base(context)
        {
            rng = new Random();
            players = new Player[NumberOfPlayers];
            turn = 0;
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Player();
            }
            bitmaps = new Bitmap[(int)Colors.AMOUNT];
            bitmaps[0] = BitmapFactory.DecodeResource(Resources, Resource.Drawable.red);
            bitmaps[1] = BitmapFactory.DecodeResource(Resources, Resource.Drawable.blue);
            bitmaps[2] = BitmapFactory.DecodeResource(Resources, Resource.Drawable.green);
            bitmaps[3] = BitmapFactory.DecodeResource(Resources, Resource.Drawable.purple);
            tunnels = new Tunnel[14];
            tunnels[0] = new Tunnel(3, 0, 4, 1);
            tunnels[1] = new Tunnel(5, 3, 5, 0);
            tunnels[2] = new Tunnel(7, 0, 9, 2);
            tunnels[3] = new Tunnel(1, 3, 9, 0);
            tunnels[4] = new Tunnel(1, 6, 7, 1);
            tunnels[5] = new Tunnel(0, 2, 1, 4);
            tunnels[6] = new Tunnel(7, 8, 3, 2);
            tunnels[7] = new Tunnel(7, 4, 5, 2);
            tunnels[8] = new Tunnel(7, 2, 5, 7);
            tunnels[9] = new Tunnel(9, 4, 6, 6);
            tunnels[10] = new Tunnel(4, 9, 5, 5);
            tunnels[11] = new Tunnel(0, 7, 1, 9);
            tunnels[12] = new Tunnel(6, 9, 7, 7);
            tunnels[13] = new Tunnel(9, 7, 8, 9);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            int tile_width = canvas.Width / 10;
            int tile_height = canvas.Height / 10;
            Rect dst = new Rect();
            Rect src = new Rect(0, 0, bitmaps[0].GetScaledWidth(canvas), bitmaps[0].GetScaledHeight(canvas));
            for (int i = 0; i < players.Length; i++)
            {
                dst.Bottom = (10 - players[i].y) * tile_height - ((i / 2 + 1) % 2 * tile_height / 2);
                dst.Top = dst.Bottom - tile_height / 2;
                int x = players[i].x;
                if (players[i].y % 2 == 1)
                {
                    x = 9 - x;
                }
                dst.Left = (x * tile_width) + (i % 2 * tile_width / 2);
                dst.Right = dst.Left + tile_width / 2;
                canvas.DrawBitmap(bitmaps[i], src, dst, null);
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Up)
            {
                AlertDialog d = null;
                int x = players[turn].x + rng.Next(6) + 1;
                int y = players[turn].y + x / 10;
                x %= 10;
                if (y > 9)
                {
                    x = 9;
                    y = 9;
                    AlertDialog.Builder b = new AlertDialog.Builder(Context);
                    string winner = "";
                    switch (turn)
                    {
                        case 0:
                            winner = "Red";
                            break;
                        case 1:
                            winner = "Blue";
                            break;
                        case 2:
                            winner = "Green";
                            break;
                        case 3:
                            winner = "Purple";
                            break;
                    }
                    b.SetMessage("Congrats " + winner);
                    b.SetPositiveButton("Ok", ok);
                    d = b.Create();
                }

                for (int i = 0; i < tunnels.Length; i++)
                {
                    if (x == tunnels[i].start_x && y == tunnels[i].start_y)
                    {
                        x = tunnels[i].end_x;
                        y = tunnels[i].end_y;
                        break;
                    }
                }
                players[turn].x = x;
                players[turn].y = y;
                if (d == null)
                {
                    turn = (turn + 1) % players.Length;
                }
                else
                {
                    d.Show();
                }
                Invalidate();

            }
            return true;
        }
        private void ok(Object sender, EventArgs e)
        {
            Intent i = new Intent(Context, typeof(MainActivity));
            i.PutExtra("winner", turn);
            ((Activity1)Context).StartActivity(i);
        }
    }
}