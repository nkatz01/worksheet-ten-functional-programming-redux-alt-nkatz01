using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuestionOneTest
{
    [TestClass]
    public class UnitTest1
    {
      

        [TestMethod]
        public void TestCalcBmiNormal()
        {

            var tuple = TestTakeInput("73", "1.76");
              QuestionOne.Program.Bmi bmi = new QuestionOne.Program.Bmi(tuple.w, tuple.h);
            Assert.AreEqual("Healthy weight", QuestionOne.Program.PrintResults(bmi));

            

        }

        [TestMethod]
        public void TestCalcBmiOverweight()
        {

            var tuple = TestTakeInput("73", "1");
            QuestionOne.Program.Bmi bmi = new QuestionOne.Program.Bmi(tuple.w, tuple.h);
            Assert.AreEqual("Overweight", QuestionOne.Program.PrintResults(bmi));

            
 

        }
        [TestMethod]
        public void TestCalcBmiUnderweight()
        {

            var tuple = TestTakeInput("50", "1.76");
            QuestionOne.Program.Bmi bmi = new QuestionOne.Program.Bmi(tuple.w, tuple.h);
            Assert.AreEqual("Underweight", QuestionOne.Program.PrintResults(bmi));

            

        }

        [TestMethod]
        public (double w, double h) TestTakeInput(string weight, string height)
        {
            return QuestionOne.Program.TakeInput(weight, height);


        }
    }
}
