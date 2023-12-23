using Microsoft.AspNetCore.Mvc;
using OtpNet;
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
					return RedirectToAction("Index", "Welcome");
				}
			}
			return View();
		}

		public IActionResult ForgotPassword()
		{
			// Generate a random secret key (you would typically store this securely on your server)
			var secretKey = KeyGeneration.GenerateRandomKey(20);

			// Create a Time-based OTP generator with a 1-minute timestep
			var totp = new Totp(secretKey, step: 60);

			// Get the current OTP
			string code = totp.ComputeTotp();

			// Print the generated code
			Console.WriteLine($"Generated Code: {code}");

			// Wait for one minute (for demonstration purposes)
			Console.WriteLine("Waiting for 1 minute...");
			System.Threading.Thread.Sleep(60000);

			
			return View();
		}
	}
}
