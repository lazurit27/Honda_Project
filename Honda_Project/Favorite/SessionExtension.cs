using System.Text.Json;

namespace Honda_Project.Favorite
{
    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            var json = JsonSerializer.Serialize(value);
            session.SetString(key, json);
        }
        public static T? GetObject<T>(this ISession session, string key)
        {
            string? json = session.GetString(key);
            return json == null
                ? default :
                JsonSerializer.Deserialize<T>(json);
        }
    }
}
