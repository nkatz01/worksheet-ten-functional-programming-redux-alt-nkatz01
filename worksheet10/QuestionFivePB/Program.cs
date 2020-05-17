using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuestionFivePB
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> ls1 = new List<int>{ 3, 4, 5, 6, 7, 8 };

            Console.WriteLine("({0})", string.Join(",", ls1));
            var ls2 = ls1.MyInsertAt(5, 10);
            Console.WriteLine("({0})", string.Join(",", ls2));
            var ls3 = ls2.MyRemoveAt<int>(4);
            Console.WriteLine("({0})", string.Join(",", ls3));
            var ls4 = ls3.MyTakeWhile(x => x <= 5);
            Console.WriteLine("({0})", string.Join(",", ls4));

            var ls5 = ls3.MyDropWhile(x => x <= 5);
            Console.WriteLine("({0})", string.Join(",", ls5));

        }









    }


    public static class IEnumerableExt
    {


        public static IEnumerable<T> MyRemoveAt<T>(this IEnumerable<T> lst, int m) => m == 0 || lst.Count() < 1
                ? lst.Skip(1)
                : lst.Take(1).Concat(lst.Skip(1).MyRemoveAt(m - 1));

        public static IEnumerable<T> MyInsertAt<T>(this IEnumerable<T> lst,  int m, T value) => m == 0 || lst.Count() < 1
               ? lst.Prepend(value)
               : lst.Take(1).Concat(lst.Skip(1).MyInsertAt( m - 1, value));


        public static IEnumerable<T> MyTakeWhile<T>(this IEnumerable<T> lst, Func<T, bool> pred) => !pred(lst.First()) || lst.Count() < 1
            ? new List<T>()
            : lst.Take(1).Concat(lst.Skip(1).MyTakeWhile(pred));

        public static IEnumerable<T> MyDropWhile<T>(this IEnumerable<T> lst, Func<T, bool> pred) =>    lst.Count() < 1 || !pred(lst.First())
            ? lst
              //   : lst.Skip(1).Concat(lst.Skip(1).MyDropWhile(pred));
              : lst.Skip(1).MyDropWhile(pred);


    }

}
