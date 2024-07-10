using System;

namespace MyApp
{
    internal class Program
    {
        static string TimeConvert(int num)
        {

            // code goes here 
            //int hours =(num 60)
            int minutes = (num % 60);
            int h = (num - minutes);
            int hours = (h / 60);
            string str = Convert.ToString(hours);
            string str1 = Convert.ToString(minutes);
            //Console.WriteLine($"{hours}:{minutes}");
            string output = ($"{str} :{str1}");

            return output;

        }
        static string PowersofTwo(int num)
        {

            // code goes here 
            int g = (num / 2);
            if ((g % 2) == 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }
            return "0";

        }

        static void Main(string[] args)
        {
            Console.WriteLine(TimeConvert(121));
        }
        

            
        
    }
}
