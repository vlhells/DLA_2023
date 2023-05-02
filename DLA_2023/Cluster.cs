using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA_2023
{
    internal class Cluster
    {
        private static Random random = new Random();
        private static int _x;
        private static int _y;
        private char _state = '"';

        internal Cluster(Cell[,] field)
        {
            do
            {
                _x = random.Next(0, field.GetLength(0));
                _y = random.Next(0, field.GetLength(1));
            }
            while (field[_x, _y].State != '.');

            field[_x, _y].State = _state;
        }
    }
}
