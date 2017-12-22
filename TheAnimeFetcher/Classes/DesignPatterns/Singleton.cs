using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAnimeFetcher.Classes.DesignPatterns
{
    public abstract class Singleton<T>  where T : new()
    {
        // non thread-safe instance
        private static T instance;

        // thread-safe instance
        private static T threadSafeInstance;
        private static readonly object padlock = new object();

        public Singleton()
        {
        }

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    ResetInstance();
                }
                return instance;
            }
        }
        public static T ThreadSafeInstance
        {
            get
            {
                lock (padlock)
                {
                    if (threadSafeInstance == null)
                    {
                        ResetThreadSafeInstance();
                    }
                    return threadSafeInstance;
                }
            }
        }
        public static void ResetInstance()
        {
            instance = new T();
        }
        public static void ResetThreadSafeInstance()
        {
            threadSafeInstance = new T();
        }
    }

}
