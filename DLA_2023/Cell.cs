using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA_2023
{
    internal class Cell
    {
        //    static Random random = new Random();
        //    private static int _x;
        //    private static int _y;
        private char _state = '.';

        //internal static int X { get { return _x; } }
        //internal static int Y { get { return _y; } }

        internal char State { get { return _state; } set { _state = value; } }

        internal Cell()
        {

        }
    }
}
