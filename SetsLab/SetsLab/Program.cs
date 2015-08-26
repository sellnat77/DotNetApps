//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Russell Tan Enterprises">
//     Copyright (c) Russell Tan Enterprises. All rights reserved.
// </copyright>
// <author>Russell Tan</author>
//-----------------------------------------------------------------------
namespace SetsLab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Entry point for the main program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method for the sets lab program
        /// </summary>
        /// <param name="args">Console arguments to pass to the program</param>
        public static void Main(string[] args)
        {
            int[] intArrA = { 1, 2, 4, 6, 8, 9, 6, 5, 4, 3 };
            int[] intArrB = { 3, 6, 8, 2, 1, 1, 11, 3, 455, 6, 44, 2 };
            
            SetsLab setA = new SetsLab(intArrA);
            SetsLab setB = new SetsLab(intArrB);

            setA.UnionSet(setB.GetIntSet());
        }
    }
}
