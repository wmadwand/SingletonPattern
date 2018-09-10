using System;
using System.Collections.Generic;

namespace Singleton
{
    public class Singleton
    {
        private static Singleton _instance;
        private static Dictionary<string, Singleton> dict = new Dictionary<string, Singleton>();

        public static void Register(string name, Singleton singleton)
        {
            dict[name] = singleton;
        }

        public static Singleton Lookup(string name)
        {
            return dict[name];
        }

        public static Singleton Instance()
        {
            if (_instance == null)
            {
                string singletonName = "Main.GetCurrentName()";

                _instance = Lookup(singletonName);
            }

            return _instance;
        }

        protected Singleton()
        {
        }
    }

    public class MySingleton : Singleton
    {
        protected MySingleton()
        {
            Singleton.Register("MySingleton", this);
        }
    }
}