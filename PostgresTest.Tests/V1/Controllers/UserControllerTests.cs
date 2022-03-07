using PostgresTest.V1.Controllers;
using PostgresTest.V1.UseCase.Interfaces;
using Hackney.Core.Testing.Shared;
using Moq;
using NUnit.Framework;
using System;
using PostgresTest.V1.Boundary.Response;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using AutoFixture;

namespace PostgresTest.Tests.V1.Controllers
{
    [TestFixture]
    public class UserControllerTests : LogCallAspectFixture
    {
        private UserController _classUnderTest;
        private Mock<IGetUserByIdUseCase> _mockGetByIdUseCase;
        private readonly Fixture _fixture = new Fixture();

        [SetUp]
        public void SetUp()
        {
            _mockGetByIdUseCase = new Mock<IGetUserByIdUseCase>();
            _classUnderTest = new UserController(_mockGetByIdUseCase.Object);
        }

        [Test]
        public void GetUserByIdReturns404IfUseCaseReturnsNull()
        {
            var id = Guid.NewGuid();
            _mockGetByIdUseCase.Setup(x => x.Execute(id)).Returns((UserResponse) null);

            var response = _classUnderTest.GetUserById(id) as NotFoundObjectResult;

            response.StatusCode.Should().Be(404);
            response.Value.Should().Be(id);
        }


        [Test]
        public void GetUserByIdReturnsUserFromUseCase()
        {
            var user = _fixture.Create<UserResponse>();

            _mockGetByIdUseCase.Setup(x => x.Execute(user.Id)).Returns(user);

            var response = _classUnderTest.GetUserById(user.Id) as OkObjectResult;

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            response.Value.Should().BeEquivalentTo(user);
        }
    }
}
