using System;
using PostgresTest.V1.Domain;
using PostgresTest.V1.Factories;
using PostgresTest.V1.Infrastructure;

namespace PostgresTest.V1.Gateways
{
    public class UserGateway : IUserGateway
    {
        private readonly DatabaseContext _databaseContext;

        public UserGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public User GetUserById(Guid id)
        {
            var result = _databaseContext.Users.Find(id);
            return result?.ToDomain();
        }
    }
}
