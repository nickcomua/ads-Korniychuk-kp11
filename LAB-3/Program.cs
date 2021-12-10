using System;

class Program
{
    //метод обміну елементів
    static void Swap(ref int value1, ref int value2)
    {
        var temp = value1;
        value1 = value2;
        value2 = temp;
    }
    
    //метод генерування наступного кроку
    static int GetNextStep(int s)
    {
        s = s * 1000 / 1247;
        return s > 1 ? s : 1;
    }

    static int[] CombSort(int[] array)
    {
        var arrayLength = array.Length;
        var currentStep = arrayLength - 1;
        
        while (currentStep > 1)
        {
            for (int i = 0; i + currentStep < array.Length; i++)
            {
                if (array[i] > array[i + currentStep])
                {
                    Swap(ref array[i], ref array[i + currentStep]);
                }
            }

            currentStep = GetNextStep(currentStep);
        }
        
        for (var i = 1; i < arrayLength; i++)
        {
            var swapFlag = false;
            for (var j = 0; j < arrayLength - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
            {
                break;
            }
        }

        return array;
    }

    //метод для отримання масиву заповненого випадковими числами
    static int[] GetRandomArray(int length, int minValue, int maxValue)
    {
        var r = new Random();
        var outputArray = new int[length];
        for (var i = 0; i < outputArray.Length; i++)
        {
            outputArray[i] = r.Next(minValue, maxValue);
        }

        return outputArray;
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        var arr = GetRandomArray(n, 0, n*100);
        var splitted = arr.GroupBy(x =>(x%2==0)?(x%n==0):(x%n==1)).ToDictionary(x => x.Key, z => z.ToArray());  
        var to_sort = splitted[true];
        var leave_curent = splitted[false];
        Console.WriteLine("Вхідні дані: {0}", string.Join(", ", arr));
        Console.Write    ("Вихідний масив: {0}, ", string.Join(", ", CombSort(to_sort)));
        Console.WriteLine(string.Join(", ", leave_curent));
        Console.ReadLine();
    }
}