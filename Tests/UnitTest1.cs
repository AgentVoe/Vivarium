using Vivarium.Authorization;
using Vivarium.StaticData;


namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void RandomPassTest()
        {
            var login = "login";
            var rndPass = new Random().Next();
            var authorize = new UsersAuthorization(login, rndPass.ToString());

            var res = authorize.CheckPassword();

            Assert.That(res, Is.False);
        }

        [Test]
        public void RandomLoginAndPassTest()
        {
            var login = new Random().Next();
            var rndPass = new Random().Next();
            var authorize = new UsersAuthorization(login.ToString(), rndPass.ToString());

            var res = authorize.CheckPassword();

            Assert.That(res, Is.False);
        }

        [TestCase(1, 1, 1)]
        public void MutatuionTest(int a, int b, int c)
        {
            var countDoneBook = UserAndBooks.userAndBooks[0].StatusBooks.Where(
                sb => sb.Status.Status1 == "Прочитано").Count();

            var res = UserAndBooks.GetCountDoneBook();

            Assert.That(countDoneBook == res, Is.True);
        }
    }
}
