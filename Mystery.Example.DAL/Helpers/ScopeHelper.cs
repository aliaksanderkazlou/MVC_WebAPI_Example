namespace Mystery.Example.DAL.Helpers
{
    public static class ScopeHelper
    {
        public static object LifeTimeContainer = new object();

        public static void StartNewLifeTime()
        {
            LifeTimeContainer = new object();
        }
    }
}