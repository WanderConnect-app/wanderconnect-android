using System;
namespace wanderconnect_android.Models.User
{
	public class Register
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public bool IsAcceptTermsOfUse { get; set; }
		public string RegisterAs { get; set; }
		public string Country { get; set; }
	}
}

