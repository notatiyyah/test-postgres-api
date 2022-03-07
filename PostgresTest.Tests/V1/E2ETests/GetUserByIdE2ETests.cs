using AutoFixture;
using PostgresTest.V1.Infrastructure;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Threading.Tasks;
using PostgresTest.Tests;
using PostgresTest;
using PostgresTest.V1.Boundary.Response;

namespace DeveloperHubAPI.Tests.V1.E2ETests
{
    [TestFixture]
    public class GetUserByIdE2ETests : IntegrationTests<Startup>
    {
        private readonly Fixture _fixture = new Fixture();

        private void SaveUserToDB(UserDb user)
        {
            DatabaseContext.Users.Add(user);
            DatabaseContext.SaveChanges();
        }

        [Test]
        public async Task GetUserByIdNotFoundReturns404()
        {
            var id = Guid.NewGuid();
            var uri = new Uri($"api/v1/users/{id}", UriKind.Relative);
            var response = await Client.GetAsync(uri).ConfigureAwait(false);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Test]
        public async Task GetUserByIdReturnsUserIfItExists()
        {
            var user = _fixture.Create<UserDb>();
            SaveUserToDB(user);

            var uri = new Uri($"api/v1/users/{user.Id}", UriKind.Relative);
            var response = await Client.GetAsync(uri).ConfigureAwait(false);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var apiEntity = JsonConvert.DeserializeObject<UserResponse>(responseContent);

            apiEntity.Should().BeEquivalentTo(user);
        }
    }
}
