using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordsHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nouns = File.ReadAllLines("word_rus.txt");

            string firstNoun = nouns[0];

            List<char> firstNounLetters = firstNoun.ToList();

            Console.WriteLine("Input a word, alstublift ");
            string Majorword = Console.ReadLine();
            int amountWords = 0;
            for (int i = 0; i < nouns.Length; i++)
            {
                string noun = nouns[i];
                if (noun==Majorword)
                {continue;
                }

                bool loopWasBroken = false;
                List<char> letters = Majorword.ToList();
                for (int j = 0; j < noun.Length; j++)
                {
                    if (letters.Contains(noun[j]))
                    {
                        letters.Remove(noun[j]);
                    }
                    else
                    {
                        loopWasBroken = true;
                        break;
                    }
                }

                if (loopWasBroken == false)
                {
                    amountWords++;
                    Console.WriteLine(noun);
                }
            }

            Console.WriteLine("в итоге имеем " + amountWords);
            if (amountWords == 0)
            {
                Console.WriteLine("нетути");
            }
        }
    }
}