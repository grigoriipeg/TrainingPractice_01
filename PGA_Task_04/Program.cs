using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGA_Task_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Игра - Победи БОССА\n\nУсловия:\nМаксимальный уровень жизни у врагов - 900\n" +
            "Величина урона, наносимого БОССОМ, для каждого хода случайна\nИгрок может пользоваться следующими действиями:\n");
            string[] enemy = { "Гоблин", "Скелет", "Тролль" };
            Random random = new Random();
            int newEnemy = random.Next(enemy.Length), health = 3, timeToAttack = 0;
            float enemyHP = (newEnemy == 0 ? 563 : newEnemy == 1 ? 900 : 257), playerHP = 250, round = 1;
            string resultOfEnemy = enemy[newEnemy], centerText = "";
            Console.WriteLine($"Вы встретили врага под названием {resultOfEnemy}");
            Console.ReadKey();
            Console.Clear();

            while (playerHP > 0 && enemyHP > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Ход {round}\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Здоровье {resultOfEnemy} {enemyHP}");
                Console.WriteLine($"Ваше здоровье {playerHP} \n");
                Console.ForegroundColor = ConsoleColor.White;
                rulesAttack();
                bool attack = random.Next(2) == 1;
                float enemyAttack = (newEnemy == 0 ? 27 : newEnemy == 1 ? 67 : 34) + round;
                float playerAttack = 45;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Ваш урон: {playerAttack}\nУрон {resultOfEnemy}: {enemyAttack}\n");
                Console.ForegroundColor = ConsoleColor.White;
                PlayerAttack(ref health, ref playerHP, ref playerAttack, ref enemyAttack, ref resultOfEnemy, ref timeToAttack, ref resultOfEnemy, ref attack);
                enemyHP -= playerAttack;
                playerHP -= enemyAttack;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Здоровье {resultOfEnemy} {enemyHP}");
                Console.WriteLine($"Ваше здоровье {playerHP} \n");
                _ = timeToAttack != 0 ? timeToAttack-- : timeToAttack;
                round++;
                Console.ReadKey();
                Console.Clear();
            
            }
            if (playerHP < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                centerText = ($"Вы умерли от рук {resultOfEnemy}\n");              
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                centerText = ($"Вы победили {resultOfEnemy} и получили {random.Next(1, 55)} золота\n");
            }
            int centerX = (Console.WindowWidth / 2) - (centerText.Length / 2);
            int centerY = (Console.WindowHeight / 2) - 1;
            Console.SetCursorPosition(centerX, centerY);
            Console.Write(centerText);
            Console.CursorVisible = false;
            Console.SetCursorPosition(centerX - 3, centerY + 2);
            Console.WriteLine("Нажмите клавишу ESC для выхода");
            do
            {
                // ваши действия
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Console.ForegroundColor = ConsoleColor.White;
        }
       public static void PlayerAttack(ref int health, ref float playerHP, ref float playerAttack, ref float enemyAttack, ref string enemy, ref int timeToAttack, ref string resultOfEnemy, ref bool attack)
        {
            Console.WriteLine("Выберите действие от 1 до 5: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Random random = new Random();
            int playerChoise = int.Parse(Console.ReadLine()), chance = random.Next(1, 10);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            EnemyAttack(ref enemyAttack, ref playerAttack, ref resultOfEnemy, ref attack);
            switch (playerChoise)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Вы атакуете {enemy} и наносите {playerAttack} урона\n");

                    break;
                case 2:
                    if (attack == true)
                    {
                        playerAttack = 0;
                        enemyAttack = 0;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    enemyAttack *= 0.1f;
                    Console.WriteLine($"Вы решили поставить щит от атаки {enemy} и прошло только {enemyAttack} урона\n");
                    break;
                case 3:
                    if (timeToAttack == 0)
                    {
                        _ = (chance <= 2 ? playerAttack = 85 : playerAttack = 15);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Вы решили провести ультра атаку и нанесли {enemy} {playerAttack} урона\n");
                        timeToAttack = 3;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Для ультра атаки необходимо продержаться еще {timeToAttack} раундов\n");
                    }
                    break;
                case 4:
                    playerAttack = 0;
                    if (health != 0)
                    {
                        health--;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Вы решили восстановить себе здоровье\nВы восстановили себе {playerHP * 0.3f} здоровья\nУ вас осталось {health} зелья здоровья\n");
                        playerHP += playerHP * 0.3f;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"У вас законичилсь зелья \n");
                    }
                    break;              
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void EnemyAttack(ref float enemyAttack, ref float playerAttack, ref string enemy, ref bool attack)
        {
            switch (attack)
            {
                case false:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Вас атакует {enemy} и наносит {enemyAttack} урона\n");
                    break;
                case true:
                    playerAttack *= 0.1f;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{enemy} в шоке и решает защититься от вашей атаки\n");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void rulesAttack()
        {
            Console.WriteLine(
                "1 - Обыкновенная атака мечом (наносит 45 урона при условии того, что враг не поставил щит)\n" +
                "2 - Поставить щит (Блокирует 90% урона)\n" +
                "3 - Провести ультра атаку (Ультра атака, наносящая 85 урона. 30% шанс, что урон пройдёт сквозь щит)\n" +
                "4 - Выпить зелье восстановления (восстанавливает 30% от базового здоровья)\n");
        }
    }
}

