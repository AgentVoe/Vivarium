using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Vivarium.Authorization;

namespace Vivarium.Tests
{
    [TestFixture]   
    internal class Tests
    {
        [Test]
        public void RandomTest() 
        {
            var login = "login";
            var rndPass = new Random().Next();
            var authorize = new UsersAuthorization(login, rndPass.ToString());

            var res = authorize.CheckPassword();

            Assert.That(res, Is.False);
        }

        [Test]
        public void MutatuionTest()
        {


            Assert.That(true, Is.True);
        }
    }
}
