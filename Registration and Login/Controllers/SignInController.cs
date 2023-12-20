using Microsoft.AspNetCore.Mvc;
using Registration_and_Login.Data;
using Registration_and_Login.Models;

namespace Registration_and_Login.Controllers
{
	public class SignInController : Controller
	{
		private readonly ApplicationDbContext _db;

		public SignInController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(string email, string password)
		{
			Users user = _db.Users.SingleOrDefault(u => u.Email == email);
			if (user != null)
			{
				if (user.Password == password)
				{
					Console.WriteLine("True");
					return View();
				}
			}
			return View();
		}
	}
}
