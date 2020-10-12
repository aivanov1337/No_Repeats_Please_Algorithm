using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Random_Proekti_Console_App
{
    class Program
    {
        public static List<string> permutations = new List<string>();

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        public static void GetPermutations(char[] list)
        {
            int x = list.Length - 1;
            GetPermutations(list, 0, x);
        }

        private static void GetPermutations(char[] list, int k, int m)
        {
            if (k == m)
            {
                permutations.Add(new string(list));
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPermutations(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }

        public static void RemoveSequentials()
        {
            List<string> copy = new List<string>(permutations);

            foreach (string n in permutations)
            {
                char[] charArray = n.ToCharArray();

               for(int i=0; i<charArray.Length; i++)
                {
                    bool isLastCharacter = (i + 1 == charArray.Length);
                    if (!isLastCharacter &&  charArray[i] == charArray[i + 1])
                    {
                        copy.Remove(n);
                    }
                }                
            }
            Console.WriteLine(copy.Count);
        }

        static void Main(string[] args)
        {
            string str = "zzzzzzzz";
            char[] arr = str.ToCharArray();
            
            GetPermutations(arr);
            RemoveSequentials();

            Console.ReadLine();
        }
    }
}
