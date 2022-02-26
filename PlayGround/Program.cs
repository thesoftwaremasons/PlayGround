using System;
using System.Reflection;
using System.Linq;

namespace PlayGround
{
    [Me("25","Femi")]
     class Program
    {

        static void Main(string[] args)
        {

             typeof(Program).GetCustomAttributes();

        }
    }


    class MeAttribute : Attribute
    {
        public MeAttribute(string value, string secondValue)
        {
            Console.WriteLine("I Work");
            Console.WriteLine(value);
            Console.WriteLine(secondValue);
        }
    }




}
