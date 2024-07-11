using System;

namespace MyApp
{
    internal class Program
    {
        //Question 01
        static void DeleteDuplicate()
        {
            Console.Write("Enter size of an array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] duplicate_array = new int[n];
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


        //Question 03
        static void MoveZeroToEnd()
        {
            Console.Write("Enter size of an array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] MoveZeroarray_array = new int[n];
            Console.WriteLine("Write Numbers array: ");
            for (int i = 0; i < n; i++)
            {
                MoveZeroarray_array[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Console.WriteLine("Array before removing duplicate numbers: ");
            for (int i = 0; i < MoveZeroarray_array.Length; i++)
            {
                Console.Write(MoveZeroarray_array[i] + " ");
            }

            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (MoveZeroarray_array[i] != 0)
                    MoveZeroarray_array[k++] = MoveZeroarray_array[i];
            }
            while (k < n)
            {
                MoveZeroarray_array[k++] = 0;
            }

            Console.WriteLine("\nAfter Moving Zeros to End Array: ");
            for (int i = 0; i < k; i++)
            {
                Console.Write(MoveZeroarray_array[i] + " ");
            }



        }


        //Question 04
        //static void FirstNonRepeatingCharacter()
        //{

        //    Console.Write("Enter size of an array : ");
        //    string n = (Console.ReadLine());
        //    string[] NonRepeatingCharacter_array = new string[n.Length];
        //    Console.WriteLine("Write Numbers array: ");
        //    for (int i = 0; i < n.Length; i++)
        //    {
        //        NonRepeatingCharacter_array[i] = Convert.ToInt32(Console.ReadLine());
        //    }

        //    //Console.WriteLine("Array before removing duplicate numbers: ");
        //    for (int i = 0; i < NonRepeatingCharacter_array.Length; i++)
        //    {
        //        Console.Write(NonRepeatingCharacter_array[i] + " ");
        //    }

        //    for (int i = 0; i < NonRepeatingCharacter_array.Length; ++i)
        //    {

        //        if (NonRepeatingCharacter_array[i] == NonRepeatingCharacter_array[i + 1])
        //        {
        //            Console.WriteLine( NonRepeatingCharacter_array[i]);
        //        }



        //    }


        //}

        //Question 05
        static void SortedArray()
        {
            Console.Write("Enter size of first array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] Sorted_array1 = new int[n];
            Console.WriteLine("Write Numbers array: ");
            for (int i = 0; i < n; i++)
            {
                Sorted_array1[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Console.WriteLine("Array before removing duplicate numbers: ");
            for (int i = 0; i < Sorted_array1.Length; i++)
            {
                Console.Write(Sorted_array1[i] + " ");
            }

            Console.Write("\nEnter size of second array : ");
            int m = Convert.ToInt32(Console.ReadLine());
            int[] Sorted_array2 = new int[m];
            Console.WriteLine("Write Numbers array: ");
            for (int i = 0; i < m; i++)
            {
                Sorted_array2[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Console.WriteLine("Array before removing duplicate numbers: ");
            for (int i = 0; i < Sorted_array2.Length; i++)
            {
                Console.Write(Sorted_array2[i] + " ");
            }

            int[] Sorted_Array = new int[n + m];
            int x = 0, y = 0, k = 0;

            while (x < n && y < m)
            {

                if (Sorted_array1[x] < Sorted_array2[y])
                    Sorted_Array[k++] = Sorted_array1[x++];
                else
                    Sorted_Array[k++] = Sorted_array2[y++];
            }

            while (x < n)
            {
                Sorted_Array[k++] = Sorted_array1[x++];
            }

            while (y < m)
            {
                Sorted_Array[k++] = Sorted_array2[y++];
            }

            Console.WriteLine("\nArray after merging: ");
            for (int i = 0; i < Sorted_Array.Length; i++)
            {
                Console.Write(Sorted_Array[i] + " ");
            }



        }

        //Question 06
        static void DistinctNumber()
        {
            Console.Write("Enter size of first array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] distinct_Number = new int[n];
            Console.WriteLine("Write Numbers array: ");
            for (int i = 0; i < n; i++)
            {
                distinct_Number[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Console.WriteLine("Array before removing duplicate numbers: ");
            for (int i = 0; i < distinct_Number.Length; i++)
            {
                Console.Write(distinct_Number[i] + " ");
            }

            int sum = 0;
            for (int i = 0; i < distinct_Number.Length; i++)
            {
                sum += distinct_Number[i];
            }
            int formulae = ((n + 1) * (n + 2)) / 2;
            int final_result = formulae - sum;
            Console.WriteLine($"\nDistinct Number: {final_result}");
        }

        //Question 07
        static void ArmStrongNumber()
        {
            Console.Write("Enter value of Number : ");
            int number = Convert.ToInt32(Console.ReadLine());
            int original = number;
            int result = 0;
            while (original != 0)
            {
                int remainder = original % 10;
                result = result + (remainder * remainder * remainder);
                original = original / 10;
            }
            if (result == number)
            {
                Console.WriteLine("Given Number is ArmStrong Number");
            }
            else
            {
                Console.WriteLine("Given Number is not ArmStrong Number");
            }
        }


        //Question 08


        static void LongestPrefix()
        {
            Console.Write("Enter size of first array : ");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] longest_prefix = new string[n];
            Console.WriteLine("Write string array: ");
            for (int i = 0; i < n; i++)
            {
                longest_prefix[i] = Console.ReadLine();
            }

            //Console.WriteLine("Array before removing duplicate numbers: ");
            for (int i = 0; i < longest_prefix.Length; i++)
            {
                Console.Write(longest_prefix[i] + " ");
            }
            string result = "";
            for (int i = 0; i < longest_prefix[0].Length; i++) {

                for (int j = 0; j < longest_prefix.Length; j++) {
                    if (longest_prefix[j][i] == longest_prefix[0][i])
                    {
                        Console.WriteLine($"\nCommon Prefix {longest_prefix[0]}"); 
                    }
                    else {
                        Console.WriteLine("No Common Prefix");
                    
                    }
                }
            }

        }

        //QUESTION 09
        static void FibonacciSeries()
        {
            Console.Write("Enter value of terms : ");
            int terms = Convert.ToInt32(Console.ReadLine());
            int term1 = 0;
            int term2 = 1;
            int nextTerm = 0;

            for (int i = 1; i <= terms; ++i)
            {
                if (i == 1)
                {
                    Console.Write($"{term1} ,");
                    continue;
                }
                if (i == 2)
                {
                    Console.Write($"{term2} ,");
                    continue;
                }
                nextTerm = term1 + term2;
                term1 = term2;
                term2 = nextTerm;
                Console.Write($"{nextTerm} ,");

            }
        }

        //Question 10

        static void Main(string[] args)
        {
            //DeleteDuplicate();
            //FirstTwoLargeNumbers();
            //MoveZeroToEnd();
            //SortedArray();
            //DistinctNumber();
            //ArmStrongNumber();
            LongestPrefix();
            //FibonacciSeries();
            //Console.WriteLine("Hello World!");
        }
    }
}



