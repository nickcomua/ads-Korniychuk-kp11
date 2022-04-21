

namespace lab
{
    class Program
    {
         static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }
                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }
            return array;
        }

        static int[,] Sorted(int[,] array)
        {
            var n = array.GetLength(0);
            var m = array.GetLength(1);
            var tempArray = new int[n, m];
            var len1 = Math.Min(n,m);
            var len2 = Math.Min(Math.Max(n,m)/2, len1);
            var array2 = new int[len1+len2];
            for(int i = 0; i < len1; i++)
                array2[i] = array[n-1-i,i];
            for(int i = 0; i < len2; i++)
                array2[len1+i] = array[n-1-i,m-i-1];
            //Console.WriteLine($"{len1} {len2}");
            //Console.WriteLine(String.Join(" ", array2));
            MergeSort(array2, 0, len1+len2-1);
            //Console.WriteLine(String.Join(" ", array2));
            for(int i = 0; i < len1; i++)
                array[n-1-i,i]=array2[i];
            for(int i = 0; i < len2; i++)
                array[n-1-i,m-i-1]=array2[len1+i];
            return array;
        } 
        static Random rnd = new Random();
        static void Main(string[] args)
        { 
            switch (args[0])
            {
                case "-t": TestCase(); break;
                case "-m": ManualCase(); break;
                case "-r": RandomCase(); break;
                default : break;
            }
            
        }
        static void ManualCase()
        {
            Console.Write("n: ");
            var n = int.Parse(Console.ReadLine()!);
            Console.Write("m: ");
            var m = int.Parse(Console.ReadLine()!);
            var array = new int[n,m];
            Console.WriteLine("enter array:");
            for(int i = 0; i < n; i++)
            {
                var temp = Console.ReadLine()!.Split(" ").Select(int.Parse).ToArray();
                for(int j = 0; j < m; j++)
                    array[i,j] = temp[j];
            }
            printArray(array);
            Sorted(array);
            printArray(array);
        }
        static void RandomCase()
        {
            var n = rnd.Next(10);
            var m = rnd.Next(10);
            var array = new int[n,m];
            for(int i = 0; i < n; i++)
                for(int j = 0; j < m; j++)
                    array[i,j] = rnd.Next(100);
            printArray(array);
            Sorted(array);
            printArray(array);
        }
        static void TestCase()
        {
            int[,] nArr = { {1, 2, 3, 4, 5},
                            {6, 7, 8, 9, 10 },
                            {11,12,13,14,15 }, 
                            {16,17,18,19,20},
                            {21,22,23,24,25}};            
            printArray(nArr);
            Sorted(nArr);
            printArray(nArr);
        }
        static void printArray(int[,] array)
        {
            var n = array.GetLength(0);
            var m = array.GetLength(1);
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                    Console.Write($"{array[i,j]}\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
