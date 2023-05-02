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
        static List<Globule> globules = new List<Globule>(); // Список появляющихся подвижных частиц.
        static int _substanceCells = 0;

        internal static Cell[,] MainCycle(Cell[,] field, out double currentPorosity)
        {
            if (_iteration == 0)
            {
                FillField(field);
                _nullCenter = new Cluster(field);
                _substanceCells++;
            }
            if (_iteration > 0)
            {
                globules.Add(new Globule(field));

                for (int i = 0; i < globules.Count; i++)
                {
                    if (globules[i].CheckBoundary(field))
                    {
                        globules.RemoveAt(i);
                        _substanceCells++;
                    }
                    else
                    {
                        globules[i].Move(field);
                    }
                }
            }

            currentPorosity = PorosityCalculate(field);
            _iteration++;
            return field;
        }

        private static double PorosityCalculate(Cell[,] field)
        {
            return (field.Length - 1.0 * _substanceCells) / field.Length;
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
