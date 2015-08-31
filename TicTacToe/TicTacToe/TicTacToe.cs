//-----------------------------------------------------------------------
// <copyright file="TicTacToe.cs" company="Russell Tan">
//     Copyright - Russell Tan
// </copyright>
// Name: Russell Tan
// Class: CECS 475 Application development with ASP.NET
// Date: 30 August 2015
// Purpose: Create and simulate a tic tac toe game on the console
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
        private const int MAX_CONSOLE_WIDTH = 80;
        private const int TOTAL_MOVES = BOARDSIZE * BOARDSIZE;
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
        /// Prints a given string to the center of the console given that the standard console
        /// width is 80 characters
        /// </summary>
        /// <param name="s">The string to print in the center of the console</param>
        public void PrintCenter(string s)
        {
            int buffer = (MAX_CONSOLE_WIDTH - s.Length) / 2;

            for (int k = 0; k < buffer; k++)
            {
                Console.Write(" ");
            }

            Console.Write(s);
        }

        /// <summary>
        /// Prints the current game board to the console
        /// </summary>
        public void PrintBoard()
        {
            Console.Clear();

            int j, k;
            string dataRow;

            Console.WriteLine("\n\n\n");
            this.PrintCenter("Welcome to Tic-Tac-Toe!\n\n");

            // Print row by row
            for (j = 0; j < BOARDSIZE; j++)
            {
                // Top
                this.PrintCenter("-------------\n");
                this.PrintCenter("|   |   |   |\n");
                dataRow = " | ";

                // Each column's value
                for (k = 0; k < BOARDSIZE; k++)
                {
                    dataRow += this.board[j, k] + " | ";
                }

                this.PrintCenter(dataRow + "\n");

                // Bottom
                this.PrintCenter("|   |   |   |\n");
            }

            this.PrintCenter("-------------\n");
        }

        /// <summary>
        /// Allows the game to be played repeatedly and handles the gameplay 
        /// mechanics of the tic tac toe application
        /// </summary>
        public void Play()
        {
            string ans;
            bool again = true;

            // Play again after game finishes
            while (again)
            {
                // While game is in progress
                while (!this.gameOver)
                {
                    if (this.playerOne)
                    {
                        Console.WriteLine("\n\n\t\tPlayer One's Turn");
                    }
                    else
                    {
                        Console.WriteLine("\n\n\t\tPlayer Two's Turn");
                    }

                    Console.Write("\tEnter a row: ");
                    try
                    {
                        int row = int.Parse(Console.ReadLine());
                        Console.Write("\n\tEnter a col: ");
                        int col = int.Parse(Console.ReadLine());
                        this.Move(row, col);
                    }
                    catch (FormatException e)
                    {
                        // Try catch used to throw out "format" exceptions
                        // This limits the input to ONLY intgers
                    }

                    this.PrintBoard();

                    // See if there is a winning condition on the board
                    this.gameOver = this.CheckWin();
                }

                this.PrintCenter("\tPlay again? y/n\n");
                ans = Console.ReadLine().ToLower();
                if (ans == "y" || ans == "yes")
                {
                    again = true;
                    this.ResetGame();
                    this.PrintBoard();
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
                    this.PrintCenter("CONGRATULATIONS PLAYER ONE!!!! You won this round!");
                }
                else
                {
                    this.PrintCenter("CONGRATULATIONS PLAYER TWO!!!! You won this round!");
                }

                return true;
            }

            if (this.numberOfMoves == TOTAL_MOVES)
            {
                this.PrintCenter("CATS GAME!");
                return true;                
            }

            return false;
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
            if (row > 2 || col > 2)
            {
                Console.WriteLine("\tError, Coordinates out of bounds, try again...");
                Console.Write("\tEnter a row: ");
                int newRow = int.Parse(Console.ReadLine());
                Console.Write("\n\tEnter a col: ");
                int newCol = int.Parse(Console.ReadLine());

                this.Move(newRow, newCol);
            }
            else
            {
                if (this.playerOne)
                {
                    if (this.board[row, col] > 0)
                    {
                        Console.WriteLine("\tError, spot is already taken, try again...");
                        Console.Write("\tEnter a row: ");
                        int newRow = int.Parse(Console.ReadLine());
                        Console.Write("\n\tEnter a col: ");
                        int newCol = int.Parse(Console.ReadLine());

                        this.Move(newRow, newCol);
                    }
                    else
                    {
                        this.board[row, col] = 1;
                        this.playerOne = false;
                        this.numberOfMoves++;
                    }
                }
                else
                {
                    if (this.board[row, col] > 0)
                    {
                        Console.WriteLine("\tError, spot is already taken, try again...");
                        Console.Write("\tEnter a row: ");
                        int newRow = int.Parse(Console.ReadLine());
                        Console.Write("\n\tEnter a col: ");
                        int newCol = int.Parse(Console.ReadLine());

                        this.Move(newRow, newCol);
                    }
                    else
                    {
                        this.board[row, col] = 2;
                        this.playerOne = true;
                        this.numberOfMoves++;
                    }
                }
            }
        }
    }
}
