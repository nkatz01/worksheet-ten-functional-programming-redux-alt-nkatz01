using System;


namespace QuestionOne
{
   public class Program
    {

        static void Main(string[] args)
        {
             

            Console.WriteLine("Please enter weight in kg: ");
            string w = Console.ReadLine();
            Console.WriteLine("Please enter height in meters: ");
            string h = Console.ReadLine();
          
            var func = CalcBmi();
            Console.WriteLine(PrintRes(func(Convert.ToDouble(w), Convert.ToDouble(h))));


        }

        public static string PrintRes(double? bmi) => !(bmi < 18.5 || bmi >= 25) ? "Healthy weight" : ((bmi < 18.5 ? "Underweight" : "Overweight"));

           public static string PrintResults(Bmi bmi) => !(bmi.CalcBmi() < 18.5 || bmi.CalcBmi() >= 25) ? "Healthy weight" : ((bmi.CalcBmi() < 18.5 ? "Underweight" : "Overweight"));


        public static Func<double, double, double> CalcBmi()
        {

            return (w, h) => w / Math.Pow(h, 2);





        }

        public static (double w, double h) TakeInput(string weight, string height)
        {
            
            return (w: Convert.ToDouble(weight), h: Convert.ToDouble(height));
           

        }


      //  Bmi bmi = new Bmi(Convert.ToDouble(w), Convert.ToDouble(h));
      //  var func = CalcBmi();





        public class Bmi
        {

            public double Weight { get; }
            public double Height { get; }

            public Bmi(double weight, double height)
            {
                Weight = weight;
                Height = height;


            }

            public double CalcBmi() => Weight / (Math.Pow(Height, 2));


        }



    }
}

//using Microsoft.VisualStudio.TestTools.UnitTesting;

 

//namespace QuestionOneTest
//{


//    [TestClass]
//    class Program
//    {

//        [TestMethod]
//        public void TestCalcBmi()
//        {

//            //  var tuple = TestTakeInput("73", "1");
//            //  QuestionOne.Program.Bmi bmi = new QuestionOne.Program.Bmi(tuple.w, tuple.h);

//            QuestionOne.Program.Bmi bmi = new QuestionOne.Program.Bmi(73, 1);
//            Assert.AreEqual("Healthy weiht", QuestionOne.Program.PrintResults(bmi));

//        }

//        //  [TestMethod]
//        //public (double w, double h) TestTakeInput(string weight, string height)
//        //{
//        //    return QuestionOne.Program.TakeInput(weight, height);


//        //}




//    }
//}
