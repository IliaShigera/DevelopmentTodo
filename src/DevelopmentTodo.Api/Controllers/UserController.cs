using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevelopmentTodo.Api.Controllers.Common;
using DevelopmentTodo.Application.Handlers.User.Commands;
using DevelopmentTodo.Application.Handlers.User.Queries;
using DevelopmentTodo.Domain.DataTransferObjects.Task;
using DevelopmentTodo.Domain.DataTransferObjects.User;
using DevelopmentTodo.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentTodo.Api.Controllers
{
    public class UserController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(ApiResult<List<UserDto>>.Success(
                await Mediator.Send(new GetAllUsersQuery())));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(ApiResult<UserDto>.Success(
                await Mediator.Send(new GetUserByIdQuery(id))));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;

            return Ok(ApiResult<UserDto>.Success(
                await Mediator.Send(command)));
        }

        //TODO: Bug
        [HttpPost("{providerId}/{developerId}")]
        public async Task<ActionResult> CreateTask(int providerId, int developerId, [FromBody] CreateTaskCommand command)
        {
            command.ProviderId = providerId;
            command.DeveloperId = developerId;

            return Ok(ApiResult<TaskDto>.Success(
                await Mediator.Send(command)));
        }
    }
}
