using System;
using System.IO;
using System.Linq;

namespace Iisusie_zon
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nouns = File.ReadAllLines("word_rus.txt");
            Random randomNumbersGenerator = new Random();
            int rindex = randomNumbersGenerator.Next(0, nouns.Length);
            string newword = nouns[rindex];

            WordToGuess wordToGuess = new WordToGuess(newword);
            Console.WriteLine("Я загадал слово " + wordToGuess.Print());

            int TheMeterSillyBoy = 0;
            int CompletedHangedSillyBoy = 10;
            while (true)
            {
                Console.Write("let me invite u to input the letter ");
                string InputingLetter = Console.ReadLine();
                Console.WriteLine("you entered " + InputingLetter);
                if (wordToGuess.IsLetterAlreadyOpen(InputingLetter) == true)
                {
                    Console.WriteLine("silly boy, u've already entred the same letter");
                }
                else if (wordToGuess.containsletter(InputingLetter))
                {
                    wordToGuess.OpenLetter(InputingLetter);
                    Console.WriteLine(wordToGuess.Print());
                    if (wordToGuess.SillyWinner())
                    {
                        Console.WriteLine("Silly Winner! Fuck off yourself! My congratulations and his ones!");
                        break;
                    }
                }
                else
                {
                    TheMeterSillyBoy++;
                    if (TheMeterSillyBoy == CompletedHangedSillyBoy)
                    {
                        Console.WriteLine("Thank u, but u died!");
                        Console.WriteLine("it was " + newword);
                        break;
                    }
                    else
                    {
                        string attemps;
                        if (CompletedHangedSillyBoy - TheMeterSillyBoy == 1)
                        {
                            attemps = "attempt";
                        }
                        else
                        {
                            attemps = "attempts";
                        }

                        Console.WriteLine("U have only " + (CompletedHangedSillyBoy - TheMeterSillyBoy) + " " +
                                          attemps);
                    }
                }
            }
        }
    }

    class WordToGuess
    {
        private string _noun;
        private string[] _pressOpen;

        public WordToGuess(string noun)
        {
            _noun = noun;
            _pressOpen = new string[_noun.Length];
        }

        public bool IsLetterAlreadyOpen(string letter)
        {
            for (int i = 0; i < _pressOpen.Length; i++)
            {
                if (letter == _pressOpen[i])
                {
                    return true;
                }
            }

            return false;
        }

        public bool containsletter(string letter)
        {
            return _noun.Contains(letter);
        }

        public void OpenLetter(string letter)
        {
            for (int i = 0; i < _noun.Length; i++)
            {
                if (_noun[i].ToString() == letter)
                {
                    _pressOpen[i] = letter;
                }
            }
        }

        public string Print()
        {
            string result = "";
            for (int i = 0; i < _pressOpen.Length; i++)
            {
                string letter = _pressOpen[i];
                if (letter == null)
                {
                    result += "_";
                }
                else
                {
                    result += letter;
                }
            }

            return result;
        }

        public bool SillyWinner()
        {
            if (!_pressOpen.Contains(null))
                return true;
            return false;
        }
    }
}