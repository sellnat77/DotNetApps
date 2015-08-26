﻿//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Russell Tan Enterprises">
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
    /// Main program for Tic Tac Toe
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point for the console application
        /// </summary>
        /// <param name="args">Console arguments to pass to the program</param>
        public static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.PrintBoard();
            game.Play();
        }
    }
}
