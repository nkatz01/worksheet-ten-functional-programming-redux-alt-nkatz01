using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace QuestionSix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("QuestionSix");
            ISet<int> myHashSet = new HashSet<int>();
            myHashSet.Add(1);
            myHashSet.Add(2);
            myHashSet.Add(3);
            Console.WriteLine("({0})", string.Join(",", myHashSet));
            var result = myHashSet.MySelect(x => x + 1);
            Console.WriteLine("({0})", string.Join(",", result));
            Console.WriteLine();

            IDictionary<string, int> myDict = new Dictionary<string, int>();
            myDict.Add("one", 1);
            myDict.Add("two", 2);
            myDict.Add("three", 3);
            Console.WriteLine("({0})", string.Join(",", myDict));
            //var result2 = myDict.MySelect1<string, int,string ,int>((pair) =>    new KeyValuePair<string,int>("number " + pair.Key  , pair.Value + 1));
            //Console.WriteLine("({0})", string.Join(",", result2));

            Console.WriteLine();
            var result3 = myDict.MySelect<KeyValuePair<string, int>, KeyValuePair<string, int>>((pair) => new KeyValuePair<string, int>("number " + pair.Key, pair.Value + 1));
            Console.WriteLine("({0})", string.Join(",", result3));
        }
    }

    //public static class DictMethod
    //{

    //    public static IEnumerable<KeyValuePair<TC, TD>> MySelect1<  TA, TB ,TC,TD>(this IEnumerable<KeyValuePair<TA,TB>> set, Func<KeyValuePair<TA, TB> , KeyValuePair<TC, TD>> map)
    //    {
    //        var t = set.GetType();
    //        IEnumerable<KeyValuePair<TC, TD>> NewSet = Activator.CreateInstance(t) as IEnumerable<KeyValuePair<TC, TD>>;

    //        if (set.Count() < 1)
    //        {

    //            return NewSet;
    //        }

    //        foreach (KeyValuePair<TA, TB> item in set)
    //        {
    //            KeyValuePair<TC, TD> transformedItem = map(item);
    //            NewSet = NewSet.Append(transformedItem);
    //        }
    //        return NewSet;
    //    }
    //}



    public static class SetMethod
    {

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
               

                NewIEnumerable = NewIEnumerable.Append( transformedItem);
               
            }
           
            return NewIEnumerable;
        }
    }
}
