using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPractice_01
{
    class Program
    {
        static void Main(string[] args)
        {
        int crystals, gold, course = 100000;
            
        g: Console.Write("Введите количество золота (допускаются только целые значения): ");
            try
            {
                gold = int.Parse(Console.ReadLine());
                if(gold <= 0)
                {
                    Console.WriteLine($"Входная строка имела неверный формат! Попробуйте снова\n");
                    goto g;
                }                
            }
            catch (FormatException)
            {
                Console.WriteLine($"Входная строка имела неверный формат! Попробуйте снова\n");
                goto g;
            }
            //int.TryParse(dollar, out value);
            Console.WriteLine("Количество золота: " + gold);
            Console.WriteLine();
            Console.WriteLine("Мы предлагаем следующий курс обмена: 1 золото = 10 кристаллов.\nВ рамках одной транзакции вы можете приобрести не более 100.000 тысяч кристаллов.");
            c: Console.Write("Введите количество золота, которые вы хотели бы обменять на кристаллы (допускаются только целые значения): ");
            try
            {
                crystals = int.Parse(Console.ReadLine());
                if (crystals <= 0 || crystals > gold)
                {
                    Console.WriteLine($"Входная строка имела неверный формат! Попробуйте снова\n");
                    goto c;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine($"Входная строка имела неверный формат! Попробуйте снова\n");
                goto c;
            }

            int value = crystals * 10;
            int goldLeft = gold - crystals;
            int courseLeft = course - value;
            if (value <= course)
            {
                Console.WriteLine("Результат обмена - за {0} ед.золота вы получаете {1} кристаллов.", crystals ,value);
                Console.WriteLine("В вашем кошельке осталось {0} ед. золота, количество кристаллов для покупки - {1}", goldLeft, courseLeft);
            }
            else
            {
                Console.WriteLine("Сумма обмена составляет более 100.000 кристаллов. Попробуйте ввести число снова");
                goto c;
            }
            Console.WriteLine("Спасибо, что пользуетесь нашими услугами! Ждём вас снова!");
            Console.ReadKey();
        }
    }
}
