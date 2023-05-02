using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLA_2023
{
    internal class Cell
    {
        private char _state = '.';

        internal char State { get { return _state; } set { _state = value; } }

        internal Cell()
        {

        }
    }
}
