using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGA_Task_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[10];
            FillArray(mas);
            Console.WriteLine("Исходный массив");
            OutputArray(mas);
            ShuffleArray(mas);
            Console.WriteLine("\nПеремешанный массив");
            OutputArray(mas);
            Console.ReadKey();
        }

        static void FillArray(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
        }

        static void OutputArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static void ShuffleArray(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int randomItem = random.Next(i);
                int x = array[randomItem];
                array[randomItem] = array[i];
                array[i] = x;
            }
        }
    }
}
