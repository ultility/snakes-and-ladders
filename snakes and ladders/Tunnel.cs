using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snakes_and_ladders
{
    public class Tunnel
    {
        public Tunnel(int start_x, int start_y, int end_x, int end_y)
        {
            this.start_x = start_x;
            this.start_y = start_y;
            this.end_x = end_x;
            this.end_y = end_y;
        }

        public int start_x { get; }
        public int start_y { get; }
        public int end_x { get; }
        public int end_y { get; }
        
    }
}