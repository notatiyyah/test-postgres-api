using AutoFixture;
using PostgresTest.V1.Domain;
using PostgresTest.V1.Factories;
using PostgresTest.V1.Infrastructure;
using FluentAssertions;
using NUnit.Framework;

namespace PostgresTest.Tests.V1.Factories
{
    [TestFixture]
    public class EntityFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void CanMapADatabaseEntityToADomainObject()
        {
            var databaseEntity = _fixture.Create<UserDb>();
            var entity = databaseEntity.ToDomain();

            databaseEntity.Id.Should().Be(entity.Id);
            databaseEntity.FirstName.Should().Be(entity.FirstName);
            databaseEntity.LastName.Should().Be(entity.LastName);
            databaseEntity.Email.Should().Be(entity.Email);
        }

        [Test]
        public void CanMapADomainEntityToADatabaseObject()
        {
            var entity = _fixture.Create<User>();
            var databaseEntity = entity.ToDatabase();

            entity.Id.Should().Be(databaseEntity.Id);
            entity.FirstName.Should().Be(databaseEntity.FirstName);
            entity.LastName.Should().Be(databaseEntity.LastName);
            entity.Email.Should().Be(databaseEntity.Email);
        }
    }
}
