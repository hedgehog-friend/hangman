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
            string[] всеСуществительные = File.ReadAllLines("word_rus.txt");

            Console.WriteLine("Input a word, alstublift ");
            string главноеСлово = Console.ReadLine();
            
            List<string> списокСлов = new List<string>();
            
            foreach (string слово in всеСуществительные)
            {
                if (слово == главноеСлово)
                {
                    continue;
                }

                bool циклПрервали = false;
                List<char> буквыГлавногоСлова = главноеСлово.ToList();
                foreach (char буква in слово)
                {
                    if (буквыГлавногоСлова.Contains(буква))
                    {
                        буквыГлавногоСлова.Remove(буква);
                    }
                    else
                    {
                        циклПрервали = true;
                        break;
                    }
                }

                if (циклПрервали == false)
                {
                    списокСлов.Add(слово);
                }
            }

            Console.WriteLine("в итоге имеем " + списокСлов.Count);
            if (списокСлов.Count == 0)
            {
                Console.WriteLine("нетути");
            }
            else
            {
                foreach (string сноваСлово in списокСлов)
                {
                    Console.WriteLine(сноваСлово);
                }
            }
        }
    }
}