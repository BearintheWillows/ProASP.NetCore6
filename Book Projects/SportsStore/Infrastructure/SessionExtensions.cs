using System.Text.Json;

namespace SportsStore.Infrastructure;

public class SessionExtensions
{
	public static void SetJson( this ISession session, string key, object value ) =>
		session.SetString( key, JsonSerializer.Serialize( value ) );

	public static T? GetJson<T>( this ISession session, string key ) where T : class
	{
		string? sessionData = session.GetString( key );
		return sessionData == null ? null : JsonSerializer.Deserialize<T>( sessionData );
	}
}