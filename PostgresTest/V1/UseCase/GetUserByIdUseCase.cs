using PostgresTest.V1.Boundary.Response;
using PostgresTest.V1.Factories;
using PostgresTest.V1.Gateways;
using PostgresTest.V1.UseCase.Interfaces;
using System;

namespace PostgresTest.V1.UseCase
{
    public class GetUserByIdUseCase : IGetUserByIdUseCase
    {
        private IUserGateway _gateway;
        public GetUserByIdUseCase(IUserGateway gateway)
        {
            _gateway = gateway;
        }

        public UserResponse Execute(Guid id)
        {
            var user = _gateway.GetUserById(id);
            return user?.ToResponse();
        }
    }
}
