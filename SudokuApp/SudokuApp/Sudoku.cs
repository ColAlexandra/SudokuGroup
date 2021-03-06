﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp
{
    class Sudoku
    {

        public int Score(int[,]board, int[,] board2)
        {
            int score = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i,j]==board2[i,j]) { score++; }
                }
            }

            return score;
        }
        
        public int[,] InputPlayer(int[,] board, int[,] boardForPrint, int[,] playerBoard)
        {
            begin:

            Console.WriteLine("Write Column (space) Row (Space) Number between 1 and 9(1 2 3)");
            string input;
            input = Console.ReadLine();
            string[] inputSplit = input.Split(" ");

            int col;
            int row;
            int num;

            try
            {
                bool resultRow = int.TryParse(inputSplit[0], out col);
                bool resultCol = int.TryParse(inputSplit[1], out row);
                bool resultNum = int.TryParse(inputSplit[2], out num);

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Type only numbers");
                goto begin;
            }

            row--;
            col--;
            
            if (!(num >= 1 && num <=9)) { goto begin; }
            if (playerBoard[row, col] != -1)
            {
                playerBoard[row, col] = num;
            }
            else
            {
                Console.WriteLine("index out of range");
                goto begin;
            }

            return playerBoard;
        }

        public void PrintBoard(int[,] board, int[,] boardForPrint, int[,] playerBoard)
        {
            Console.Clear();
            string sepCol = "   ";
            string sepLin = " | ";
            int lng = sepCol.Length * 9;
            FirstLine(sepCol);

            for (int i = 0; i < 9; i++)
            {
                if (i == 3 || i == 6)
                {
                    Console.WriteLine();
                    PrintLine(sepCol, lng);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                }

                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(i+1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ");
                
                for (int j = 0; j < 9; j++)
                {
                    if (j == 3 || j == 6)
                    {
                        Console.Write(sepLin);
                    }
                    else
                    {
                        Console.Write(sepCol);
                    }
                    Console.Write(" ");
                    PrintElement(i, j, board, boardForPrint, playerBoard);
                    Console.Write(" ");

                }


            }
            Console.WriteLine();

        }

        public void PrintElement(int x, int y, int[,] board, int[,] boardForPrint, int[,] playerBoard)
        {
            if (boardForPrint[x,y] > 0 && boardForPrint[x, y] <= 9) 
            {
                Console.Write(boardForPrint[x,y]);
            }
            else if(playerBoard[x,y] > 0 && playerBoard[x, y] <= 9)
            {
                if (playerBoard[x, y] == board[x, y]) 
                {                   
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(playerBoard[x,y]);
                    Console.ForegroundColor = ConsoleColor.White;                   
                }
                else
                {                   
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(playerBoard[x, y]);
                    Console.ForegroundColor = ConsoleColor.White;                    
                }
            }
            else
            {
                Console.Write(" ");
            }

        }


        public void PrintLine(string sepCol, int lng)
        {
            Console.Write(sepCol);
            for (int i = 0; i < lng; i++)
            {
                Console.Write("_ ");
            }
            Console.WriteLine();
        }

        public void FirstLine(string sepCol)
        {
            Console.Write(sepCol);

            for (int i = 0; i < 9; i++)
            {
                Console.Write(sepCol);
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(i+1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ");
            }
        }

        public int[,] PlayerBoard(int[,] board)
        {
            int[,] newBoard = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i,j]!=0) 
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

        public bool ResultOfAll(int[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!ResultOfOne(board, i, j))
                    {
                        return false;
                    }

                }
            }

            return true;
        }

        public bool ResultOfOne(int[,] board, int col, int row)
        {

            for (int i = 0; i < 9; i++)
            {
                if (i == col)
                {
                    continue;
                }

                if (board[col, row] == board[i, row])
                {
                    return false;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (i == row)
                {
                    continue;
                }
                if (board[col, row] == board[col, i])
                {
                    return false;
                }
            }

            int colMin;
            int colMax;
            int rowMin;
            int rowMax;

            if (col < 3)
            {
                colMin = 0;
                colMax = 2;
            }
            else if (col >= 3 && col < 6)
            {
                colMin = 3;
                colMax = 5;
            }
            else
            {
                colMin = 6;
                colMax = 8;
            }

            if (row < 3)
            {
                rowMin = 0;
                rowMax = 2;
            }
            else if (row >= 3 && row < 6)
            {
                rowMin = 3;
                rowMax = 5;
            }
            else
            {
                rowMin = 6;
                rowMax = 8;
            }

            for (int i = colMin; i < colMax; i++)
            {
                for (int j = rowMin; j < rowMax; j++)
                {
                    if (i == col && j == row)
                    {
                        continue;
                    }
                    if (board[col, row] == board[i, j])
                    {
                        return false;
                    }


                }
            }

            return true;

        }

        public bool CheckIfNumIsIn(int[,] board, int row, int col, int num)
        {

            for (int i = 0; i < 9; i++)
            {
                if (i == col)
                {
                    continue;
                }

                if (num == board[row, i])
                {
                    return false;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (i == row)
                {
                    continue;
                }
                if (num == board[i, col])
                {
                    return false;
                }
            }

            int colMin;
            int colMax;
            int rowMin;
            int rowMax;

            if (col < 3)
            {
                colMin = 0;
                colMax = 2;
            }
            else if (col >= 3 && col < 6)
            {
                colMin = 3;
                colMax = 5;
            }
            else
            {
                colMin = 6;
                colMax = 8;
            }

            if (row < 3)
            {
                rowMin = 0;
                rowMax = 2;
            }
            else if (row >= 3 && row < 6)
            {
                rowMin = 3;
                rowMax = 5;
            }
            else
            {
                rowMin = 6;
                rowMax = 8;
            }

            for (int i = colMin; i < colMax; i++)
            {
                for (int j = rowMin; j < rowMax; j++)
                {
                    if (i == col && j == row)
                    {
                        continue;
                    }
                    if (num == board[j, i])
                    {
                        return false;
                    }


                }
            }

            return true;

        }

        public int[,] CreateNewBoard2()
        {   
            
            allAgain:
            int[,] board = new int[9, 9];
            int x = 0;
            for (int i = 0; i < 9; i++)
            {
                again:

                for (int j = 0; j < 9; j++)
                {
                    int l = 0;
                    int[] numbers = new int[9];
                    for (int k = 1; k <= 9; k++)
                    {
                        
                        
                        if(CheckIfNumIsIn(board, i, j, k))
                        {
                            numbers[l] = k;
                            l++;
                            
                        }
                        Random random = new Random();
                        int rng = random.Next(0,l);
                        board[i, j] = numbers[rng];
                        
                    }
                    x++;
                    
                    if(x > 500) { goto allAgain; }
                    if (l == 0) { goto again; } 

                }

                

            }

            bool asd = ResultOfAll(board);
            
            if (asd)
            {
                return board;
            }
            else
            {
                goto allAgain;
            }
        }

    }
}
