﻿using Microsoft.AspNetCore.Mvc;

namespace Registration_and_Login.Controllers
{
	public class CreateAccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}