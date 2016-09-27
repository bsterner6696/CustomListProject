using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<string> words = new CustomList<string>
            {
                "hello", "my", "name", "is", "Ben"
            };
            CustomList<string> moreWords = new CustomList<string>
            {
                "hello", "this", "is", "more", "words", "so", "many", "words"
            };
            CustomList<string> combinedWords = words + moreWords;

            CustomList<string> subtractedWords = words - moreWords;

            CustomList<string> zippedWords = words.Zip(moreWords);

            CustomList<int> numbers = new CustomList<int>
            {
                1, 2, 3, 4, 5
            };

            CustomList<double> doubles = new CustomList<double>
            {
                1.3, 2.8, 6.4453535, .0123424, .00001
            };


            Console.WriteLine(words[3]);
            foreach(string line in words)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("The count of the list is {0}", words.Count());
            Console.WriteLine(" ");

            foreach (string line in moreWords)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("The count of the list is {0}", moreWords.Count());
            Console.WriteLine(" ");

            foreach (string line in combinedWords)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("The count of the list is {0}", combinedWords.Count());
            Console.WriteLine(" ");

            foreach (string line in subtractedWords)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("The count of the list is {0}", subtractedWords.Count());
            Console.WriteLine(" ");

            foreach (string line in zippedWords)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("The count of the list is {0}", zippedWords.Count());
            Console.WriteLine(" ");


            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            };
            Console.WriteLine(" ");

            foreach (double number in doubles){
                Console.WriteLine(number);
            };
            Console.WriteLine(" ");

            words.Add("Sterner");
            foreach(string line in words)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(" ");
            Console.WriteLine("The count of the list is {0}", words.Count());
            Console.WriteLine(" ");

            words.Remove("hello");
            foreach(string line in words)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("The count of the list is {0}", words.Count());
            Console.WriteLine(" ");
            Console.WriteLine(words.ToString());
            Console.WriteLine(" ");

            Console.WriteLine(words[3]);

            Console.ReadLine();
        }
    }
}
