using System;


namespace QuestionOne
{
   public class Program
    {

        static void Main(string[] args)
        {


            
            Func<string> read = () => Console.ReadLine();
            var tuple = TestTakeInput(read, read);
            var func = CalcBmi();
            Console.WriteLine(PrintRes(func(tuple.w, tuple.h)));


        }

        

        public static string PrintRes(double bmi) => !(bmi < 18.5 || bmi >= 25) ? "Healthy weight" : ((bmi < 18.5 ? "Underweight" : "Overweight"));

           public static string PrintResults(Bmi bmi) => !(bmi.CalcBmi() < 18.5 || bmi.CalcBmi() >= 25) ? "Healthy weight" : ((bmi.CalcBmi() < 18.5 ? "Underweight" : "Overweight"));


        public static Func<double, double, double> CalcBmi()
        {

            return (w, h) => w / Math.Pow(h, 2);





        }

      

        public static (double w, double h) TestTakeInput(Func<string> funcW, Func<string> funcH)
        {
            Console.WriteLine("Please enter weight in kg: ");
            string weight = funcW();
            Console.WriteLine("Please enter height in meters: ");
            string height = funcH();

            return (w: Convert.ToDouble(weight), h: Convert.ToDouble(height));


        }


        





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

 
