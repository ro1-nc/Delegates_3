using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_8_3
{
    class Program
    {
        public delegate void Cal(double a, double b);

        public event Cal Cal_notify ;
        static void Main(string[] args)
        {
            double x, y;
            x = 10;
            y = 12;

            
            

            Cal calc = new Cal(Addition);
            calc(x, y);
            
            
            calc = new Cal(Subtraction);
            calc(x, y);



            Console.ReadKey();
        }
        public static void Addition(double x, double y)
        {
            Console.WriteLine("Addition of two numbers is: "+ (x + y));
            Program temp = new Program();
            temp.OnProcessCompleted( x,  y);
        }

        public static void Subtraction(double x, double y)
        {
            Console.WriteLine("Subtraction of two numbers is: "+( x - y));
            Program temp1 = new Program();
            temp1.OnProcessCompleted(x, y);
        }

        protected virtual  void OnProcessCompleted(double x,double y) //protected virtual method
        {
            //if ProcessCompleted is not null then call delegate

            Cal_notify?.Invoke(x,y);
            bl_ProcessCompleted();
        }

        public static void bl_ProcessCompleted()
        {
            Console.WriteLine("Process Completed!");
        }


    }
    
}
