using System.ComponentModel.DataAnnotations;

namespace Registration_and_Login.Models
{
	public class Users
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
