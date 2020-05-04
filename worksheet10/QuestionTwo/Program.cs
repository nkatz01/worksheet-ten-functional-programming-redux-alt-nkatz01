

using System;

using LanguageExt;
using static LanguageExt.Prelude;


namespace QuestionTwo
{
    public static class Program
    {



        static void Main(string[] args)
        {

            Console.WriteLine(Parse<DayOfWeek>("Friday"));
            Console.WriteLine(Parse<DayOfWeek>("Freeday"));




        }


        private static Option<T> Parse<T>(string s) where T : struct
            => Enum.TryParse(s, out T t) ? Some(t) : None;



    }
}