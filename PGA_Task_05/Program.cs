using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGA_Task_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int y = 0, x = 0, i = 0, j = 0, n = 0;
            var wall = '█';
            var space = ' ';
            var player = '☺';
            var end = '▲';
            var coin = '·';
            int count = 0;
            int coins = 0;
            int playerY = -1;
            int playerX = -1;
            int coinCounter = 0;
            bool start = true;

            Console.SetWindowPosition(0, 0);
            string[] str = File.ReadAllLines($"maze1.txt");
            int[,] map = new int[str.Length, str[0].Split(' ').Length];
            for (i = 0; i < str.Length; i++)
            {
                string[] str2 = str[i].Split(' ');
                for (j = 0; j < str2.Length; j++)
                    map[i, j] = Int32.Parse(str2[j]);
                n = str2.Length;
            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.SetCursorPosition(x++, y);
                    if (map[i, j] == 0)
                    {
                        Console.WriteLine(space);
                    }
                    if (map[i, j] == 1)
                    {
                        Console.WriteLine(wall);
                    }
                    if (map[i, j] == 2)
                    {
                        Console.Write(player);
                        playerX = j;
                        playerY = i;
                    }
                    if (map[i, j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(end);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    if (map[i, j] == 4)
                    {
                        Console.WriteLine(coin);
                        coins++;
                    }
                }
                x = 0;
                Console.SetCursorPosition(x, ++y);
            }
            Console.CursorVisible = false;
            ConsoleKeyInfo key;
            Console.SetCursorPosition(x = playerX, y = playerY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("☺");

            while (start)
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow) // клавиша W
                {
                    if (map[playerY - 1, playerX] != 1)
                    {
                        Console.SetCursorPosition(x, y--); Console.Write(" ");
                        Console.SetCursorPosition(x, y); Console.Write("☺");
                        playerY--;
                        count++;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow) // клавиша S
                {
                    if (map[playerY + 1, playerX] != 1)
                    {
                        Console.SetCursorPosition(x, y++); Console.Write(" ");
                        Console.SetCursorPosition(x, y); Console.Write("☺");
                        playerY++;
                        count++;
                    }
                }
                else if (key.Key == ConsoleKey.LeftArrow) // клавиша A
                {
                    if (map[playerY, playerX - 1] != 1)
                    {
                        Console.SetCursorPosition(x--, y); Console.Write(" ");
                        Console.SetCursorPosition(x, y); Console.Write("☺");
                        playerX--;
                        count++;
                    }
                }
                else if (key.Key == ConsoleKey.RightArrow) // клавиша D
                {
                    if (map[playerY, playerX + 1] != 1)
                    {
                        Console.SetCursorPosition(x, y); Console.Write(" ");
                        Console.SetCursorPosition(++x, y); Console.Write("☺");
                        playerX++;
                        count++;
                    }
                }
                if (map[playerY, playerX] == 4)
                {
                    coinCounter++;
                    map[playerY, playerX] = 0;
                }
                if (playerY == 1 & playerX == 23)
                {
                    start = false;
                }
            }
            Console.Clear();
            Console.SetCursorPosition(x = 50, y = 10);
            Console.WriteLine("Вы прошли лабиринт!");
            Console.SetCursorPosition(x = 52, y = 11);
            Console.WriteLine("Всего шагов: " + count);
            Console.SetCursorPosition(x = 50, y = 13);
            Console.WriteLine("Собрано монет: " + coinCounter + " из " + coins);
            Console.SetCursorPosition(x = 44, y = 12);
            Console.WriteLine("Нажмите клавишу ESC для выхода");
            do
            {
                // ваши действия
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
