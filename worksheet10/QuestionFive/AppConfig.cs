using LanguageExt;
using System;

using System.Collections.Specialized;
using static LanguageExt.Prelude;

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

        public  Option<T> Get<T>(string name) //returns an instanciated object of retrieved value associated with key\name
           
              => (source[name] != null && Type.GetType(source[name]) != null ) ?  Some( (T)Activator.CreateInstance(Type.GetType(source[name]))) :  None;

        

        public T Get<T>(string name, T defaultValue)

        //  => Get<T>(name).IsSome ? (T)Get<T>(name) :    defaultValue;
         => Get<T>(name).IsSome ? (T)Get<T>(name) : (T)Activator.CreateInstance(defaultValue.GetType());






    }
}
