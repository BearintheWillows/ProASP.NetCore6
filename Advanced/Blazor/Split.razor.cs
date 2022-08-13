using Advanced.Data;
using Microsoft.AspNetCore.Components;

namespace Advanced.Blazor;

public partial class Split : ComponentBase{
	
	[Inject]
	public DataContext? Context { get; set; }
	public IEnumerable<string> Names =>
		Context?.People.Select(p => p.Firstname)
	 ?? Enumerable.Empty<string>();
}