﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GetAPet.Models;

namespace GetAPet.Controllers;

public class HomeController : Controller
{
	public IActionResult Index() => View();
}