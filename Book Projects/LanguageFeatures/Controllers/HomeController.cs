
namespace LanguageFeatures.Controllers;
public class HomeController : Controller
{
    public async Task<ViewResult> Index()
    {
        List<string> output = new();
        foreach ( long? len in await MyAsyncMethod.GetPageLengths( output, "apress.com", "microsoft.com", "amazon.com" ) )
        {
            output.Add( $"Page length: {len}" );
        }
        return View( output );
    }
}
