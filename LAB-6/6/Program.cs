


class Program
{
    struct Queve{
        public int head;
        public int tail;
        private int[] array;
        public int size;
        public int count;
        public Queve(){
            this.size = 3;
            array = new int[size];
            head = 0;
            tail = 0;
            count = 0;
        }
        public void Enqueue(int value){
            if(count == size){
                Console.WriteLine("Queue is full");
                int[] newArray = new int[size*2];
                for(int i = 0; i < size; i++){
                    newArray[i] = array[head];
                    head = (head + 1) % size;
                }
                head = 0;
                tail = size;
                size *= 2;
                array = newArray;
            }
            array[tail] = value;
            tail = (tail + 1) % size;
            count++;
        }
        public int? Dequeue(){
            if(count == 0){
                Console.WriteLine("Queue is empty");
                return null;
            }
            int value = array[head];
            head = (head + 1) % size;
            count--;
            return value;
        }
        public void Print(){
            if(count == 0){
                Console.WriteLine("Queue is empty");
                return;
            }
            Console.Write("Queue: ");
            for(int i = head; i < head + count; i++){
                Console.Write(array[i % size] + " ");
            }
            Console.WriteLine();
        }

    }
    static Queve queve = new Queve();
    static void run(int n)
    {
        if(n == 0){
            for(int i = 0; i < 3 ; i++){
                int? value = queve.Dequeue();
                if(value != null){
                    Console.WriteLine(value);
                }
                else Environment.Exit(0);
            }
        }
        else{
            queve.Enqueue(n);
        }
        queve.Print();
    }
    static void ManualFun()
    {
        while(true)
        {
            Console.Write("Введіть число: ");
            string numba = Console.ReadLine()!; 
            int n;
            bool isNumber = int.TryParse(numba, out n);
            if(isNumber){
                run(n);
            }
            else{
                Console.WriteLine("Невірний формат");
            }
        }
    }
    static void TestFun()
    {
        for(int i = 1; i < 10; i++){
            Console.WriteLine($"вводимо: {i}");
            run(i);
        }
        Console.WriteLine($"вводимо: {0}");
        run(0);
        Console.WriteLine($"вводимо: {0}");
        run(0);
        for(int i = 0; i < 3; i++){
            Console.WriteLine($"вводимо: {i}");
            run(i);
        }
        Console.WriteLine($"вводимо: {0}");
        run(0);
        Console.WriteLine($"вводимо: {0}");
        run(0);
    }
    static void Main(string[] args)
    {
        
        while(true)
        {
            Console.WriteLine("Напишіть 1 щоб запустити тестовий режим або 2 щоб запустити програму в ручному режимі");
            switch(Console.ReadLine())
            {
                case "1": TestFun()  ;return;
                case "2": ManualFun();return;
                default: Console.WriteLine("Невірний ввід");break;
            }
        }   
    }
}