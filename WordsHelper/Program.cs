﻿using System;
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

            Console.WriteLine("Input a word, alstublift ");
            string Majorword = Console.ReadLine();
            int amountWords = 0;
            foreach (string noun in nouns)
            {
                if (noun == Majorword)
                {
                    continue;
                }

                bool loopWasBroken = false;
                List<char> letters = Majorword.ToList();
                foreach (char letter in noun)
                {
                    if (letters.Contains(letter))
                    {
                        letters.Remove(letter);
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