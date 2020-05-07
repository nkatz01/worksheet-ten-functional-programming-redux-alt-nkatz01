using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

using LanguageExt;
using static LanguageExt.Prelude;
using LanguageExt.UnsafeValueAccess;

namespace QuestionSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            ISet<int> myHashSet = new System.Collections.Generic.HashSet<int>();
            myHashSet.Add(1);
            myHashSet.Add(2);
            myHashSet.Add(3);
            Console.WriteLine("({0})", string.Join(",", myHashSet));
            var result = myHashSet.MySelect( x => x.Select(x => x + 1));
            Console.WriteLine(result);
            //  Console.WriteLine("({0})", string.Join(",", result.ValueUnsafe().ToList())); //to print contents of result in case it's a Some.

         


        }

        public static Option<T> Return<T>(T item) => item == null ? None : Some((T)item);

    }

    public static class MapAndOptOnIenum
    {

        public static Option<IEnumerable<TB>> MySelect<TA, TB>(this IEnumerable<TA> Ienum,   Func<IEnumerable<TA>, IEnumerable<TB>> map) 
        {
            var t = Ienum.GetType();
            IEnumerable<TB> NewIEnumerable = Activator.CreateInstance(t) as IEnumerable<TB>;

            if (Ienum.Count() < 1)
            {

               
               return None;
                
            }



            IEnumerable<TB> transformedItems = map(Ienum);

 
            return Option<IEnumerable<TB>>.Some(  transformedItems); 
        }

    }

}
