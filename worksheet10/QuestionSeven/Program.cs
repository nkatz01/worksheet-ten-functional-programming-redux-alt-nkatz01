using LanguageExt;
using System;
using System.Collections;
using System.Collections.Generic;

namespace QuestionSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            Option<int> optionalInteger = 34; // note we can just assign it straight away
            optionalInteger = Option<int>.Some(34); // save as above. Shown just for demonstration purposes
            optionalInteger = Option<int>.None;
            //  optionalInteger = null; //Options effectively eliminate nulls in your code.


            var result1 = Add5ToIt(optionalInteger);
            

            Console.WriteLine($"The result A is '{result1} ");


        }
        public static IEnumerable<TB> MySelect<TA, TB>(this IEnumerable<TA> Ienum, Func<TA, TB> map)
        {
            var t = Ienum.GetType();
            IEnumerable<TB> NewIEnumerable = Activator.CreateInstance(t) as IEnumerable<TB>;

            if (Ienum.Count() < 1)
            {

                return NewIEnumerable;
            }

            foreach (TA item in Ienum)
            {

                TB transformedItem = map(item);


                NewIEnumerable = NewIEnumerable.Append(transformedItem);

            }

            return NewIEnumerable;
        }
    }
}
