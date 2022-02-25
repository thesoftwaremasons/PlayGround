using System;
using System.Reflection;
using System.Linq;

namespace PlayGround
{
    internal class Program
    {

        static void Main(string[] args)
        {

            /*            
             Get all test  attributes
             */
            var testSuites = from d in Assembly.GetExecutingAssembly().GetTypes()
                             where d.GetCustomAttributes().Any(a => a is TestAttribute)
                             select d;

            foreach (Type attributeType in testSuites)
            {
                /*            
             Get all method attributes
             */
                var getTestMethods = from d in attributeType.GetMethods()
                                     where d.GetCustomAttributes().Any(m => m is TestMethodAttribute)
                                     select d;

                /* dynamically instantiate the object*/
                var createInstance = Activator.CreateInstance(attributeType);

                foreach (MethodInfo methodInfo in getTestMethods)
                {
                    /* dynamically call the methods*/
                    methodInfo.Invoke(createInstance, new object[0]);
                }


            }

        }
    }

    sealed class TestAttribute : Attribute
    {

    }

    public class TestMethodAttribute : Attribute
    {

    }
    [TestAttribute]
    public class MyTestAttribute
    {
        public void HelperMethod()
        {

        }
        [TestMethodAttribute]
        public void Method1()
        {
            Console.WriteLine("Method 1 works");
            HelperMethod();
        }
        [TestMethodAttribute]
        public void Method2()
        {
            Console.WriteLine("Method 2 works");
            HelperMethod();
        }
    }





}
