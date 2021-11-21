using System;
using System.Collections.Generic;
using System.Linq;
namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static int[,] rand_gen(int n,int m)
        {
            var ans = new int[n,m];
            var rr = new Random();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    ans[i,j] = rr.Next(201);
                }
            }
            return ans;
        }
        static int[,] test_gen(int n,int m)
        {
            var ans = new int[n,m];
            for(int i = 0,c = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++, c++) 
                {
                    ans[i,j] = c;
                }
            }
            return ans;
        }

        static (int, int, int) tempf1(int i, int j, int n, int m, int vec)
        //      i    j    vec
        {
            switch(vec)
            {
                case 0: if(i == n - 1 - j) return (i, j + 1, 1); else return (i + 1, j, 0);
                case 1: if(j == n - 2 - (n - i - 1) * 2) return(i - 1, j - 1, 2); else return (i, j + 1, 1);
                case 2: if(i / 2 == j) return (i + 1 ,j , 0) ;else return (i - 1, j - 1 ,2);
                default: return(666, 666, 666);
                // let there be magic
            }
        }
        public static void Main(string[] args)
        {
            double s = 0;
            Console.WriteLine("Enter n:");
            int mmin = int.MaxValue, min_i = 0,min_j = 0;
            int n = int.Parse(Console.ReadLine()!);
            var ob = new List<(int,int,int)>();
            var a = new List<(int,int,int)>();
            var mas = new int[n,n];
            ff:
            Console.WriteLine("Plase write 't' to test type and 'r' for random type");
            switch(Console.ReadLine())
                {
                    case "r": mas = rand_gen(n,n); break;
                    case "t": mas = test_gen(n,n); break;
                    default: goto ff; 
                }
            
            Console.WriteLine("Array:");
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write(mas[i,j]+"\t");
                }
                Console.WriteLine();
            }
            int vec = 0;
            // vec: 
            // 0    →

            // 1    ⇂
            // 2   ←
            //      ↑
            for(int tt = 0,i = 1, j = 0; tt < n * (n - 1) / 2; tt++)
            {
                ob.Add((i,j,mas[j,i]));
                if(mas[j,i] < mmin)
                {
                    mmin = mas[j,i];
                    min_i = i;
                    min_j = j;
                }
                (i, j, vec) = tempf1(i, j,n, n, vec);
            }
            Console.WriteLine("\nmin: {0}, min_x: {1}, min_y: {2}", mmin, min_i, min_j);

            for(int tt = 0,i = 0, j = 0; tt < n; tt++)
            {
                ob.Add((i,j,mas[j,i]));
                s += mas[i,j];
                (i, j) = (i+1, j+1);
            }
            s /= 2.0;
            Console.WriteLine("\nsum / 2: {0} \n", s);
            vec = 0;
            for(int tt = 0,i = n - 2, j = n - 1; tt < n * (n - 1) / 2; tt++)
            {
                ob.Add((i,j,mas[j,i]));
                if(mas[j,i] < s)
                {
                    a.Add((i,j,mas[j,i]));
                }
                (i, j, vec) = tempf1(n - 1 - i, n - 1 - j, n, n, vec);
                i = n - 1 - i;
                j = n - 1 - j;
            }           
            Console.WriteLine("Resul elements:");
            if(!a.Any())
            {
                Console.WriteLine("\nNothing");
            }
            else
            foreach(var (x,y,v) in a)
            {
                Console.WriteLine("({0},{1}): {2}",x,y,v);
            }

            Console.WriteLine("\nAll elements");
            foreach(var (x,y,v) in ob)
            {
                Console.WriteLine("({0},{1}): {2}",x,y,v);
            }
        }   
    }
}