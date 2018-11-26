using System;
using System.Collections.Generic;

namespace Recall
{
    public class GameControllerForiOS : GameController
    {
        public GameControllerForiOS()
        {
            Console.WriteLine("Hi iOS");
        }
    }

    public class GameControllerForAndroid : GameController
    {
        public GameControllerForAndroid()
        {
            Console.WriteLine("Hi Andorid");
        }
    }

    public class GameController
    {
        public static GameController Instance1
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameController();
                }

                return _instance;
            }
        }

        private static GameController _instance;

        protected GameController() { }

        public static GameController Instance()
        {
            if (_instance == null)
            {
                string currentPlatform = "iOS"; // GetCurrentPlatform() -> iOS

                switch (currentPlatform)
                {
                    case "iOS": _instance = new GameControllerForiOS(); break;
                    case "Android": _instance = new GameControllerForAndroid(); break;
                }
            }

            return _instance;
        }
    }

    public class Singleton
    {
        private static Singleton _instance;
        private static Dictionary<string, Singleton> dict = new Dictionary<string, Singleton>();

        protected Singleton() { }

        public static void Register(string name, Singleton singleton)
        {
            dict[name] = singleton;
        }

        public static Singleton Get(string name)
        {
            return dict[name];
        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    string currPlatform = "iOS"; // if iOS => GameControllerForIOS
                    _instance = Get(currPlatform);
                }

                return _instance;
            }
        }
    }

    public class GameController1 : Singleton
    {
        public GameController1()
        {
            Singleton.Register("GameControllerForIOS", this);
        }
    }
}