namespace Beginner.UserSession.Helpers
{
    public interface IRedisCacheHelper
    {
        void Set(string key, string value);
        string Get(string key);   
    }
}
