using Vivarium.Authorization;

namespace Tests
{
    [TestFixture]
    public class Tests 
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
