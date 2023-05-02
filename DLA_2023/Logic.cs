using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace DLA_2023
{
    internal class Logic
    {
        static int _iteration = 0;
        static Random random = new Random();
        static Cluster _nullCenter; // Нулевой центр кластеризации.
        static List<Globule> globules = new List<Globule>(); 

        internal static Cell[,] MainCycle(Cell[,] field)
        {
            if (_iteration == 0)
            {
                FillField(field);
                _nullCenter = new Cluster(field);
                //globules.Add(new Globule(field));
            }
            if (_iteration > 0)
            {
                globules.Add(new Globule(field));

                for (int i = 0; i < globules.Count; i++)
                {
                    if (globules[i].CheckBoundary(field))
                        globules.RemoveAt(i);
                    else
                    {
                        globules[i].Move(field);
                    }

                }
            }

            _iteration++;
            return field;
        }

        private static void FillField(Cell[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = new Cell();
                }
            }
        }
    }
}
