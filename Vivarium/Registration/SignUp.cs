using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivarium.Context;
using Vivarium.HashProcess;

namespace Vivarium.Registration
{
    class SignUp
    {
        private string login;
        private string password;
        public SignUp(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public bool Registration()
        {
            var hashedPassword = new Hashing(password).HashPassword();
            using (VivariumContext db = new VivariumContext())
            {
                User user = new User
                {
                    Login = login,
                    Pass = hashedPassword
                };
                db.Users.Add(user);
                db.SaveChanges();
                return true;
			}
			return false;
		}
    }
}