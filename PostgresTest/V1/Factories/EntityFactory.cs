using PostgresTest.V1.Domain;
using PostgresTest.V1.Infrastructure;

namespace PostgresTest.V1.Factories
{
    public static class EntityFactory
    {
        public static User ToDomain(this UserDb databaseEntity)
        {
            return new User
            {
                Id = databaseEntity.Id,
                FirstName = databaseEntity.FirstName,
                LastName = databaseEntity.LastName,
                Email = databaseEntity.Email
            };
        }

        public static UserDb ToDatabase(this User entity)
        {

            return new UserDb
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email
            };
        }
    }
}
