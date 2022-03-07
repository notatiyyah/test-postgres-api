using System;
using PostgresTest.V1.Boundary.Response;

namespace PostgresTest.V1.UseCase.Interfaces
{
    public interface IGetUserByIdUseCase
    {
        public UserResponse Execute(Guid id);
    }
}
