using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace WordsHelper
{
    [TestFixture]
    public class Tests
    {
        [TestCase("слово", "вол", ExpectedResult = true)]
        [TestCase("слово", "волище", ExpectedResult = false)]
        [TestCase("слово", "слово", ExpectedResult = false)]
        public bool МожноЛиСоставить(string главноеСлово, string очередноеСлово)
        {
            return Program.МожноЛиСоставить(главноеСлово, очередноеСлово);
        }
    }
    public static class Program
    {
        public static bool МожноЛиСоставить(string главноеСлово, string очередноеСлово)
        {
            if (очередноеСлово == главноеСлово)
            {
                return false;
            }

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
                if (МожноЛиСоставить(главноеСлово, слово))
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