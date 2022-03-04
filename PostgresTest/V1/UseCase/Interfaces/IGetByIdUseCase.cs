using PostgresTest.V1.Boundary.Response;

namespace PostgresTest.V1.UseCase.Interfaces
{
    public interface IGetByIdUseCase
    {
        ResponseObject Execute(int id);
    }
}
