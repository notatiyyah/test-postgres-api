using System.Linq;
using NUnit.Framework;
using AutoFixture;
using PostgresTest.V1.Infrastructure;

namespace PostgresTest.Tests.V1.Infrastructure
{
    [TestFixture]
    public class DatabaseContextTest : DatabaseTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanGetAUser()
        {
            var user = _fixture.Create<UserDb>();

            DatabaseContext.Add(user);
            DatabaseContext.SaveChanges();

            var result = DatabaseContext.Users.ToList().FirstOrDefault();

            Assert.AreEqual(result, user);
        }
    }
}
