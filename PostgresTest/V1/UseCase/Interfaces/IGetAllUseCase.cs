using PostgresTest.V1.Boundary.Response;

namespace PostgresTest.V1.UseCase.Interfaces
{
    public interface IGetAllUseCase
    {
        ResponseObjectList Execute();
    }
}
