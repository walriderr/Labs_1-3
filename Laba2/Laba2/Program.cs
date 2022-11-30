using System;

namespace Laba2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ListElement list = new ListElement();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Введите {i + 1}-е целочисленное число:");
                int number = int.Parse(Console.ReadLine());
                list.AddLastNode(number);
            }
            while (true)
            {
                Console.WriteLine("\nВведите:\n1 - для просмотра всех элементов списка" +
                                   "\n2 - для вставки элемента справа" +
                                   "\n3 - для поиска элемента" +
                                   "\n4 - для удаления элемента" +
                                   "\n5 - для очистки списка" +
                                   "\n6 - удаление 0");
                int number;
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        list.Show();
                        break;
                    case 2:
                        Console.WriteLine("Введите число для добавления:");
                        number = int.Parse(Console.ReadLine());
                        list.AddLastNode(number);
                        break;
                    case 3:
                        Console.WriteLine("Введите число для поиска");
                        number = int.Parse(Console.ReadLine());
                        if (list.Search(number) != null)
                            Console.WriteLine(list.Search(number).Value);
                        else
                            Console.WriteLine("Число не найдено");
                        break;
                    case 4:
                        Console.WriteLine("Введите число для удаления");
                        number = int.Parse(Console.ReadLine());
                        if (list.Search(number) != null)
                            list.RemoveNode(list.Search(number));
                        else
                            Console.WriteLine("Число не найдено");
                        break;
                    case 5:
                        list.Clear();
                        break;
                    case 6:
                        list.RemoveZero();
                        break;
                    default:
                        Console.WriteLine("Функционал по данной кнопке не обнаружен");
                        break;
                }
            }
        }
    }
    class ListElementNode
    {
        public int Value { get; set; }
        public ListElementNode Next { get; set; }
        public ListElementNode Prev { get; set; }
        public ListElementNode(int value)
        {
            Value = value;
        }
    }
    class ListElement
    {
        public ListElementNode Head = null;
        public ListElementNode Current = null;
        public ListElementNode Tail = null;
        public int Count;
        public ListElement() { }

        public void AddLastNode(int value)
        {
            ListElementNode node = new ListElementNode(value);
            if (Head == null)
                Head = node;
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
            }
            Tail = node;
            Count++;
        }

        public void Show()
        {
            Console.WriteLine("Вывод всех элементов двунаправленного цикличного линейного списка:");
            ListElementNode tmp = Head;
            while (tmp != null)
            {
                Console.Write(tmp.Value + " ");
                tmp = tmp.Next;
            }
        }
        public ListElementNode Search(int value)
        {
            ListElementNode tmp = Head;
            while (tmp != null)
            {
                if (tmp.Value == value)
                    return tmp;
                tmp = tmp.Next;
            }
            return null;
        }
        public void RemoveNode(ListElementNode target)
        {

            if (Head == target)
                Head = Head.Next;
            else
            {
                ListElementNode tmp = Head;
                while (tmp.Next != target)
                    tmp = tmp.Next;
                tmp.Next = target.Next;
            }
        }
        public void Clear()
        {
            Console.WriteLine("Очистка списка");
            ListElementNode temp;
            while (Head != null)
            {
                temp = Head.Next;
                Head = temp;
            }
        }
        public void RemoveZero()
        {
            ListElementNode tmp = Head;
            while (tmp != null)
            {
                if (tmp.Value == 0)
                    RemoveNode(tmp);

                tmp = tmp.Next;
            }
        }
    }
}

