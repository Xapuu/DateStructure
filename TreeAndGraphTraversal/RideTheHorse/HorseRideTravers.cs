using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideTheHorse
{
    static class HorseRideTravers
    {
        //pattern
        private static readonly int[] Direction = { 1, 2, -1, 2, 1, -2, -1, -2, 2, 1, -2, 1, 2, -1, -2, -1 };

        private static bool IsCellUsable(int[,] matrix, Cell cell)
        {
            bool isCellUsable = cell.X >= 0 && cell.X < matrix.GetLength(0) && cell.Y >= 0
                            && cell.Y < matrix.GetLength(1) && matrix[cell.X, cell.Y] == 0;

            return isCellUsable;
        }

        private static bool IsNextCellUsable(int[,] matrix, Cell cell, int index)
        {
            var nextCell = new Cell()
            {
                X = cell.X + Direction[index],
                Y = cell.Y + Direction[index + 1]
            };

            return IsCellUsable(matrix, nextCell);
        }

        public static int[,] TraverseTheMatrix(int[,] matrix, Cell startingCell)
        {
            var queue = new Queue<Cell>();
            queue.Enqueue(startingCell);

            while (queue.Any())
            {
                var cell = queue.Dequeue();
                matrix[cell.X, cell.Y] = cell.Value;

                for (int index = 0; index < Direction.Length; index += 2)
                {
                    if (IsNextCellUsable(matrix,cell,index))
                    {
                        queue.Enqueue(new Cell
                            (
                            cell.X + Direction[index],
                            cell.Y + Direction[index + 1],
                            cell.Value + 1
                            ));
                    }
                }
            }
            return matrix;
        }
    }
}
