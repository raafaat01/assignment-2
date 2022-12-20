﻿using System;
using System.Threading;

namespace TIC_TAC_TOE
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag = 0;

        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Tic-Tac-Toe!\n");
                Console.WriteLine("1. New game");
                Console.WriteLine("2. About the author");
                Console.WriteLine("3. Exit\n");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    NewGame();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("This game made by mohamed raafat for assignment 2.");
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Thank you for playing!");
                    break;
                }
            }
        }

        static void NewGame()
        {
            while (flag == 0)
            {
                Console.Clear();
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }
                Console.WriteLine("\n");
                Board();
                Console.WriteLine("Enter a number between 1 and 9 to make your move: ");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue;
                }
                if (choice < 1 || choice > 9)
                {
                    Console.WriteLine("Invalid move. Please choose a number between 1 and 9.");
                    continue;
                }
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }
                flag = CheckWin();
            }
            while (flag != 1 && flag != -1) ;
            Console.Clear();
            Board();
            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
                Console.Writeline("press any button to return to main menu"); 
            }
            else
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
            

        }

        static void Board()
            {
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
                Console.WriteLine("     |     |      ");
            }
             static int CheckWin()
            {
                #region Horzontal Winning Condtion
                if (arr[1] == arr[2] && arr[2] == arr[3])
                {
                    return 1;
                }
                else if (arr[4] == arr[5] && arr[5] == arr[6])
                {
                    return 1;
                }
                else if (arr[6] == arr[7] && arr[7] == arr[8])
                {
                    return 1;
                }
                #endregion
                #region vertical Winning Condtion
                else if (arr[1] == arr[4] && arr[4] == arr[7])
                {
                    return 1;
                }
                else if (arr[2] == arr[5] && arr[5] == arr[8])
                {
                    return 1;
                }
                else if (arr[3] == arr[6] && arr[6] == arr[9])
                {
                    return 1;
                }
                #endregion
                #region Diagonal Winning Condition
                else if (arr[1] == arr[5] && arr[5] == arr[9])
                {
                    return 1;
                }
                else if (arr[3] == arr[5] && arr[5] == arr[7])
                {
                    return 1;
                }
                #endregion
                #region Checking For Draw
                else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
                {
                    return -1;
                }
                #endregion
                else
                {
                    return 0;
                }
            }
        }
    }

  

