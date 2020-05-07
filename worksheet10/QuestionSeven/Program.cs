using LanguageExt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuestionSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            ISet<int> myHashSet = new HashSet<int>();
            myHashSet.Add(1);
            myHashSet.Add(2);
            myHashSet.Add(3);
            Console.WriteLine("({0})", string.Join(",", myHashSet));
            var result = myHashSet.MySelect( x => x + 1);
            Console.WriteLine("({0})", string.Join(",", result));
            Console.WriteLine();


        }
        public static Option<IEnumerable<TB>> MySelect<TA, TB>(this IEnumerable<TA> Ienum, Func<IEnumerable<TB>, Option<IEnumerable<TB>>> Return, Func<TA, TB> map)
        {
            var t = Ienum.GetType();
            IEnumerable<TB> NewIEnumerable = Activator.CreateInstance(t) as IEnumerable<TB>;

            if (Ienum.Count() < 1)
            {

                var none =  Return(NewIEnumerable);
                return none;
            }

            foreach (TA item in Ienum)
            {

                TB transformedItem = map(item);
              

                NewIEnumerable = NewIEnumerable.Append(transformedItem);

            }
            var NewIEnumerableOpt = Return(NewIEnumerable);
            return NewIEnumerableOpt;
        }
    }
}
