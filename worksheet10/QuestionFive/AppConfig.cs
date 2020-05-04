using LanguageExt;
using System;
//using System.Collections.Generic;
using System.Collections.Specialized;
using static LanguageExt.Prelude;
// using System.Configuration;
//using System.Text;
//using System.Diagnostics;
//using System.Reflection;
//using Autofac;

namespace QuestionFive
{
    public class AppConfig
    {
        NameValueCollection source;

        public AppConfig() : this(System.Configuration.ConfigurationManager.AppSettings) { 
        
        }

        public AppConfig(NameValueCollection source)
        {
            this.source = source;
        }

        public static object ConfigurationManager { get; }

        public  Option<T> Get<T>(string name)
          //{
          //  if (source[name] != null) {
          ////   Option<T> opSt = source[name];
          // var opSt = Type.GetType(source[name]);
          // var obj = Activator.CreateInstance(opSt); 
          //  return Some((T)obj); }
          //  else 
          //  return  None ;
          //  => (source[name] != null) ? (Option<T>)Activator.CreateInstance(Type.GetType(source[name])) : (Option<T>)None;
              => (source[name] != null && Type.GetType(source[name]) != null ) ?  Some( (T)Activator.CreateInstance(Type.GetType(source[name]))) :  None;

         // => Console.WriteLine(source[name]  );
        //  }

        public T Get<T>(string name, T defaultValue)
      
            => (source[name] != null && Type.GetType(source[name]) != null) ?  (T)Activator.CreateInstance(Type.GetType(source[name])) :  (T)Activator.CreateInstance( defaultValue.GetType());
         
    }
}
