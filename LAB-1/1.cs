using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double z = double.Parse(Console.ReadLine());
            double a,b;
            if(z == 0)
            {
                Console.WriteLine("BED INPUT");
                return;
            }
            a = Math.Cos(x + (  x  *  y ) / z);
            b = x*x*x / Math.Cos(a);
            Console.WriteLine($"a = {a}\nb = {b}");
        }
    }
}
