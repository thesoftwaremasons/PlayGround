using System;
using System.Reflection;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PlayGround
{
  
     class Program
    {

        static void Main(string[] args)
        {
            var betsy = new Cow
            {
                Name = "Femi",
                Weight = 35,
            };
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
         
            formatter.Serialize(stream, betsy);
            stream.Seek(0, SeekOrigin.Begin);
            var betsyClone= formatter.Deserialize(stream) as Cow;
            Console.WriteLine(betsyClone.Name);
            Console.WriteLine(betsyClone.Weight);

        }
    }


    [Serializable]
    class Cow
    {
        public int Weight { get; set; }
        public string Name { get; set; }
    }




}
