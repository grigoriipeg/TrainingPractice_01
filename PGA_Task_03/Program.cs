using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGA_Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "qwerty", input;

            for (int i = 2; i >= 0; i--)
            {
                Console.Write("Введите пароль: ");
                input = Console.ReadLine();

                if (String.Equals(input, password))
                {
                    Console.WriteLine("Вы взломали Пентагон!");
                    break;
                }
                else
                {
                    Console.WriteLine("Введён неверный пароль. Осталось попыток: {0}\n", i);
                }                     
            }
        Console.ReadKey();
        } 
    }
}
