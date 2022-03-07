using System;
using PostgresTest.V1.Domain;

namespace PostgresTest.V1.Gateways
{
    public interface IUserGateway
    {
        User GetUserById(Guid id);

    }
}
