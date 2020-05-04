using System;

namespace QuestionFive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Question Five!");
            var AC = new AppConfig();
          var ob =   AC.Get<QuestionFive.Class1> ("myClass");
           //  Console.WriteLine(ob);

            var ob2 = AC.Get("myClass1",   new Class1());
            Console.WriteLine(ob2);
        }
    }
}
