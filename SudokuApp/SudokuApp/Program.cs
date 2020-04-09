using System;

namespace SudokuApp
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Sudoku sudoku = new Sudoku();
            int[,] board = sudoku.NewBoard();
            int[,] boardForPrint = sudoku.BoardForPrint(board);
            int[,] playerBoard = sudoku.PlayerBoard(boardForPrint);

            sudoku.PrintBoard(board, boardForPrint, playerBoard);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i,j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(boardForPrint[i, j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(playerBoard[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Hello World!");

        }
    }
}
