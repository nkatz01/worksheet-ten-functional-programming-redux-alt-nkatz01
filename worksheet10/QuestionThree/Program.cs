using System;
using System.Collections.Immutable;

using System.Linq;
using LanguageExt;
using static LanguageExt.Prelude;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace QuestionThree
{
   public static class Program
    {
        static void Main(string[] args)
        {
            bool isOdd(int i) => i % 2 == 1;
          var something =   new List<int>().Lookup(isOdd);

            Console.WriteLine(something);
            var somethingelse = new List<int>() { 1 }.Lookup(isOdd);
            Console.WriteLine(somethingelse);
            
        }

        private static Option<T> Lookup<T>(this IEnumerable<T> ls, Func<T, bool> predicate)
           => ls.Where(predicate).Count()>0 ? Some(ls.First()) : None;
    }
}
