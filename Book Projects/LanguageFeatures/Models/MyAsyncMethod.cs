namespace LanguageFeatures.Models;
public class MyAsyncMethod
{
    public async static Task<long?> GetPageLength()
    {
        HttpClient client = new();

        var httpMessage = await client.GetAsync("http://apress.com");
        return httpMessage.Content.Headers.ContentLength;
    }

    public static async Task<IEnumerable<long?>> GetPageLengths( List<string> output, params string[] urls )
    {
        List<long?> results = new();
        HttpClient client = new();
        foreach ( var url in urls )
        {
            output.Add( $"Started request for {url}" );

            var httpMessage = await client.GetAsync($"https://{url}");

            results.Add( httpMessage.Content.Headers.ContentLength );

            output.Add( $"Completed request for {url}" );
        }
        return results;
    }
}