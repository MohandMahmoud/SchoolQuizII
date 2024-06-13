using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class SchoolQuizII
    {
        #region YOUR CODE IS HERE
        static public void Sample_Mode(int Old_Size, int[] Dynamic_programming_List, int New_Size)
        {
            //nitializes the dynamic programming list
            //with int.MaxValue for indices 1 to Old_Size to represent
            //the absence of valid combinations, and sets the value at index 0 to 0.
            for (int i = 1; i <= Old_Size; i++)
            {
                Dynamic_programming_List[i] = int.MaxValue;
            }

            Dynamic_programming_List[0] = 0;

        }
        static public void MIN_Mode(int Old_Size, int[] Dynamic_programming_List, int New_Size, int[] numbers)
        {
            //the dynamic programming list by iterating through all values from 1 to Old_Size and checking
            //each number from the numbers array to see if it can be used to obtain
            //the minimum number of integers needed to sum up to the current value i.
            for (int i = 1; i <= Old_Size; i++)
            {              
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] <= i && Dynamic_programming_List[i - numbers[j]] != int.MaxValue)
                    {
                        Dynamic_programming_List[i] = Math.Min(Dynamic_programming_List[i], Dynamic_programming_List[i - numbers[j]] + 1);
                    }
                }
            }
        }
        static public int Null_Solve(int Old_Size, int[] Dynamic_programming_List, int New_Size)
        {
            // If it's not possible to sum up to N using any number of integers, return -1.
            if (Dynamic_programming_List[Old_Size] == int.MaxValue)
                return -1;
            return 0;

        }
        static public int[] Null_Construct(int Old_Size, int[] Dynamic_programming_List, int New_Size)
        {
            // If it's not possible to sum up to N using any number of integers, return Null.
            if (Dynamic_programming_List[Old_Size] == int.MaxValue)
            {

                return null;
            }
            return new int[] { };
        }
        static public void Hard_Mode(int Old_Size, int[] Dynamic_programming_List, int New_Size, int[] numbers, List<int> selectedNumbers)
        {
            //while loop to select the numbers used to obtain
            //the minimum number of integers needed to sum up to a target value

            while (Old_Size > 0)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] <= Old_Size && Dynamic_programming_List[Old_Size - numbers[j]] == Dynamic_programming_List[Old_Size] - 1)
                    {
                        selectedNumbers.Add(numbers[j]);
                        Old_Size -= numbers[j];
                        break;
                    }
                }
            }

        }
        #region FUNCTION#1: Calculate the Value
        //Your Code is Here:
        //==================
        /// <summary>
        /// find the minimum number of integers whose sum equals to ‘N’
        /// </summary>
        /// <param name="N">number given by the teacher</param>
        /// <param name="numbers">list of possible numbers given by the teacher (starting by 1)</param>
        /// <returns>minimum number of integers whose sum equals to ‘N’</returns>

        static public int SolveValue(int N, int[] numbers)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            // Initialize new size to DP Table .
            int New_Size = N + 1;
            // Initialize  DP Table With new size  we create it .
            int[] Dynamic_programming_Table = new int[New_Size];
            // Sort Max Value Expected the index[0] is Equal=0.
            Sample_Mode(N, Dynamic_programming_Table, New_Size);
            //Push Minumum Value in Dynamic_programming_Table.
            MIN_Mode(N, Dynamic_programming_Table, New_Size,numbers);
            // If it's not possible to sum up to N using any number of integers, return -1.
            Null_Solve(N, Dynamic_programming_Table, New_Size);
            // Return Dynamic_programming_Table .
            return Dynamic_programming_Table[N];
        }
        #endregion

        #region FUNCTION#2: Construct the Solution
        //Your Code is Here:
        //==================
        /// <returns>the numbers themselves whose sum equals to ‘N’</returns>
        static public int[] ConstructSolution(int N, int[] numbers)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            // Initialize new size to DP Table .
            int New_Size = N+1;
            // Initialize  DP Table With new size  we create it .
            int[] Dynamic_programming_List = new int[New_Size];
            // Initialize selectedNumbers  List  .
            List<int> selectedNumbers = new List<int>();
            // Sort Max Value Expected the index[0] is Equal=0.
            Sample_Mode(N, Dynamic_programming_List, New_Size);
            //Push Minumum Value in Dynamic_programming_Table.
            MIN_Mode(N, Dynamic_programming_List, New_Size, numbers);
            // If it's not possible to sum up to N using any number of integers, return Null.
            Null_Construct(N, Dynamic_programming_List, New_Size);
           //while loop to select the numbers used to obtain
           //the minimum number of integers needed to sum up to a target value
            Hard_Mode(N, Dynamic_programming_List, New_Size, numbers, selectedNumbers);
            //Return the selected numbers in reverse order.
            return selectedNumbers.ToArray().Reverse().ToArray();
        }
        #endregion

        #endregion
    }
}
