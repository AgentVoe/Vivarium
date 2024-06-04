using Vivarium.Authorization;
using Vivarium.Context;
using Vivarium.Registration;
using Vivarium.StaticData;

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
        public Controller()
        {
            
        }

        public bool TryToAuthorize()
		{
			var authorize = new UsersAuthorization(login, password).CheckPassword();
			if (authorize)
			{
				var loader = new DataLoader(login);
				return true;
			}	
			return false;
		}
		public bool TryToSignUp()
		{
			var signUp = new SignUp(login, password).Registration();
			if (signUp) return true;
			return false;
		}
		public void TryToLoadData()
		{
			new DataLoader();
		}
		public void TryToAddBookToUser(StatusBook book)
		{
			UserAndBooks.AddBookToUser(book);
		}
	}
}