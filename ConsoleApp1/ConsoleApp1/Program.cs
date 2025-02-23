using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //int num = int.Parse(Console.ReadLine());
            //if (num %2==0) 
            //{
            //    num *= 8;
            //}
            //else
            //{
            //    num *= 9;
            //}
            //Console.WriteLine(num);

            //----------------------------------------------------------------------------------------


            //int num = int.Parse(Console.ReadLine());
            ////int num2 = num / 100;
            //if (num %100==0)
            //{
            //    //num /= 100;
            //    Console.WriteLine(num/100);
            //}
            //else 
            //{
            //    //num /= 100 + 1;
            //    Console.WriteLine(num/100+1);
            //}
            ////Console.WriteLine(num);




            //--------------------------------------------------------------------------------

            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            bool num11 = false,
                num22 = false,
                num33 = false;

            if (num1 % num2 == 0 && num1 % num3 == 0)
            {
                num11 = true;
            }

            if (num2 % num1 == 0 && num2 % num3 == 0)
            {
                num22 = true;
            }

            if (num3 % num1 == 0 && num3 % num2 == 0)
            {
                num33 = true;
            }

            if (num11 && num22 && num33)
            {
                Console.WriteLine("Divide");
            }
            else
            {
                Console.WriteLine("Not Divide");
            }



        }
    }
}
