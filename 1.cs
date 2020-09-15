using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            A test = new A();
            
            Console.WriteLine(test.c);
            test.c = 2;
            Console.WriteLine(test.c);
            Console.ReadKey();
        }
    }
    class A
    {
       private float a = 9;
       private float b = 3;
 
        public float c 
    {
        get { return a/=b; }
        set { a=b+value; }     
    }
    }
}
