using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TestPermutation("abd", "eaidbaooo"));
        }
        
        static bool TestPermutation(string s1, string s2)
        {
            var permutationList = new List<string>();

           GetPermutations(s1, permutationList);

           return permutationList.Any(s2.Contains);
        }
        


        static void GetPermutations(string text, List<string> permutations, string workingSet ="")
        {
          
            if (text.Length == 0) permutations.Add(workingSet);


            for (int i = 0; i < text.Length; i++)
            {
                char value = text.ElementAt(i);

                workingSet += value;
                text = text.Remove(i, 1);

                GetPermutations(text, permutations, workingSet);

                text = text.Insert(i, value.ToString());
                workingSet = workingSet.Remove(workingSet.Length - 1, 1);
            }
        }
    }
}