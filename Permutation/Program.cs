using System;
using System.Collections.Generic;
using System.Linq;

namespace Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            GetValidParenthese(5);
        }

        static List<string> GetValidParenthese(int n)
        {
            string fullParentheses = "";

            for (int i = 0; i < n; i++) fullParentheses += "(";
            for (int i = 0; i < n; i++) fullParentheses += ")";
            
            var parentheseList = new List<string>();
            GetPermutations(fullParentheses, parentheseList);

            var validParentheseList = parentheseList.Where(IsValidParenthese).ToList();
            
            return validParentheseList;
        }

        static void GetPermutations(string text, List<string> permutations, string workingSet = "")
        {
            if (text.Length == 0 && !permutations.Contains(workingSet)) 
                permutations.Add(workingSet);


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

        static bool IsValidParenthese(string parenthese)
        {
            var stack = new Stack<char>();

            foreach (char c in parenthese)
            {
                switch (c)
                {
                    case '(':
                        stack.Push(c);
                        break;
                    case ')' when stack.Count == 0:
                        return false;
                    case ')':
                        stack.Pop();
                        break;
                }
            }

            return stack.Count == 0;
        }
    }
}