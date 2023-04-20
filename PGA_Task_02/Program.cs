using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGA_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int count = 0;

            for (int i = 1; i > count; i++)
            {
                Console.Write("Напишите какой-то текст: ");
                input = Console.ReadLine();

                if (String.Equals(input, "exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Пока!");
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("\nДля выхода из программы напишите слово 'exit'.\n");
            }
        }
    }
}
