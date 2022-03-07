using PostgresTest.V1.Domain;
using PostgresTest.V1.Factories;
using NUnit.Framework;
using AutoFixture;
using FluentAssertions;

namespace PostgresTest.Tests.V1.Factories
{
    public class ResponseFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanMapADatabaseEntityToADomainObject()
        {
            var domain = _fixture.Create<User>();
            var response = domain.ToResponse();

            response.Id.Should().Be(domain.Id);
            response.FirstName.Should().Be(domain.FirstName);
            response.LastName.Should().Be(domain.LastName);
            response.Email.Should().Be(domain.Email);
        }
    }
}
