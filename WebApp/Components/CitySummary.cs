namespace WebApp.Components;

using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

public class CitySummary : ViewComponent
{
	private CitiesData data;
	public CitySummary(CitiesData cdata) {
		data = cdata;
	}
	public IViewComponentResult Invoke(string themeName)
	{
		ViewBag.Theme = themeName;
		return View( new CityViewModel
				{
				Cities = data.Cities.Count(), Population = data.Cities.Sum( c => c.Population ),
				}
		);
	}
}