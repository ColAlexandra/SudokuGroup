using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class Sudoku
    {
        public int[,] newBoard()
        {
            int[,] board = new int[9, 9];
            int[] row = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            row = Shuffle(row);
            return board;
        }

        public int[] Shuffle(int[] array)
        {
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                int temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
            return array;
        }

        public int[] MoveLeft(int[] a, int d)
        {
            int n = a.Length;
            int[] finalA = new int[9];
            for (int i = 0; i < n - d; i++)
            {
                finalA[i] = a[i + d];
            }

            for (int i = 0; i < d; i++)
            {
                finalA[i + n - d] = a[i];
            }
            return finalA;
        }
    }
}
