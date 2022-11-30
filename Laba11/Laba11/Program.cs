using System;

namespace Laba11
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();

            Console.WriteLine("Введите числа:");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1})");
                list.AddElement(ref list._current, Convert.ToInt32(Console.ReadLine()));
                Console.Write("\n");
            }
            while (true)
            {
                Console.WriteLine("\nВведите:\n1) - для просмотра всех элементов списка" +
                                    "\n2) - для вставки элемента справа" +
                                    "\n3) - для поиска элемента" +
                                    "\n4) - для удаления элемента" +
                                    "\n5) - для очистки списка" + 
                                    "\n6) - для ввода числа справа от первого"+
                                    "\n7) - для удаления чисел стоящих на нечетных местах");
                int number;
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        list.ShowList();
                        break;

                    case 2:
                        Console.WriteLine("Введите число для добавления:");
                        number = int.Parse(Console.ReadLine());
                        list.AddElement(ref list._current, number);
                        break;

                    case 3:
                        Console.WriteLine("Введите число для поиска");
                        number = int.Parse(Console.ReadLine());
                        if (list.SearchElement(number) != null)
                            Console.WriteLine(list.SearchElement(number).Value);
                        else
                            Console.WriteLine("Число не найдено");
                        break;

                    case 4:
                        Console.WriteLine("Введите число для удаления");
                        number = int.Parse(Console.ReadLine());
                        if (list.SearchElement(number) != null)
                            list.RemoveElem(list.SearchElement(number));
                        else
                            Console.WriteLine("Число не найдено");
                        break;
                    case 5:
                        list.ClearList();
                        break;
                    
                    case 6:
                        Console.WriteLine("Введите число для ввода правее первого");
                        number = int.Parse(Console.ReadLine());
                        list.AddRightElem(number);
                        break;

                    case 7:
                        list.RemoveOddElements();
                        break;
                }
            }
        }
    }

    class ListElem
    {
        public int Value;
        public ListElem Next;
        public ListElem(ListElem next, int value)
        {
            Next = next;
            Value = value;
        }
    }
    class List
    {
        public ListElem _head = null;
        public ListElem _current = null;
        public List() { }

        public void AddElementFirst(int value)
        {
            ListElem temp = new ListElem(null, value);
        
            if(_head == null)
            {
                _head = temp;
            }
            else
            {
                temp.Next = _head;
                _head = temp;
            }
        }
        
        public void AddElement(ref ListElem current, int value)
        {
            if (_head == null)
            {
                AddElementFirst(value);
                _current = _head;
            }
            else
            {
                ListElem temp = new ListElem(null, value);
                temp.Next = _current.Next;
                _current.Next = temp;
                _current = temp;
            }
            current = _current;
        }

        public void ShowList()
        {
            Console.WriteLine("Список: ");

            ListElem temp = _head;
            while (temp != null)
            {
                Console.Write(temp.Value + " ");
                temp = temp.Next;
            }
        }
        public void AddRightElem(int value)
        {
            if (_head == null)
            {
                AddElementFirst(value);
                _current = _head;
            }
            else
            {
                ListElem node = new ListElem(null, value);
                ListElem temp = _head.Next;
                _head.Next = node;
                node.Next = temp;
            }
        }

        public ListElem SearchElement(int value)
        {
            ListElem temp = _head;
            while (temp != null)
            {
                if (temp.Value == value)
                    return temp;
                temp = temp.Next;
            }
            return null;
        }

        public void RemoveOddElements()
        {
            ListElem temp = _head;
            int localCount = 1; 

            bool isEven;
            while (temp != null)
            {
                isEven = localCount % 2 == 0;
                if (isEven == false)
                {
                    RemoveElem(temp);
                }            
                localCount++;
                temp = temp.Next;
            }
        }
        public void RemoveElem(ListElem del)
        {
            if (_head == del)
                _head = _head.Next;
            else
            {
                ListElem temp = _head;
                while (temp.Next != del)
                    temp = temp.Next;
                temp.Next = del.Next;
            }
        }

        public void ClearList()
        {
            ListElem temp;
            while (_head != null)
            {
                temp = _head.Next;
                _head = temp;
            }
        }
    }
}
