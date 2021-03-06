using PostgresTest.V1.Boundary.Response;
using PostgresTest.V1.Domain;

namespace PostgresTest.V1.Factories
{
    public static class ResponseFactory
    {
        public static UserResponse ToResponse(this User domain)
        {
            return new UserResponse
            {
                Id = domain.Id,
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                Email = domain.Email
            };
        }
    }
}
