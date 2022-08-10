using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advanced.Pages;

using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

public class IndexModel: PageModel {
	private DataContext context;
	public IndexModel(DataContext dbContext) {
		context = dbContext;
	}
	public IEnumerable<Person> People { get; set; } = Enumerable.Empty<Person>();
	public IEnumerable<string> Cities { get; set; } = Enumerable.Empty<string>();
	[FromQuery]
	public string SelectedCity { get; set; } = String.Empty;
	public void OnGet() {
		People = context.People.Include(p => p.Department)
		                .Include(p => p.Location);
		Cities = context.Locations.Select(l => l.City).Distinct();
	}
	public string GetClass(string? city) =>
		SelectedCity == city ? "bg-info text-white" : "";
}