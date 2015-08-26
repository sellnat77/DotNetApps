//-----------------------------------------------------------------------
// <copyright file="SetsLab.cs" company="Russell Tan Enterprises">
//     Copyright (c) Russell Tan Enterprises. All rights reserved.
// </copyright>
// <author>Russell Tan</author>
//-----------------------------------------------------------------------
namespace SetsLab
{
    using System;

    /// <summary>
    /// Public class for the Sets Lab
    /// </summary>
    public class SetsLab
    {
        /// <summary>
        /// Defines the max size for the arrays being dealt with 
        /// </summary>
        private const int MAXSIZE = 500;
        
        /// <summary>
        /// The array of integers to perform operations on
        /// </summary>
        private int[] intSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetsLab" /> class
        /// </summary>
        public SetsLab()
        {
            int k;
            this.intSet = new int[MAXSIZE];

            for (k = 0; k < MAXSIZE; k++)
            {
                this.intSet[k] = -999;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetsLab" /> class
        /// with a passed array to populate the intSet member
        /// </summary>
        /// <param name="passedArray">Array passed into the constructor that populates the int array member</param>
        public SetsLab(int[] passedArray)
        {
            if (passedArray.Length <= MAXSIZE)
            {
                this.intSet = passedArray;
            }
            else
            {
                Console.WriteLine("Array passed in is too large!");
            }
        }

        /// <summary>
        /// Accessor to retrieve an item at a specific index
        /// </summary>
        /// <param name="index">The index to look for the value to return</param>
        /// <returns>An integer at the specified location</returns>
        public int GetIntSet(int index)
        {
            return this.intSet[index];
        }

        /// <summary>
        /// Accessor to return the entire integer array
        /// </summary>
        /// <returns>The entire integer array</returns>
        public int[] GetIntSet()
        {
            return this.intSet;
        }

        /// <summary>
        /// The mutator to set the value at a particular index
        /// </summary>
        /// <param name="index">Index to change</param>
        /// <param name="value">Value to set</param>
        public void SetIntSet(int index, int value)
        {
            this.intSet[index] = value;
        }

        /// <summary>
        /// The mutator to set an entire integer array
        /// </summary>
        /// <param name="integerSet">The integer array to replace this. array</param>
        public void SetIntSet(int[] integerSet)
        {
            this.intSet = integerSet;
        }

        /// <summary>
        /// Iterates through the larger array and determines which elements belong to either 
        /// </summary>
        /// <param name="setToUnionWith">Integer array to be unioned with this. array</param>
        /// <returns>A SetsLab variable containing the unioned set</returns>
        public SetsLab UnionSet(int[] setToUnionWith)
        {
            int k;
            int setLength = setToUnionWith.Length;
            SetsLab returnSet = new SetsLab();
            
            for (k = 0; k < setLength; k++)
            {
                if (this.GetIntSet(k) == setToUnionWith[k])
                {
                    returnSet.Insert(this.GetIntSet(k));
                }
                else if (this.GetIntSet(k) != setToUnionWith[k])
                {
                    returnSet.Insert(setToUnionWith[k]);
                }
            }

            Console.WriteLine("Unioned set = {0}", returnSet);
            return returnSet;
        }

        /// <summary>
        /// Inserts an integer at the end of the array
        /// </summary>
        /// <param name="valToInsert">The integer to insert</param>
        public void Insert(int valToInsert)
        {
            int k = 0; 
            
            while (k < MAXSIZE)
            {
                if (this.GetIntSet(k) == -999)
                {
                    this.SetIntSet(k, valToInsert);
                    break;
                }

                k++;
            }
        }
    } 
}
