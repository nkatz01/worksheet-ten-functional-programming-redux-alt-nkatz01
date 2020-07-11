using System;

namespace QuestionOnePD
{
    class Program
    {
        static void Main(string[] args)
        {
            //var remainderPos1 = RemainderAlsoForNegativesCurry(Mod)(3)(17);
            //var remainderNeg1 = RemainderAlsoForNegativesCurry(Mod)(-3)(17);
            //var remainderPos2 = RemainderAlsoForNegativesCurry(Mod)(3)(-17);
            //var remainderNeg2 = RemainderAlsoForNegativesCurry(Mod)(-3)(-17);
            //Console.WriteLine(remainderPos1);//2
            //Console.WriteLine(remainderNeg1);//2
            //Console.WriteLine(remainderPos2);//-2
            //Console.WriteLine(remainderNeg2);//-2

            var ParRemainderPos1 = RemainderAlsoForNegatives(Mod,3)(17);
            var ParRemainderNeg1 = RemainderAlsoForNegatives(Mod,-3)(17);
            var ParRemainderPos2 = RemainderAlsoForNegatives(Mod,3)(-17);
            var ParRemainderNeg2 = RemainderAlsoForNegatives(Mod,-3)(-17);
            Console.WriteLine(ParRemainderPos1);//2
            Console.WriteLine(ParRemainderNeg1);//2
            Console.WriteLine(ParRemainderPos2);//-2
            Console.WriteLine(ParRemainderNeg2);//-2
           //------------------------------------------------up to here q1
            var By5RemainderPos1 = ModAnyIntBy5(17);           
            var By5RemainderPos2 = ModAnyIntBy5(-17);
            Console.WriteLine(ParRemainderPos1);//2
            Console.WriteLine(ParRemainderPos2);//-2
            //------------------------------------------------up to here q4
        }


        //static Func<int, Func<int, int>> RemainderAlsoForNegativesCurry(Func<int, int, int> calcRemaind) =>
        //  (divisor)   => (dividend) => dividend >= 0 ? calcRemaind(Math.Abs(dividend), Math.Abs(divisor)) :  -calcRemaind(Math.Abs(dividend), Math.Abs(divisor));
        static Func<int, int> RemainderAlsoForNegatives(Func<int, int, int> calcRemaind, int divisor) =>
         (dividend) =>
         {
             int res = calcRemaind(Math.Abs(dividend), Math.Abs(divisor)) ;
             return dividend >= 0 ? res  : -res;
         };

        static Func<int, int, int> Mod = (dividend, divisor) => (dividend-divisor)<= 0 ? dividend : Mod(dividend-divisor, divisor);

        static Func<T1, T3> ApplyR0<T1, T2, T3>(Func<T1, T2, T3> func) => (t1) => { T2 t2 =  default(T2); return func(t1, t2); };//-------------------------q2
        static Func<T1, T3> ApplyR1<T1, T2, T3>(Func<T1, T2, T3> func , T2 t2) => (t1) =>      func(t1, t2);//----------------------------------------------q3
        static Func<T2, Func<T1, T3>> ApplyR2<T1, T2, T3>(Func<T1, T2, T3> func) => (t2) => (t1) => func(t1, t2);//-----------------------------------------q3
        static Func<T3, Func<T1, Func<T2, T4>>> ApplyR2<T1, T2, T3,T4>(Func<T1, T2, T3, T4> func) => (t3) => (t1) => (t2) => func(t1, t2, t3);//------------q5
        static int ModAnyIntBy5(int dividend) => ApplyR2(Mod)(5)(dividend);



    }
}
