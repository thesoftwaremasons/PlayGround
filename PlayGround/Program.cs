using System;
using System.Reflection;
using System.Linq;

namespace PlayGround
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var testSuites = from d in Assembly.GetExecutingAssembly().GetTypes()
                             where d.GetCustomAttributes().Any(a => a is TestAttribute)
                             select d;
                             ;
            Console.WriteLine(testSuites?.FirstOrDefault().Name);



            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {

                foreach (Attribute attribute in type.GetCustomAttributes())
                {
                    if (attribute is TestAttribute)
                    {
                        Console.WriteLine($"{type.Name} is a TestAttribute");
                    }
                }
               // 
            }
        }
    }

    sealed class TestAttribute : Attribute
    {

    }
    [TestAttribute]
    public class MyTestAttribute
    {

    }




    
}
