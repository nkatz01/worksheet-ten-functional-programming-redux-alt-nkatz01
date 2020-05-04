using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionSix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("QuestionSix");
            ISet<int> myHashSet = new HashSet<int>();
            myHashSet.Add(1);
            Console.WriteLine("({0})", string.Join(",", myHashSet)  );
           var result = myHashSet.Select(x => x + 1);
            Console.WriteLine("({0})", string.Join(",", result));
        }
    }

    public static class SetMethod
    {
        /// <summary>
        /// Transforms the contents of a Box, in a user defined way
        /// </summary>
        /// <typeparam name="TA">The type of the thing in the box to start with</typeparam>
        /// <typeparam name="TB">The result type that the transforming function to transform to</typeparam>
        /// <param name="box">The Box that the extension method will work on</param>
        /// <param name="map">User defined way to transform the contents of the box</param>
        /// <returns>The results of the transformation, put back into a box</returns>
        public static ISet<TB> Select<TA, TB>(this ISet<TA> set, Func<TA, TB> map)
        {
            ISet<TB> NewSet = set as ISet<TB>;
            NewSet.Clear();
            // Validate/Check if box is valid(not empty) and if so, run the transformation function on it, otherwise don't
            if (set.Count<1)
            {
                // No, return the empty box
                return new SortedSet<TB>();
            }

            // Extract the item from the Box and run the provided transform function ie run the map() function
            // ie map is the name of the transformation function the user provided.
            foreach (TA item in set)
            {
                TB transformedItem = map(item);
                NewSet.Add(transformedItem);
            }
            return NewSet;
        }
    }
}
