namespace DLA_2023
{
    internal class Program
    {
        static void Main()
        {
            string[] field_sizes = Console.ReadLine().Split('x');
            Cell[,] field = new Cell[int.Parse(field_sizes[0]), int.Parse(field_sizes[1])];
            double porosity = double.Parse(Console.ReadLine());
            double currentPorosity = 100;


            while (currentPorosity > porosity)
            {
                field = Logic.MainCycle(field, out currentPorosity);
                Draw(field);
                Console.WriteLine($"\n{currentPorosity}");
            }
            
        }

        internal static void Draw(Cell[,] field)
        {
            Thread.Sleep(750);
            Console.Clear();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    switch (field[i, j].State)
                    {
                        case '*':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;

                        case '"':
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                    }
                    Console.Write(field[i, j].State);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}