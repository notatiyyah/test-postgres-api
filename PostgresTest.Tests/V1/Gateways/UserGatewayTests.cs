using AutoFixture;
using PostgresTest.V1.Domain;
using PostgresTest.V1.Gateways;
using FluentAssertions;
using NUnit.Framework;
using System;
using PostgresTest.V1.Factories;

namespace PostgresTest.Tests.V1.Gateways
{
    [TestFixture]
    public class UserGatewayTests : DatabaseTests
    {
        private readonly Fixture _fixture = new Fixture();
        private UserGateway _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new UserGateway(DatabaseContext);
        }

        [Test]
        public void GetUserByIdReturnsNullIfUserDoesntExist()
        {
            var id = Guid.NewGuid();
            var response = _classUnderTest.GetUserById(id);

            response.Should().BeNull();
        }

        [Test]
        public void GetUserByIdReturnsTheUserIfItExists()
        {
            var user = _fixture.Create<User>();

            DatabaseContext.Users.Add(user.ToDatabase());
            DatabaseContext.SaveChanges();

            var response = _classUnderTest.GetUserById(user.Id);

            response.Should().BeEquivalentTo(user);
        }
    }
}
