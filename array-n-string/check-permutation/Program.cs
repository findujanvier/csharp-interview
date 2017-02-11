/*
Question: give two strings, write a method to decide if one is a permutation of the other
*/
using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        static string str1 = "1abcd";
        static string str2 = "dcba";
        
        public static void Main(string[] args)
        {
            // Console.Write ("Hello");
            // Solution1();
            Solution2 ();
        }

        /*
        solution 1:
        - compare 2 sorted arrays with SequenceEqual (linq)
         */
        public static void Solution1 (){
            var result = false;
            if (str1.Length != str2.Length ) goto End;  

            char[] c1 = str1.ToCharArray ();
            char[] c2 = str2.ToCharArray ();
            
            Array.Sort(c1);
            Array.Sort(c2);           
            
            result = c1.SequenceEqual (c2);
            
            End:           
            Console.Write (result);
        }

        /* 
        solution 2:
        - check if both strings are having the same length, if not return false
        - craete a hash table, make character as key and its count as value
        - navigate the string one taking each character at a time
        - check if that a character already existing in hash table, if yes then increase its count by 1 and if it does not exist insert into hash table with the count as 1
        - now navigate the second string taking each character at a time
        - check if that character existing in hash table, if yes then decrease its count by 1 and if it does not exist then return false
        - at the end navigate through hash table and check if all the keys has 0 count against it if yes then return true else return false
        */

        public static void Solution2 () {
            var charCounts = new Dictionary <char,int>();
            // var charCounts = new Hashtable ();
            
            var result = false;
            if (str1.Length != str2.Length ) goto End;  

            foreach (var c in str1)
            {
                if (charCounts.ContainsKey (c)) {
                    charCounts[c] ++;
                } else {
                    charCounts.Add (c, 0);
                }
            }

            foreach (var c in str2)
            {
                if (charCounts.ContainsKey(c)) {
                    charCounts[c]--;
                } else {
                    goto End;
                }
            }

            foreach (var item in charCounts)
            {
                if (item.Value > 0) {
                    goto End;
                }
            }
            result = true;

            End:
            Console.Write (result);

        }
    }
}
