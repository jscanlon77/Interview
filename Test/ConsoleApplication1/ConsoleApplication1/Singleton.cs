namespace ConsoleApplication1
{
    public sealed class Singleton
    {
        private static volatile Singleton instance;
        private static readonly object syncRoot = new object();

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }

                return instance;
            }
        }
    }
}