/*
Question implement and algorithm to determine if a string has all unique characters. What if you cannot use additional data structures?
*/
using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // Solution1 ();
            Solution2 ();
            
        }


        /*
        solution 1:
        - create a hashset object
        - scan the whole string, and add each character one by one to the hashset object
        - if the add object returns true then continue
        - else return false
        */
        public static void Solution1 () {

            var result = false;
            
            Console.Write ("Input the string: ");
            string inputString = Console.ReadLine ();

            var uniqueCharset = new HashSet<char>();

            for (int i = 0; i < inputString.Length; i++)
            {
                result = uniqueCharset.Add (inputString[i]);
                if (result == false) break;
            }
            Console.WriteLine (result);
        }

        /*
        solution 2:
        - scan the inputString, take each character one by one and set cound flag to 0.
        - for each character in the inputString, re-scan the inputString and compare the character with each character appear in the inputString
        - if equal then increase the count by 1 else conitnue the loop
        - if count flag value is greater than 1 then return false else return true
        */
        public static void Solution2 () {
            var result = false;

            Console.Write ("Input the string: ");            
            string inputString = Console.ReadLine ();

            for (int i = 0; i < inputString.Length; i++)
            {
                char c = inputString[i];
                int count = 0;

                for (int j = 0; j < inputString.Length; j++)
                {
                    if (c == inputString[j]) count++;
                }

                if (count > 1) {
                    result = false;
                    goto End;
                }
            }
            result = true;

            End:     
            Console.Write (result);
        }

    }
}
