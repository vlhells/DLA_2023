using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA_2023
{
    internal class Globule
    {
        private protected static Random random = new Random();
        private protected static int _x;
        private protected static int _y;
        private protected char _state = '"';

        internal static int X { get { return _x; } }
        internal static int Y { get { return _y; } }

        internal Globule(Cell[,] field)
        {
            do
            {
                _x = random.Next(0, field.GetLength(0));
                _y = random.Next(0, field.GetLength(1));
            }
            while (field[_x, _y].State == '*');

            field[_x, _y].State = _state;
        }
    }
}
