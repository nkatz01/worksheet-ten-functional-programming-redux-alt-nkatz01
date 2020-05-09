using LanguageExt;
using LanguageExt.SomeHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using static LanguageExt.Prelude;

namespace QuestionNine
{
    static class Program
    {
        static void Main(string[] args)
        {
            Employee personA = new Employee();
            personA.ChangeJoinedOn(DateTime.Today);
            personA.ChangeLeftOn(DateTime.Today.AddYears(2));//joined today, leaving in 2 yrs  
            personA.Id = "person1";

            WorkPermit WorkPermit = new WorkPermit();
            WorkPermit.Number = "1111";
            WorkPermit.Expiry = DateTime.Today.AddYears(2);
            personA.WorkPermit = WorkPermit;
            Console.WriteLine(personA.WorkPermit);

            Employee personB = new Employee();
            personB.ChangeJoinedOn(DateTime.Today.AddYears(-1));
            personB.ChangeLeftOn(DateTime.Today.AddDays(-1)); //joined last yr left yesterday
            personB.Id = "person2";
            WorkPermit = new WorkPermit();
            WorkPermit.Number = "2222";
            WorkPermit.Expiry = DateTime.Today.AddYears(1);
            personB.WorkPermit = WorkPermit;

            Employee personC = new Employee();
            personC.ChangeJoinedOn(DateTime.Today.AddYears(-2));
            personC.ChangeLeftOn(DateTime.Today.AddDays(-1)); //joined 2 yrs ago, left yesterday
            personC.Id = "person3";
            WorkPermit = new WorkPermit();
            WorkPermit.Number = "3333";
            WorkPermit.Expiry = DateTime.Today.AddYears(-2);
            personC.WorkPermit = WorkPermit;

            Console.WriteLine($"{personA.Id} is employed from {personA.JoinedOn} to {personA.LeftOn}");
            Console.WriteLine($"{personB.Id} is employed from {personB.JoinedOn} to {personB.LeftOn}");
            Console.WriteLine($"{personC.Id} is employed from {personC.JoinedOn} to {personC.LeftOn}");

            IEnumerable<Employee> lst = new List<Employee> { personA, personB, personC };
            Console.WriteLine(AverageYearsWorkedAtTheCompany(lst));



        }

        static double AverageYearsWorkedAtTheCompany(IEnumerable<Employee> employees)
        {

            var employeeList = employees.Map(x => x.LeftOn.CompareTo(DateTime.Today) == -1 ? Some((x.LeftOn - x.JoinedOn).TotalDays) : None);
            double numberOfTotalDaysAllEmps = 0;
            int numberOfRetiredEmps = 0;
            foreach (var item in employeeList)
            {
                if (item.IsSome)
                {
                    numberOfTotalDaysAllEmps += item.Head();
                    numberOfRetiredEmps++;
                }
            }

            return (numberOfTotalDaysAllEmps / 365) / numberOfRetiredEmps;
        }

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> func)
           => ts.Bind(t => List(func(t)));



    }





    public struct WorkPermit
    {
        public string Number { get; set; }
        public DateTime Expiry { get; set; }
    }

    public class Employee
    {
        public string Id { get; set; }
        public Option<WorkPermit> WorkPermit { get; set; }

        public Employee(DateTime joinedon, DateTime lefton)
        {
            JoinedOn = joinedon;
            LeftOn = lefton;

        }
        public Employee() : this(default(DateTime), default(DateTime)) { }

        private DateTime _joindOn;
        private DateTime _leftOn;
        public DateTime JoinedOn
        {
            private set
            {

                _joindOn = value;
            }

            get => _joindOn;
        }
        public DateTime LeftOn
        {
            private set
            {

                _leftOn = value;
            }

            get => _leftOn;
        }

        public void ChangeJoinedOn(DateTime jonedOn) { JoinedOn = jonedOn; }
        public void ChangeLeftOn(DateTime leftOn) { LeftOn = leftOn; }



    }
}
