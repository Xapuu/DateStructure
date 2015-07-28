using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideTheHorse
{
    class RideTheHorseTest
    {
        private static void Main(string[] args)
        {
            int[,] matrix = GetMatrixInput();
            var startingCell = GetCellPosition();
            matrix = HorseRideTravers.TraverseTheMatrix(matrix, startingCell);
            PrintWholeMatrix(matrix);
            Console.WriteLine(Environment.NewLine);
            PrintMatrixMiddleRow(matrix);
        }

        static void PrintWholeMatrix(int[,] matrix)
        {
            for (int row = 0; row <= matrix.GetUpperBound(0); row++)
            {
                for (int col = 0; col < matrix.GetUpperBound(1); col++)
                {
                    Console.Write("|{0,2}|", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void PrintMatrixMiddleRow(int[,] matrix)
        {
            int middleCol = matrix.GetLength(1) / 2;
            Console.WriteLine("Middle col:");
            for (int row = 0; row <= matrix.GetUpperBound(0); row++)
            {
                Console.WriteLine(matrix[row, middleCol]);
            }
        }

        static int[,] GetMatrixInput()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            return new int[rows, cols];
        }

        static Cell GetCellPosition()
        {
            int startRow = int.Parse(Console.ReadLine());
            int startCol = int.Parse(Console.ReadLine());

            Cell cell = new Cell(startRow, startCol);
            return cell;
        }

    }
}
