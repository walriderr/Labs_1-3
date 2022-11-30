using System;

namespace Laba3
{
    class Program
    {
        public static Deque deque = new Deque();

        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа:");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1}): ");
                int number = Convert.ToInt32(Console.ReadLine());
                deque.AddLastNode(number);

            }

            while (true)
            {
                Console.WriteLine("1) просмотр всех элементов дэка\n" +
                                  "2) вставка элемента в начало\n" +
                                  "3) вставка элемента в конец\n" +
                                  "4) удаление элемента в начале\n" +
                                  "5) удаление элемента в конце\n" +
                                  "6) очистка дека\n" +
                                  "7) удаление отрицательных чисел\n");

                Console.Write("Введите значение: ");

                int answer = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (answer)
                {
                    default:
                        Console.WriteLine("Такого варианта ответа нет!");

                        break;

                    case 1:
                        deque.Show();

                        break;

                    case 2:
                        Console.Write("Введите число: ");

                        deque.AddFirstNode(Convert.ToInt32(Console.ReadLine()));

                        Console.WriteLine("Число добавлено!\n");

                        break;

                    case 3:
                        Console.Write("Введите число: ");

                        deque.AddLastNode(Convert.ToInt32(Console.ReadLine()));

                        Console.WriteLine("Число добавлено!\n");

                        break;

                    case 4:
                        deque.RemoveFirstNode();

                        Console.WriteLine("Элемент удалён!");

                        break;

                    case 5:
                        deque.RemoveLastNode();

                        Console.WriteLine("Элемент удалён!");

                        break;

                    case 6:
                        deque.Clear();

                        Console.WriteLine("Очищен!");

                        break;

                    case 7:
                        deque.RemoveNegativeValue();

                        Console.WriteLine("Отрицательные числа удалены!");

                        break;

                }

            }
        }
    }
}



