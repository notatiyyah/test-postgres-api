using PostgresTest.V1.Gateways;
using PostgresTest.V1.UseCase;
using Moq;
using NUnit.Framework;
using System;
using PostgresTest.V1.Domain;
using FluentAssertions;
using AutoFixture;

namespace PostgresTest.Tests.V1.UseCase
{
    public class GetUserByIdUseCaseTests
    {
        private Mock<IUserGateway> _mockGateway;
        private GetUserByIdUseCase _classUnderTest;
        private readonly Fixture _fixture = new Fixture();

        [SetUp]
        public void SetUp()
        {
            _mockGateway = new Mock<IUserGateway>();
            _classUnderTest = new GetUserByIdUseCase(_mockGateway.Object);
        }

        [Test]
        public void ReturnsNullIfGatewayReturnsNull()
        {
            var id = Guid.NewGuid();
            _mockGateway.Setup(x => x.GetUserById(id)).Returns((User) null);

            var response = _classUnderTest.Execute(id);
            response.Should().BeNull();
        }

        [Test]
        public void ReturnsTheUserFromTheGateway()
        {
            var user = _fixture.Create<User>();
            _mockGateway.Setup(x => x.GetUserById(user.Id)).Returns(user);

            var response = _classUnderTest.Execute(user.Id);
            response.Should().BeEquivalentTo(user);
        }
    }
}
