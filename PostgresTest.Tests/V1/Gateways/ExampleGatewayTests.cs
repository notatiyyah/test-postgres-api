using AutoFixture;
using PostgresTest.Tests.V1.Helper;
using PostgresTest.V1.Domain;
using PostgresTest.V1.Gateways;
using FluentAssertions;
using NUnit.Framework;

namespace PostgresTest.Tests.V1.Gateways
{
    //TODO: Rename Tests to match gateway name
    [TestFixture]
    public class ExampleGatewayTests : DatabaseTests
    {
        private readonly Fixture _fixture = new Fixture();
        private ExampleGateway _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new ExampleGateway(DatabaseContext);
        }

        [Test]
        public void GetEntityByIdReturnsNullIfEntityDoesntExist()
        {
            var response = _classUnderTest.GetEntityById(123);

            response.Should().BeNull();
        }

        [Test]
        public void GetEntityByIdReturnsTheEntityIfItExists()
        {
            var entity = _fixture.Create<Entity>();
            var databaseEntity = DatabaseEntityHelper.CreateDatabaseEntityFrom(entity);

            DatabaseContext.DatabaseEntities.Add(databaseEntity);
            DatabaseContext.SaveChanges();

            var response = _classUnderTest.GetEntityById(databaseEntity.Id);

            databaseEntity.Id.Should().Be(response.Id);
            databaseEntity.CreatedAt.Should().BeSameDateAs(response.CreatedAt);
        }

        //TODO: Add tests here for the get all method.
    }
}
