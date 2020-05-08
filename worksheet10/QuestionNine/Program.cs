using LanguageExt;
using System;
using System.Collections.Generic;

namespace QuestionNine
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee personA = new Employee(DateTime.Today, DateTime.Today.AddYears(2));//joined today, leaving in 2 yrs
            personA.Id = "person1";
            personA.Id = "person1";
            Employee personB = new Employee(DateTime.Today.AddYears(-1), DateTime.Today.AddYears(1));//joined last yr leaving in 1 yr
            personB.Id = "person2";
            personB.Id = "person2";
            Employee personC = new Employee(DateTime.Today.AddYears(-2), DateTime.Today.AddDays(-1));//joined 2 yrs ago, left yesterday
            personB.Id = "person3";
            personB.Id = "person3";
            //  personA.JoinedOn = DateTime.Today.AddYears(1);
            //  personA.JoinedOn = DateTime.Today ;
            Console.WriteLine($"{personA.JoinedOn}");
           // Employee personB = new Employee("person2", DateTime.Today.AddDays(-1));
           // Console.WriteLine($"{personA.Id} is employed from {personA.WorkPermit.IssueDate} to {personA.WorkPermit.ValidUntil}");
           // Console.WriteLine($"{personB.Id} is employed from {personB.WorkPermit.IssueDate} to {personB.WorkPermit.ValidUntil}");

          //  IEnumerable<Employee> lst = new List<Employee>{ personA, personB };
             
            Console.WriteLine("Hello World!");
        }
    }

    //static double AverageYearsWorkedAtTheCompany(List<Employee> employees)
    //{
    //    throw new NotAppendableException();
    //}

    //...

    public struct WorkPermit
    {
        public string Number { get; set; }
        public DateTime Expiry { get; set; }
    }

    public class Employee
    {
        public string Id { get; set; }
        public Option<WorkPermit> WorkPermit { get; set; }
         public DateTime JoinedOn { get;   }

        public Employee(DateTime joinedon, DateTime lefton)
        {
            JoinedOn = joinedon;
            LeftOn = lefton;

        }

        //private DateTime _joindOn;
        //public DateTime JoinedOn
        //{  set
        //    {
        //        if (_joindOn ==null)
        //        _joindOn = value;
        //    }

        //    get => _joindOn;
        //}


        public Option<DateTime> LeftOn { get; }
    }
}
