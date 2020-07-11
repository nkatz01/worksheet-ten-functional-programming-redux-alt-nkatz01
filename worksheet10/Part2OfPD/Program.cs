using Amazon.Runtime;
using System;

namespace Part2OfPD
{   
    
    public static class Utils {
         
        public static  void Info(this Program.Level level, string msg) => Console.WriteLine(  $"{level.ToString()}: {msg}"); 
            public   static void consumeLog(Program.Level log) => log.Info("Look! no objects!");
            }
    public class Program
    {
        
        static void Main(string[] args)

        {

            numberType nt =   numberType.Home;
           // string numTp = numberType.Home;
           // Console.WriteLine(numTp);
            PhoneNumber pn = new PhoneNumber(nt,  countryCode.uk, 02088978356);//-----------------------------------------------------q1
            Console.WriteLine(pn.NumberType);

            Utils.consumeLog(Level.Info) ; //---------------------------------------------------------------------------------------q3
        }

        PhoneNumber createPhoneNumber<T1, T2, T3, T4>(numberType nt, countryCode cc, int num) => new PhoneNumber(nt, cc, num);//----q2

        public enum Level
        {
            Debug ,
            Info,
            Error
        }

 
        

        public class PhoneNumber
        {
            
 
             
            public int Number { get; }
            public numberType NumberType { get; }  
             public countryCode CountryCode { get; }
                public PhoneNumber(numberType nt, countryCode cc, int num) { NumberType = nt; CountryCode = cc; Number = num; }
          
          



          

        }
        public class numberType : ConstantClass //https://github.com/dotnet/csharplang/issues/2849
        {


            public static readonly numberType Home = new numberType("Home");

            public static readonly numberType Mobile = new numberType("Mobile");


            private numberType(string value)
                : base(value)
            {
            }


            public static numberType FindValue(string value)
            {
                return FindValue<numberType>(value);
            }


            /// <returns></returns>
            public static implicit operator numberType(string value)
            {
                return FindValue(value);
            }
        }

        public class countryCode : ConstantClass 
        {

            public static readonly countryCode it = new countryCode("it");

            public static readonly countryCode us = new countryCode("us");
            public static readonly countryCode uk = new countryCode("uk");

            private countryCode(string value)
                : base(value)
            {
            }


            public static countryCode FindValue(string value)
            {
                return FindValue<countryCode>(value);
            }


            public static implicit operator countryCode(string value)
            {
                return FindValue(value);
            }
        }


    }
}
