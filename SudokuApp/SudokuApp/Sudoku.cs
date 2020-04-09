﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class Sudoku
    {

        public int[,] PlayerBoard(int[,] board)
        {
            int[,] newBoard = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i,j]==0) 
                    {
                        newBoard[i, j] = -1;
                    }
                    
                }
            }
            

            return newBoard;
        }

        public int[,] BoardForPrint(int[,] board)
        {
            int[,] newBoard = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    newBoard[i, j] = board[i, j];
                }
            }
            int nMin = 4;
            int nMax = 6;
            int[] code = new int[] { 0, 3, 6 };
            for (int i = 0; i < code.Length; i++)
            {
                for (int j = 0; j < code.Length; j++)
                {
                    Random rng = new Random();
                    //code[i],code[j]
                    int n = rng.Next(nMin, nMax);
                    newBoard = RemoveElementsFromSquare(newBoard, code[i], code[j], n);
                }
            }

            return newBoard;
        }

        public int[,] RemoveElementsFromSquare(int[,] board, int x, int y, int n) 
        {
            int[,] newBoard = new int[9, 9];
            newBoard = board;
            int i = 0;
            while(i < n)
            {
                Random rng = new Random();
                int numX = rng.Next(x, x + 3);
                int numY = rng.Next(y, y + 3);
                if(newBoard[numX,numY] != 0)
                {
                    newBoard[numX, numY] = 0;
                    i++;
                }
            }



            return newBoard;
        }

        
            
        public int[,] NewBoard()
        {
            int[,] board = new int[9, 9];
            int[] row = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] code = new int[] { 0, 3, 6, 1, 4, 7, 2, 5, 8 };
            row = Shuffle(row);
            
            for (int i = 0; i < 9; i++)
            {
                int[] newRow = MoveLeft(row, code[i]);
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = newRow[j];
                }
            }

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
