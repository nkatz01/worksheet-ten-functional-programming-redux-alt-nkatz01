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
            // var ls1 = ls.InsertAt(0, 3).InsertAt(1, 4).InsertAt(2, 5).InsertAt(3, 6).InsertAt(4, 7).InsertAt(5, 8);
            // Console.WriteLine($"List: {ls1}");
            //  var ls2 = ls1.InsertAt(5, 10);
            // Console.WriteLine($"List: {ls2}");
            var ls3 = ls1.RemoveAt<int>(4);
            Console.WriteLine("({0})", string.Join(",", ls3));
            //var ls4 = ls3.TakeWhile(x => x <= 5);
            //Console.WriteLine($"List: {ls4}");
            //var ls5 = ls3.DropWhile(x => x <= 5);
            //Console.WriteLine($"List: {ls5}");

        }









    }


    public static class IEnumerableExt
    {


        public static IEnumerable<T> RemoveAt<T>(this IEnumerable<T> lst, int m)
        {

            //    var t = lst.GetType();
            // IEnumerable<T> NewIEnumerable = Activator.CreateInstance(t) as IEnumerable<T>;
            return m == 0 || lst.Count() < 1
                ? lst.Skip(1)
                : lst.Take(1).Concat(lst.Skip(1).RemoveAt(m - 1));


        }

    }

}
