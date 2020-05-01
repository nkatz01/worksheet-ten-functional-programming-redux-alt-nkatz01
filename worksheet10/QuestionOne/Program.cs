using System;


namespace QuestionOne
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Please enter weight in kg: ");
            string w = Console.ReadLine();
            Console.WriteLine("Please enter height in meters: ");
            string h = Console.ReadLine();
            //  Bmi bmi = new Bmi(Convert.ToDouble(w), Convert.ToDouble(h));
            var func = CalcBmi();
            Console.WriteLine(PrintRes(func(Convert.ToDouble(w), Convert.ToDouble(h))));


        }

        public static string PrintRes(double? bmi) => !(bmi < 18.5 || bmi >= 25) ? "Healthy weight" : ((bmi < 18.5 ? "Underweight" : "Overweight"));

        //   public static string PrintRes(Bmi? bmi) => !(bmi.CalcBmi() < 18.5 || bmi.CalcBmi() >= 25) ? "Healthy weight" : ((bmi.CalcBmi() < 18.5 ? "Underweight" : "Overweight"));


        public static Func<double, double, double> CalcBmi()
        {

            return (w, h) => w / Math.Pow(h, 2);





        }



        //   public double CalcBmi() => Weight / (Math.Pow(Height, 2)); //in main





        //public   class Bmi
        // {

        //     public double Weight { get; }
        //     public double Height { get; }

        //     public Bmi(double weight, double height)
        //     {
        //         Weight = weight;
        //         Height = height;


        //     }

        //     public double CalcBmi() => Weight/( Math.Pow(Height, 2));


        // }



    }
}
