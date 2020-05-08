using LanguageExt;
using LanguageExt.TypeClasses;
using LanguageExt.UnsafeValueAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using static LanguageExt.Prelude;

namespace QuestionEight
{
    public class Program
    {
 
        public delegate Option<TA> MyDelegate<TA>(IEnumerable<TA> collec, Func<TA, bool> pred);
        static void Main(string[] args)
        {
            Employee personA = new Employee("person1", DateTime.Today.AddYears(1));
            Employee personB = new Employee("person2", DateTime.Today.AddDays(-1));
            Console.WriteLine($"{personA.Id} is employed from {personA.WorkPermit.IssueDate} to {personA.WorkPermit.ValidUntil}");
            Console.WriteLine($"{personB.Id} is employed from {personB.WorkPermit.IssueDate} to {personB.WorkPermit.ValidUntil}");
 
            IDictionary<string, Employee> ienum = new Dictionary<string, Employee> {
                {personA.Id, personA },
                { personB.Id, personB  }

                };


 
            MyDelegate<KeyValuePair<string, Employee>> func = new MyDelegate<KeyValuePair<string, Employee>>(SetMethod.filterListOnPred);
            //   var result1 = func(ienum, x => x.Key.Equals("person1"));

            var result1 = ienum.MySelect(x => x.Key.Equals("person1"), func);
            var result2 = ienum.MySelect(x => x.Key.Equals("person2"), func);
            var result3 = ienum.MySelect(x => x.Key.Equals("person3"), func);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);

        }

        public static Option<WorkPermit> GetWorkingPermit(Dictionary<string, Employee> people, string employeeId)
        {
            Employee value;
            if (people.TryGetValue(employeeId, out value))
                return Some(value.WorkPermit);
            else
                return None;
        }


    }

    public static class SetMethod
    {
        public static Option<TA> filterListOnPred<TA>(this IEnumerable<TA> Ienum, Func<TA, bool> Predicate) => Ienum.Find(Predicate);

        public static Option<WorkPermit> MySelect(this IEnumerable<KeyValuePair<string, Employee>> Ienum, Func<KeyValuePair<string, Employee>, bool> pred, Program.MyDelegate<KeyValuePair<string, Employee>> extractEmp)
        { 


            extractEmp(Ienum, pred);

            var record = extractEmp(Ienum, pred);

            var workpermit = record.Match(Some: i => Some(i.Value.WorkPermit), None: () => None);

            var tru = workpermit.Match(Some: i => i.ValidUntil > DateTime.Today, None: () => false);
           
           
            if (tru)
                return workpermit;
            else
                return
                    None;





        }

        //maybe come back later and render this method generic like so
        //public static Option<WorkPermit> MySelect<TA>(this IEnumerable<TA> Ienum, Func<TA, bool> pred, Program.MyDelegate<TA> extractEmp)
        //{

        //        var Dictrecord = extractEmp(Ienum, pred);
        //        var wrkprmt = Dictrecord.Match(Some: i => (Employee)i.Value.WorkPermit, None: i => None);
        //        return wrkprmt;

        //    }
        // ? Some(Ienum.AsQueryable().Where(Predicate).ToList() ) : None ;
        //Func<IEnumerable<TA>, Func<TA, bool>,  Option<TA>> extractEmp

    }

    public class Employee
    {
        public WorkPermit WorkPermit { get; }
        public string Id { get; }
        public Employee(string id, DateTime validUntil)
        {
            Id = id;
            WorkPermit = new WorkPermit(DateTime.Today, validUntil);

        }


    }

    public class WorkPermit
    {
        public DateTime ValidUntil { get; }
        public DateTime IssueDate { get; }
        public WorkPermit(DateTime issuedate, DateTime validuntil) { IssueDate = issuedate; ValidUntil = validuntil; }

    }



}
