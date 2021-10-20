using System;
using System.Linq;

namespace lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int d1, d2, m1, m2, y1, y2, t1 ,t2;
            //var mass11 = new int[] {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            //var mass12 = new int[] {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            //var mass2 = Enumerable.Range(0,12).Select(x =>mass1.Take(x).Sum());
            var mass21 = new int[] {0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334};
            var mass22 = new int[] {0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335};
            Console.WriteLine("Введіть в форматі DD/MM/YY");
            var temp1 = Console.ReadLine().Split("/").Select(int.Parse).ToArray();
            var temp2 = Console.ReadLine().Split("/").Select(int.Parse).ToArray();
            d1 = temp1[0];
            d2 = temp2[0];
            m1 = temp1[1];
            m2 = temp2[1];
            y1 = temp1[2];
            y2 = temp2[2];
            t1 = d1;
            t2 = d2;
            if(y1 % 4 == 0 && y1 % 100 != 0)
                t1 += mass22[m1 - 1]; 
            else t1 += mass21[m1 - 1]; 
            if(y2 % 4 == 0 && y2 % 100 != 0)
                t2 += mass22[m1 - 1]; 
            else t2 += mass21[m1 - 1]; 
            t1 += y1 * 365 + y1 / 4 - y1 / 100;
            t2 += y2 * 365 + y2 / 4 - y2 / 100;
            var vus =Math.Abs(y1 / 4 - y1 / 100 - (y2 / 4 - y2 / 100));
            Console.WriteLine("всього днів");
            Console.WriteLine(Math.Abs(t1 - t2));
            Console.WriteLine("повних років і днів");
            Console.WriteLine(Math.Abs(t2 - t1) / 365);
            Console.WriteLine(Math.Abs(t2 - t1) % 365 - vus);
        }
        
    }
}


