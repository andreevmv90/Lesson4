using System;

namespace ArrayManager
{
    class Program
    {
        static void Main(string[] args)
        {
            int size;
            
        start:
            Console.WriteLine("Введите размер массива");

            /*
              
             можно сделать так:
              if (!Int32.TryParse(Console.ReadLine(), out size))
              {
                Console.WriteLine("Введено некорректное значение размера массива");
                goto start;
              }
             
             */

            try
            {
                size = Int32.Parse(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("Введено некорректное значение размера массива");
                goto start;
            }
            if (size == 0)
            {
                Console.WriteLine("Размер массива должен быть больше нуля");
                goto start;
            }

            int[] array = CreateArray(size);

            /*
             * Если бы иметь дело с List<>, то у них есть метод Sort
             */

            Console.WriteLine($"Второй максимальный член массива : {FindSecondMax(array)}");

            Console.ReadKey();
            
        }

        private static int[] CreateArray(int length)
        {
            int[] tempArray = new int[length];
            for (var i = 0; i < length; i++)
            {
                int value;
            repeat:
                Console.WriteLine($"Введите значение члена массива № {i + 1}");
                if (!Int32.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine($"Некорректное значение члена массива № {i + 1}");
                    goto repeat;
                }
                   
                tempArray[i] = value;
            }
            return tempArray;
        }

        private static int FindSecondMax(int[] array)
        {
            int[] arraySorted = new int[array.Length];
            for (var i = 0; i < array.Length; i++)
            {
                arraySorted[i] = array[i];
            }
            Array.Sort(arraySorted);
            Array.Reverse(arraySorted);

            int result = arraySorted[0];
            for (var i = 1; i < arraySorted.Length; i++)
            {
                if (result == arraySorted[i]) continue;
                result = arraySorted[i];
                break;
            }

            return result;
        }
    }
}
