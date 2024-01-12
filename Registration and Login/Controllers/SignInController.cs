using Microsoft.AspNetCore.Mvc;
using OtpNet;
using Registration_and_Login.Data;
using Registration_and_Login.Models;
using System.Net.Mail;
using System.Net;

namespace Registration_and_Login.Controllers
{
	public class SignInController : Controller
	{
		private readonly ApplicationDbContext _db;

		private static int randomGeneratedNumber;

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

		[HttpGet]
		public IActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ForgotPassword(string email)
		{
			Users user = _db.Users.SingleOrDefault(u => u.Email == email);
			SendEmail(email);
			if (user != null)
			{
				return RedirectToAction("Verify", "SignIn" , new { recipient_email = email });
			}
			return View();
		}
		[HttpGet]
		public IActionResult Verify(string recipient_email)
		{
			ViewData["RecipientEmail"] = recipient_email;
			return View();
		}
		[HttpGet]
		public IActionResult ResendEmail(string recipient_email)
		{
			SendEmail(recipient_email);
			return View("Verify");
		}

		[HttpPost]
		public IActionResult Verify(string digit1, string digit2, string digit3, string digit4)
		{
			
			int digit = (Convert.ToInt32(digit1) * 1000) + (Convert.ToInt32(digit2) * 100 ) + (Convert.ToInt32(digit3) * 10) + Convert.ToInt32(digit4);
			Console.WriteLine(digit);
			Console.WriteLine(randomGeneratedNumber);
			return View();
		}



		private int GenerateRandomCode()
		{
			// Generate a random 6-digit code for simplicity
			Random rand = new Random();
			return rand.Next(0, 9999);
		}

		public void SendEmail(string recipient_email)
		{
			ViewData["RecipientEmail"] = recipient_email;
			randomGeneratedNumber = GenerateRandomCode();
			Console.WriteLine(randomGeneratedNumber);
			Console.WriteLine(recipient_email);
			using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
			{
				client.UseDefaultCredentials = false;
				client.Credentials = new NetworkCredential("m.mohammadiha81@gmail.com", "dquieocvriktbpen");
				client.EnableSsl = true;

				MailMessage mailMessage = new MailMessage();
				mailMessage.From = new MailAddress("m.mohammadiha81@gmail.com");
				mailMessage.To.Add(recipient_email);
				mailMessage.Subject = "Verification Code";
				mailMessage.Body = $"Your verification code is: {randomGeneratedNumber}";

				client.Send(mailMessage);
			}
		}
	}
}
