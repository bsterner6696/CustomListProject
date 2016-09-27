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

            CustomList<int> numbers = new CustomList<int>
            {
                1, 2, 3, 4, 5
            };

            CustomList<double> doubles = new CustomList<double>
            {
                1.3, 2.8, 6.4453535, .0123424, .00001
            };

            foreach(string line in words)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("The count of the list is {0}", words.Count());
            Console.WriteLine(" ");



            foreach(int number in numbers)
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
            Console.ReadLine();
        }
    }
}
