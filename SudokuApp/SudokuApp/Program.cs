﻿using System;

namespace SudokuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Sudoku sudoku = new Sudoku();
            int[,] board = sudoku.NewBoard();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i,j]);
                }
                Console.WriteLine();
            }



            Console.WriteLine("Hello World!");

        }
    }
}
