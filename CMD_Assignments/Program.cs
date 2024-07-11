using System;
using System.Drawing;

namespace MyApp
{
    internal class Program
    {
        //Question 01
        static void DeleteDuplicate()
        {
            Console.Write("Enter size of an array : ");
            int n=Convert.ToInt32(Console.ReadLine());
            int[] duplicate_array= new int[n];
            Console.WriteLine("Write duplicate Numbers array: ");
            for (int i = 0; i < n; i++)
            {
                duplicate_array[i] = Convert.ToInt32(Console.ReadLine());  
            }

            Console.WriteLine("Array before removing duplicate numbers: ");
            for (int i = 0; i < duplicate_array.Length; i++)
            {
                Console.Write(duplicate_array[i] + " ");
            }

            int[] WithOutDuplicate = new int[n];
            int k = 0;

            for (int i = 0; i < n; i++)
            {
                int j;
                for (j = 0; j < k; j++)
                {
                    if (duplicate_array[i] == WithOutDuplicate[j])
                        break;
                }
                if (j == k)
                {
                    WithOutDuplicate[k] = duplicate_array[i];
                    k++;
                }
            }

            Console.WriteLine("\nArray after removing duplicate numbers: ");
            for (int i = 0; i < k; i++)
            {
                Console.Write(WithOutDuplicate[i] + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine(WithOutDuplicate.Length);
                

        }


        //Question 02
        static void FirstTwoLargeNumbers()
        {
            Console.Write("Enter size of an array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] largeNumber_array = new int[n];
            Console.WriteLine("Write Numbers array: ");
            for (int i = 0; i < n; i++)
            {
                largeNumber_array[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Console.WriteLine("Array before removing duplicate numbers: ");
            for (int i = 0; i < largeNumber_array.Length; i++)
            {
                Console.Write(largeNumber_array[i] + " ");
            }

            int large1 = 0;
            int large2 = 0; 
            int helpingnumber = 0;

            large1 = largeNumber_array[0];
            large2 = largeNumber_array[1];

            if (large1 < large2)
            {
                helpingnumber = large1;
                large1 = large2;
                large2 = helpingnumber;
            }

            for (int i = 2; i < n; i++)
            {
                if (largeNumber_array[i] > large1)
                {
                    large2 = large1;
                    large1 = largeNumber_array[i];
                }
                else if (largeNumber_array[i] > large2 && largeNumber_array[i] != large1)
                {
                    large2 = largeNumber_array[i];
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine($"First largest number: {large1}");
            Console.WriteLine($"Second large number: {large2}");
            

        }
        static void Main(string[] args)
        {
            //DeleteDuplicate();
            //FirstTwoLargeNumbers();
            //Console.WriteLine("Hello World!");
        }
    }
}