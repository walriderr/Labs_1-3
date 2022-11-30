using System;

namespace Laba3
{
    class DequeNode
    {
        public int Value;
        public DequeNode Prev { get; set; }
        public DequeNode Next { get; set; }

        public DequeNode(int value)
        {
            Value = value;
        }
    }
    class Deque
    {
        DequeNode Head;
        DequeNode Tail;
        int Count;

        public void AddFirstNode(int value)
        {
            DequeNode node = new DequeNode(value);
            DequeNode tmp = Head;
            node.Next = tmp;
            Head = node;
            if (Count == 0)
                Tail = Head;
            else
                tmp.Prev = node;
            Count++;
        }
        public void AddLastNode(int value)
        {
            DequeNode node = new DequeNode(value);
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
        public void RemoveFirstNode()
        {
            if (Count == 0)
                Console.WriteLine("Дек пуст!");
            int number = Head.Value;
            if (Count == 1)
                Head = Tail = null;
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            Count--;
        }
        public void RemoveLastNode()
        {
            if (Count == 0)
                Console.WriteLine("Дек пуст!");
            int number = Head.Value;
            if (Count == 1)
                Head = Tail = null;
            else
            {
                Tail = Tail.Prev;
                Tail.Next = null;
            }
            Count--;
        }
        public void Show()
        {
            Console.WriteLine("Вывод всех элементов двунаправленного списка:");
            DequeNode tmp = Head;
            while (tmp != null)
            {
                Console.Write(tmp.Value + " ");
                tmp = tmp.Next;
            }

            Console.WriteLine();
        }

        public void RemoveNegativeValue()
        {

            DequeNode node = Head;

            while (node != null)
            {
                node = node.Next;
                if (node.Value < 0)
                {
                    if (Count == 1)
                    {
                        Head = Tail = null;
                        Count--;
                    }

                    else if (node == Head)
                    {
                        Head = Head.Next;
                        Head.Prev = null;
                        Count--;
                    }

                    else if (node == Tail)
                    {
                        Tail = Tail.Prev;
                        Tail.Next = null;
                        Count--;
                    }

                    else
                    {
                        node = node.Next;
                        node = node.Prev;
                        node.Next = node;
                        Count--;
                    }
                }
            }
        }

        public void Clear()
        {
            while (Head != null)
                RemoveLastNode();
        }
    }
}