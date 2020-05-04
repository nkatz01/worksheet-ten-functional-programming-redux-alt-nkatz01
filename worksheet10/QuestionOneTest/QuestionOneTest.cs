using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
 
namespace QuestionOneTest
{
    [TestClass]
    public class QuestionOneTest
    {
      



        [TestMethod]
        public void TestCalcBmiNormal()
        {
        
          
              QuestionOne.Program.Bmi bmi = new QuestionOne.Program.Bmi(73, 1.76);
            Assert.AreEqual("Healthy weight", QuestionOne.Program.PrintResults(bmi));

            

        }

        [TestMethod]
        public void TestCalcBmiOverweight()
        {

           
            QuestionOne.Program.Bmi bmi = new QuestionOne.Program.Bmi(73, 1);
            Assert.AreEqual("Overweight", QuestionOne.Program.PrintResults(bmi));

            
 

        }
        [TestMethod]
        public void TestCalcBmiUnderweight()
        {

          
            QuestionOne.Program.Bmi bmi = new QuestionOne.Program.Bmi(50, 1.76);
            Assert.AreEqual("Underweight", QuestionOne.Program.PrintResults(bmi));

            

        }

        [TestMethod]
        public void TestTakeInput()
        {
            Func<string> readW = () => "73"; 
            Func<string> readH = () => "1.76";
           (double,double) tuple = QuestionOne.Program.TestTakeInput(readW, readH);
            Assert.AreEqual(tuple.Item1, 73.0);
            Assert.AreEqual(tuple.Item2, 1.76);

        }

        
    }
}
