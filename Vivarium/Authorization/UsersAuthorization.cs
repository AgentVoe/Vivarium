using System.Security.Cryptography;
using Vivarium.Context;

namespace Vivarium.Authorization
{
	public class UsersAuthorization
	{
		private string login;
		private string password;
		public UsersAuthorization(string login, string password)
		{
			this.login = login;
			this.password = password;
		}
		public bool CheckPassword()
		{
			string userPasswordInDB;
			using (VivariumDContext db = new VivariumDContext())
			{
				var user = db.Users.Where(userLogin => userLogin.Login == login).FirstOrDefault();
				userPasswordInDB = user.Pass;
			}

			if (VerifyHashedPassword(userPasswordInDB, password)) return true;
			return false;
		}

		private bool VerifyHashedPassword(string hashedPassword, string password)
		{
			byte[] buffer4;
			if (hashedPassword == null)
			{
				return false;
			}
			if (password == null)
			{
				throw new ArgumentNullException("password");
			}
			byte[] src = Convert.FromBase64String(hashedPassword);
			if ((src.Length != 0x31) || (src[0] != 0))
			{
				return false;
			}
			byte[] dst = new byte[0x10];
			Buffer.BlockCopy(src, 1, dst, 0, 0x10);
			byte[] buffer3 = new byte[0x20];
			Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
			using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
			{
				buffer4 = bytes.GetBytes(0x20);
			}
			//return ByteArraysEqual(buffer3, buffer4);
			return buffer3.SequenceEqual(buffer4);
		}
	}
}

