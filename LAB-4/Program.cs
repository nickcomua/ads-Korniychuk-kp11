namespace lab
{
    public class Node    
    {
        public Node(int data)
        {
            Data = data;
        }
        public int Data { get; set; }
        public Node? Next { get; set; }

        public Node Copy()
        {
            var n =  new Node(Data);
            n.Next = Next;
            return n;
        }
    }

    public class CircularLinkedList // кольцевой связный список
    {
        Node? head;
        int count; 
        public void AddFirst(int data)
        {
            if(head == null)
            {
                count = 1;
                head = new Node(data);
                head.Next = head;
            }
            else 
            {
                
                Node nod = head.Copy();
                head.Data = data;
                head.Next = nod;
                count++;
            }
        }
        public void AddLast(int data)
        {
            if(head == null)
            {
                count = 1;
                head = new Node(data);
                head.Next = head;
            }
            else
            {
                var last = head;
                for(int i = 0; i < count - 1; i++)
                {
                    last = last!.Next;
                }
                Node n_last = new Node(data);
                last!.Next = n_last;
                n_last.Next = head;
                count++;
            }
        }
        public void AddAtPosition(int data, int pos)
        {
            if(pos == 0)
            {
                AddFirst(data);
            }
            else
            {
                var nth = head;
                for(int i = 0; i < pos - 1; i++)
                {
                    nth = nth!.Next;
                }
                Node neww = new Node(data);
                neww.Next = nth!.Next;
                nth!.Next = neww;
                count++;
            }
        }
        public void DeleteFirst()
        {
            var last = head;
            for(int i = 0; i < count - 1; i++)
            {
                last = last!.Next;
            }
            head = head!.Next;
            last!.Next = head;
            count--;
        }
        public void DeleteLast()
        {
            var last = head;
            for(int i = 0; i < count - 2; i++)
            {
                last = last!.Next;
            }
            last!.Next = head;
            count--;
        }

        public void DeleteAtPosition(int pos)
        {
            if(pos == 0)
            {
                DeleteFirst();
            }
            else
            {
                var nth = head;
                for(int i = 0; i < pos - 1; i++)
                {
                    nth = nth!.Next;
                }
                nth!.Next = nth!.Next.Next;
                count--;
            }
        }
        public void AddFunc(int data)
        {
            int? s = null;
            var nod = head;
            for(int i = 0; i < count; i++)
            {
                if(nod!.Data < 0)
                {
                    s = i;
                }
                nod = nod.Next;
            }
            if(s == null)
            {
                AddLast(data);
            }
            else
            {
                AddAtPosition(data, (int)s+1);
            }
        }
        public void Print()
        {
            var nod = head;
            for(int i = 0; i < count; i++)
            {
                Console.Write($"{nod!.Data} ");
                nod = nod.Next;
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList circularList = new CircularLinkedList();
            Console.WriteLine("Введіть перший елемент");
            circularList.AddFirst(int.Parse(Console.ReadLine()!));
            while (true)
            {
                Console.WriteLine("Список: ");
                circularList.Print();
                Console.WriteLine("Виберіть дію: \n1 AddFirst\n2 AddLast\n3 AddAtPosition\n4 DeleteFirst\n5 DeleteLast\n6 DeletAtPosition\n7 castom func\n");
                switch (Console.ReadLine())
                {
                    case "1": circularList.AddFirst(int.Parse(Console.ReadLine()!)); break;
                    case "2": circularList.AddLast(int.Parse(Console.ReadLine()!)); break;
                    case "3": circularList.AddAtPosition(int.Parse(Console.ReadLine()!), int.Parse(Console.ReadLine()!)); break;
                    case "4": circularList.DeleteFirst(); break;
                    case "5": circularList.DeleteLast(); break;
                    case "6": circularList.DeleteAtPosition(int.Parse(Console.ReadLine()!)); break;
                    case "7": circularList.AddFunc(int.Parse(Console.ReadLine()!)); break;
                    default: Console.WriteLine("Помилка вводу"); break;
                }
            }
        }
    }
}
