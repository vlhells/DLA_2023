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
        static Globule _nullGlobule; // Нулевой центр кластеризации.
        static List<Particle> particles = new List<Particle>(); 

        internal static Cell[,] MainCycle(Cell[,] field)
        {
            if (_iteration == 0)
            {
                FillField(field);
                _nullGlobule = new Globule(field);
                //particles.Add(new Particle(field));
            }
            if (_iteration > 0)
            {
                particles.Add(new Particle(field));
                for (int i = 0; i < particles.Count; i++)
                {
                    if (particles[i].CheckBoundary(field))
                        particles.RemoveAt(i);
                    else
                    {
                        particles[i].Move(field);
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
