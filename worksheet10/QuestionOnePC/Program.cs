using System;
using System.Collections.Generic;

namespace QuestionOnePC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


    }

    public abstract class Utils
    {
        public abstract List<Person> OrderByDescending(Func<Person, double> func);

        public abstract List<Person> Take(int firstQuarter);

        public abstract double Avarage(List<double> @this); 




    }
}
