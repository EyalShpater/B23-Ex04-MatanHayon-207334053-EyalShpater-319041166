using System;
using System.Linq;

namespace Ex04.Menus.Test
{
    internal class CountSpacesMethod : Interfaces.ILeafMethod
    {
        public void WhenSelected()
        {
            string input;

            Console.WriteLine("Please write a sentence");
            input = Console.ReadLine();
            Console.WriteLine("There are {0} spaces in your sentence.", countNumOfSpacesInSentence(input));
        }

        private static int countNumOfSpacesInSentence(string i_Sentence)
        {
            int count = 0;

            for (int i = 0; i < i_Sentence.Length; i++)
            {
                if (i_Sentence.ElementAt(i) == ' ')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
