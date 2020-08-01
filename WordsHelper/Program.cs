using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordsHelper
{
    class Program
    {
        static bool можноЛиСоставить(string главноеСлово, string очередноеСлово)
        {
            if (очередноеСлово == главноеСлово)
            {
                return false;
            }

            bool циклПрервали = false;
            List<char> буквыГлавногоСлова = главноеСлово.ToList();
            foreach (char буква in очередноеСлово)
            {
                if (буквыГлавногоСлова.Contains(буква))
                {
                    буквыГлавногоСлова.Remove(буква);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        
        static void Main(string[] args)
        {
            string[] всеСуществительные = File.ReadAllLines("word_rus.txt");

            Console.WriteLine("Input a word, alstublift ");
            string главноеСлово = Console.ReadLine();
            
            List<string> списокСлов = new List<string>();
            
            foreach (string слово in всеСуществительные)
            {
                if (можноЛиСоставить(главноеСлово, слово))
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