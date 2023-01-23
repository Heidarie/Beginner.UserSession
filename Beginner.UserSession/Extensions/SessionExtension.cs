using Newtonsoft.Json;

namespace Beginner.UserSession.Extensions
{
    public static class SessionExtension
    {
        public static string GetSessionValue(this ISession session, string key)
        {
            return session.GetString(key);
        }

        public static void SetSessionValue(this ISession session, string key, object value)
        {
            var val = JsonConvert.SerializeObject(value);
            session.SetString(key, val);
        }
    }
}
