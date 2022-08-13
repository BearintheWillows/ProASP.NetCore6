namespace Advanced.Blazor;

using Microsoft.AspNetCore.Components;

public partial class SelectFilter
{
	[Parameter]
	public IEnumerable<string> Values        { get; set; } = Enumerable.Empty<string>();
	[Parameter]
	public string?             SelectedValue { get; set; }
	
	[Parameter]
	public string Title { get; set; } = "Placeholder";
	
	[Parameter(CaptureUnmatchedValues = true)]
	public Dictionary<string, object?> Attrs { get; set; }
	
	[Parameter]
	public EventCallback<string> SelectedValueChanged { get; set; }
	
	public async Task HandleSelect(ChangeEventArgs e)
	{
		SelectedValue = e.Value as string;
		if (SelectedValue == "Sales") {
			throw new Exception("Sales cannot be selected");
		}
		await SelectedValueChanged.InvokeAsync(SelectedValue);
	}

	[CascadingParameter( Name = "BgTheme" )]
	public string Theme { get; set; } = "";
	
	public string TextColor() => String.IsNullOrEmpty( Theme ) ? "text-dark" : "text-light";
}