using System;
using System.IO;

public class LinkedListNode
{
    public int Data { get; set; }
    public LinkedListNode Next { get; set; }

    public LinkedListNode(int data)
    {
        Data = data;
        Next = null;
    }
}

public class Program
{
    public static LinkedListNode CreateListFromFile(string filename)
    {
        LinkedListNode head = null;
        LinkedListNode tail = null;

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            int value;
            if (int.TryParse(line, out value))
            {
                LinkedListNode newNode = new LinkedListNode(value);
                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.Next = newNode;
                    tail = newNode;
                }
            }
        }
        return head;
    }

    public static LinkedListNode ReplaceNodes(LinkedListNode head, int m, int n)
    {
        LinkedListNode current = head;
        while (current != null)
        {
            if (current.Data == m)
            {
                current.Data = n;
            }
            current = current.Next;
        }
        return head;
    }

    static void PrintList(LinkedListNode head)
    {
        LinkedListNode current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        LinkedListNode head = null;

        // Зчитуємо список з файлу text.txt
        head = CreateListFromFile("text.txt");

        Console.WriteLine("Input list:");
        PrintList(head);

        // Введення значень m та n
        Console.Write("Enter m: ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        // Заміна входжень елемента m на n
        head = ReplaceNodes(head, m, n);

        // Виведення відредагованого списку
        Console.WriteLine("Output list:");
        PrintList(head);
    }
}
