using System.Collections.Generic;
using PostgresTest.V1.Domain;

namespace PostgresTest.V1.Gateways
{
    public interface IExampleGateway
    {
        Entity GetEntityById(int id);

        List<Entity> GetAll();
    }
}
