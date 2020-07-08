using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using static LanguageExt.Prelude;

namespace QuestionEight
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee personA = new Employee("person1", DateTime.Today.AddYears(1));
            Employee personB = new Employee("person2", DateTime.Today.AddDays(-1));
            Console.WriteLine($"{personA.Id} is employed from {personA.WorkPermit.IssueDate} to {personA.WorkPermit.IssueDate}");
            IDictionary<string, Employee> ienum = new Dictionary<string, Employee> {
                {personA.Id, personA },
                { personB.Id, personB  }

                };
            //    var result3 = myDict.MySelect<KeyValuePair<string, int>, KeyValuePair<string, int>>((pair) => new KeyValuePair<string, int>("number " + pair.Key, pair.Value + 1));

            var result3 = ienum.MyWhere<KeyValuePair<string, Employee>>(x => x.Key.Equals("person3"));//<KeyValuePair<string, Employee>, KeyValuePair<string, Employee>>
            Console.WriteLine(result3);
        }


        static Option<WorkPermit> GetWorkingPermit(Dictionary<string, Employee> people, string employeeId)
        {
            Employee value;
            if (people.TryGetValue(employeeId, out value))
                return Some(value.WorkPermit);
            else
                return None;//TryGetValue(employeeId, out value)//x => x.Key.Equals(employeeId)).ToList.Count() > 0 
        }
    }
    public static class SetMethod
    {

        public static Option<TA> MyWhere<TA>(this IEnumerable<TA> Ienum, System.Linq.Expressions.Expression<Func<TA, bool>> Predicate)

         

       =>     Ienum.AsQueryable().Where(Predicate).Count()>0 ? Some(Ienum.AsQueryable().Where(Predicate).First()) : None ;

  


        // Ienum.Where(x =>  predSelector(x) ) > 0 ? Some(predSelector(Ienum)) : None;
        //   Ienum.Where(i => map(i).Equals(true)).ToList().Count() > 0 ? Some((TB) Ienum.Where(i => map(i).Equals(true)).ToList()[0]) : None;




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
