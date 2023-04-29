using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA_2023
{
    internal class Particle
    {
        private protected static Random random = new Random();
        private protected static int _x;
        private protected static int _y;
        private protected char _state = '*';

        internal static int X { get { return _x; } }
        internal static int Y { get { return _y; } }

        internal char State { get { return _state; } set { _state = value; } }


        internal Particle(Cell[,] field)
        {
            do
            {
                _x = random.Next(0, field.GetLength(0));
                _y = random.Next(0, field.GetLength(1));
            }
            while (field[_x, _y].State == '*' || field[_x, _y].State == '"');

            field[_x, _y].State = _state;
        }

        internal void Move(Cell[,] field)
        {
            field[_x, _y].State = '.';

            (int x, int y) coords;

            do
            {
                coords = GenerateNewCoords(field);
            }
            while (coords.x < 0 || coords.x >= field.GetLength(0) || coords.y < 0 || coords.y >= field.GetLength(1) || field[coords.x, coords.y].State == '*');

            _x = coords.x;
            _y = coords.y;

            field[_x, _y].State = _state;
        }

        private (int, int) GenerateNewCoords(Cell[,] field)
        {
            int x = _x;
            int y = _y;

            int direction = random.Next(0, 4);
            switch (direction)
            {
                case 0:
                    x += 1;
                    break;

                case 1:
                    y += 1;
                    break;

                case 2:
                    x -= 1;
                    break;

                case 3:
                    y -= 1;
                    break;
            }

            return (x, y);

        }

        internal bool CheckBoundary(Cell[,] field)
        {
            for (int i = Particle._x - 1; i <= Particle._x + 1; i++)
            {
                for (int j = Particle._y - 1; j <= Particle._y + 1; j++)
                {
                    //if (i == Particle._x && j == Particle._y)
                    //    continue;

                    if (i >= 0 && j >= 0 && i < field.GetLength(0) && j < field.GetLength(1) && field[i, j].State == '"')
                    {
                        field[Particle._x, Particle._y].State = field[i, j].State;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
