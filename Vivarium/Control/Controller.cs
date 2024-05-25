using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivarium.Authorization;
using Vivarium.Registration;

namespace Vivarium.Control
{
	public class Controller
	{
		private string login;
		private string password;
		public Controller(string login, string password)
		{
			this.login = login;
			this.password = password;
		}

		public bool TryToAuthorize()
		{
			var authorize = new UsersAuthorization(login, password).CheckPassword();
			if (authorize) return true;
			return false;
		}
		//public bool TryToSignUp()
		//{
		//	var signUp = new SignUp(login, password).Registration();
		//}
	}
}