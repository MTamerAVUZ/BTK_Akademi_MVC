using System.Text.Json;

namespace StoreApp.Infrastructure.Extensions
{
	public static class SessionExtension     //Extensionslar static olur genelde
	{
		public static void SetJson(this ISession session, string key, object value)
		{
			session.SetString(key, JsonSerializer.Serialize(value));// bir objeyi serilize edip string olarak kullanmak için
		}

		public static void setObject<T>(this ISession session, string key, T value)
		{
			session.SetString(key, JsonSerializer.Serialize(value));
		}

		public static T? GetJson<T>(this ISession session, string key)
		{
			var data = session.GetString(key);
			return data is null
				? default(T)
				: JsonSerializer.Deserialize<T>(data);
		}
	}
}
