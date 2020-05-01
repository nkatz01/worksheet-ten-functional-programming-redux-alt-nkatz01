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
            Bmi bmi = new Bmi(Convert.ToDouble(w), Convert.ToDouble(h));

            Console.WriteLine(PrintRes(bmi));
            Console.WriteLine(bmi);
        }


        public static string PrintRes(Bmi? bmi) =>  !(bmi.CalcBmi() < 18.5 || bmi.CalcBmi() >= 25) ? "Healthy weight" : ((bmi.CalcBmi() < 18.5 ? "Underweight" : "Overweight"));
    }

   public   class Bmi
    {

        public double Weight { get; }
        public double Height { get; }

        public Bmi(double weight, double height)
        {
            Weight = weight;
            Height = height;


        }

        public double CalcBmi() => Weight/( Math.Pow(Height, 2));

        
    }
}
