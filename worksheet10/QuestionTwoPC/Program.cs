using System;
using System.Collections.Generic;
 
using LanguageExt;
using LanguageExt.SomeHelp;
using static LanguageExt.Prelude;

namespace QuestionTwoPC
{
    class Program
    {
        static void Main(string[] args)
        {
          
       Console.WriteLine(Utils.retStrOpt1().Bind(i => Utils.retStrOpt2(i)));   // P1 of Q4   
            Console.WriteLine(Utils.retEither().Bind(i => Utils.retStrOpt2(i)));  // P2 of Q4 

        }


    }



    public static class Utils 
    {
        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T2, T3> f, Func<T1, T2> g) => x => f(g(x)); //Q2

        public static Option<T> ToOption<L, T>(LanguageExt.Either<L, T> either) => either.Map(i => Some(i)).Match(v => v, l => None); //P1 of Q3

        public static Either<QuestionTwoPC.Utils.L, T> ToEither<L, T>(Option<T> opt) => opt.ToEither<QuestionTwoPC.Utils.L>(   GetLeft());//P2 of Q3

        public static Option<string> retStrOpt1() => Some("a");
        public static Option<string> retStrOpt2(string a) => Some(a.ToUpper());
        public static Either<QuestionTwoPC.Utils.L, string> TestConvertOpt(string a) =>  ToEither<QuestionTwoPC.Utils.L,string>(a.ToUpper());
        public static Either<L, string> retEither() => "a";

        public static Option<T> Bind<T,R>(this Either<L, R> either, Func<R, Option<T>> func) => either.Map(i => func(i)).Match(v => v, l => None);

    

        public static Either<L, R> Safely<L, R>(Func<R> right, Func<Exception, R> wrong) {

            var res = Try( () => right());
            return res.Match(Succ: v => v, Fail: wrong(new Exception()));

            

        }

      

        public static Exceptional<T> MyTry<T>(Func<T> func)
        {
            var res = Try(() => func());
           var result = res.Match(
                Succ: v => new Exceptional<T>(v),
                Fail: result => new Exceptional<T>( new Exception()));
            return result; 
        }









        public static  L GetLeft() => new L();
        

        public class L
        {

        }
        public class Exceptional<T>
        {
            public Either<T,Exception> Result { get; }

            public Exceptional(Either<T, Exception> res)
            {
                  Result = res;
               

            }
        }
      
    }

  


}
