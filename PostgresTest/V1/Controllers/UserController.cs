using PostgresTest.V1.Boundary.Response;
using PostgresTest.V1.UseCase.Interfaces;
using Hackney.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace PostgresTest.V1.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class UserController : BaseController
    {
        private readonly IGetUserByIdUseCase _getByIdUseCase;
        public UserController(IGetUserByIdUseCase getByIdUseCase)
        {
            _getByIdUseCase = getByIdUseCase;
        }

        /// <response code="200">Success</response>
        /// <response code="404">No user found for the specified ID</response>
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [LogCall(LogLevel.Information)]
        [Route("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var result = _getByIdUseCase.Execute(id);
            if (result is null)
                return new NotFoundObjectResult(id);
            return Ok(result);
        }
    }
}
