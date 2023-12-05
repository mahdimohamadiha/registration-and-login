using Microsoft.AspNetCore.Mvc;
using Registration_and_Login.Data;
using Registration_and_Login.Models;

namespace Registration_and_Login.Controllers
{
	public class CreateAccountController : Controller
	{

		private readonly ApplicationDbContext _db;

		public CreateAccountController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Users users)
		{
			if (ModelState.IsValid)
			{
				_db.Users.Add(users);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(users);
		}
	}
}
