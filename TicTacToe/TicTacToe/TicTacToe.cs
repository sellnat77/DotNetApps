//-----------------------------------------------------------------------
// <copyright file="TicTacToe.cs" company="Russell Tan Enterprises">
//     Copyright - Russell Tan Enterprises
// </copyright>
// Name: Russell Tan
// Class: CECS 475 Application development with ASP.NET
// Date:
// Purpose: Create an simulate a tic tac toe game on the console
//-----------------------------------------------------------------------
namespace TicTacToe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class for the Tic Tac Toe application
    /// </summary>
    public class TicTacToe
    {
        /// <summary>
        /// Private members for a standard tic tac toe game
        /// </summary>
        private const int BOARDSIZE = 3;
        private int[,] board;
        private int numberOfMoves;
        private bool playerOne;
        private bool gameOver;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicTacToe" /> class with zeroed out members
        /// </summary>
        public TicTacToe()
        {
            this.board = new int[BOARDSIZE, BOARDSIZE];
            this.playerOne = true;
            this.numberOfMoves = 0;
            this.gameOver = false;
        }

        /// <summary>
        /// Prints the current game board to the console
        /// </summary>
        public void PrintBoard()
        {
            int j, k;

            for (j = 0; j < BOARDSIZE; j++)
            {
                Console.WriteLine("-------------");
                Console.WriteLine("|   |   |   |");
                Console.Write("| ");

                for (k = 0; k < BOARDSIZE; k++)
                {
                    Console.Write(this.board[j, k] + " | ");
                }

                Console.WriteLine(" ROW: " + j);
                Console.WriteLine("|   |   |   |");
            }

            Console.WriteLine("-------------");
        }

        /// <summary>
        /// Allows the game to be played repeatedly and handles the gameplay 
        /// mechanics of the tic tac toe application
        /// </summary>
        public void Play()
        {
            bool again = true;
            while (again)
            {
                while (!this.gameOver)
                {
                    if (this.playerOne)
                    {
                        Console.WriteLine("\n\n\tPlayer One");
                    }
                    else
                    {
                        Console.WriteLine("\n\n\tPlayer Two");
                    }

                    Console.Write("Enter a row: ");
                    int row = int.Parse(Console.ReadLine());
                    Console.Write("\nEnter a col: ");
                    int col = int.Parse(Console.ReadLine());

                    this.Move(row, col);

                    this.PrintBoard();
                    this.gameOver = this.CheckWin();
                    if (this.numberOfMoves == BOARDSIZE * BOARDSIZE && !this.CheckWin())
                    {
                        Console.WriteLine("CATS GAME!");
                        this.ResetGame();
                    }
                }

                Console.WriteLine("Play again? y/n");
                if (Console.ReadLine() == "y")
                {
                    again = true;
                    this.ResetGame();
                }
                else
                {
                    again = false;
                }
            }
        }

        /// <summary>
        /// Resets the game elements
        /// </summary>
        private void ResetGame()
        {
            this.playerOne = true;
            this.numberOfMoves = 0;
            this.gameOver = false;
            this.board = new int[BOARDSIZE, BOARDSIZE];
        }

        /// <summary>
        /// Checks if there is a victory on the game board by the use of helper methods
        /// <see cref="CheckVert"/>
        /// <see cref="CheckHoriz"/>
        /// <see cref="CheckDiag"/>
        /// </summary>
        /// <returns>Returns true if there exists a victory on the board</returns>
        private bool CheckWin()
        {
            if (this.CheckVert() || this.CheckHoriz() || this.CheckDiag())
            {
                if (!this.playerOne)
                {
                    Console.WriteLine("CONGRSTULATIONS PLAYER ONE!!!! You won this round!");
                }
                else
                {
                    Console.WriteLine("CONGRSTULATIONS PLAYER TWO!!!! You won this round!");
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Helper method to check for vertical victories on the game board
        /// </summary>
        /// <returns>Returns true if there exists a vertical victory on the board</returns>
        private bool CheckVert()
        {
            int k;
            bool win = false;

            for (k = 0; k < BOARDSIZE; k++)
            {
                if (this.board[0, k] == this.board[1, k] && this.board[2, k] == this.board[1, k])
                {
                    if (this.board[1, k] > 0)
                    {
                        win = true;
                    }
                }
            }

            return win;
        }

        /// <summary>
        /// Helper method to check if there is a horizontal victory on the board
        /// </summary>
        /// <returns>Returns true if there exists a victory on the board</returns>
        private bool CheckHoriz()
        {
            int k;
            bool win = false;

            for (k = 0; k < BOARDSIZE; k++)
            {
                if (this.board[k, 0] == this.board[k, 1] && this.board[k, 1] == this.board[k, 2])
                {
                    if (this.board[k, 1] > 0)
                    {
                        win = true;
                    }
                }
            }

            return win;
        }

        /// <summary>
        /// Helper method to check if there is a diagonal victory on the board
        /// </summary>
        /// <returns>Returns true if there exists a diagonal victory on the board</returns>
        private bool CheckDiag()
        {
            bool win = false;

            if (this.board[0, 0] == this.board[1, 1] && this.board[1, 1] == this.board[2, 2])
            {
                if (this.board[1, 1] > 0)
                {
                    win = true;
                }
            }

            if (this.board[0, 2] == this.board[1, 1] && this.board[1, 1] == this.board[2, 0])
            {
                if (this.board[1, 1] > 0)
                {
                    win = true;
                }
            }

            return win;
        }

        /// <summary>
        /// Lets a user place a "move" on the board based on row and column index starting at 0
        /// </summary>
        /// <param name="row">Row for the move</param>
        /// <param name="col">Column for the move</param>
        private void Move(int row, int col)
        {
            if (this.playerOne)
            {
                if (this.board[row, col] > 0)
                {
                    Console.WriteLine("Error, spot is already taken, try again...");
                    Console.Write("Enter a row: ");
                    int newRow = int.Parse(Console.ReadLine());
                    Console.Write("\nEnter a col: ");
                    int newCol = int.Parse(Console.ReadLine());

                    this.Move(newRow, newCol);
                }
                else
                {
                    this.board[row, col] = 1;
                    this.playerOne = false;
                }
            }
            else
            {
                if (this.board[row, col] > 0)
                {
                    Console.WriteLine("Error, spot is already taken, try again...");
                    Console.Write("Enter a row: ");
                    int newRow = int.Parse(Console.ReadLine());
                    Console.Write("\nEnter a col: ");
                    int newCol = int.Parse(Console.ReadLine());

                    this.Move(newRow, newCol);
                }
                else
                {
                    this.board[row, col] = 2;
                    this.playerOne = true;
                }
            }

            this.numberOfMoves++;
        }
    }
}
