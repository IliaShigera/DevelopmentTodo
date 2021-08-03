using System.Collections.Generic;
using System.Threading.Tasks;
using DevelopmentTodo.Api.Controllers.Common;
using DevelopmentTodo.Application.Handlers.Task.Commands;
using DevelopmentTodo.Application.Handlers.Task.Queries;
using DevelopmentTodo.Domain.DataTransferObjects.Task;
using DevelopmentTodo.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevelopmentTodo.Api.Controllers
{
    public class TaskController : BaseApiController
    {
        [HttpGet("{providerId}")]
        public async Task<ActionResult> GetAllFoProvider(int providerId)
        {
            return Ok(ApiResult<List<TaskDto>>.Success(
                await Mediator.Send(new GetAllProviderTasksQuery(providerId))));
        }

        [HttpGet("{developerId}")]
        public async Task<ActionResult> GetAllForDeveloper(int developerId)
        {
            return Ok(ApiResult<List<TaskDto>>.Success(
                await Mediator.Send(new GetAllDeveloperTasksQuery(developerId))));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(ApiResult<TaskDto>.Success(
                await Mediator.Send(new GetTaskByIdQuery(id))));
        }

        [HttpPost("{taskId}/{developerId}")]
        public async Task<ActionResult> Edit(int taskId, int developerId, [FromBody] UpdateTaskCommand command)
        {
            command.TaskId = taskId;
            command.DeveloperId = developerId;

            return Ok(ApiResult<TaskDto>.Success(
                await Mediator.Send(command)));
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> EditStatus(int id, [FromBody] UpdateTaskStatusCommand command)
        {
            command.TaskId = id;

            return Ok(ApiResult<TaskDto>.Success(
                await Mediator.Send(command)));
        }

        [HttpPost("{taskId}/{developerId}")]
        public async Task<ActionResult> ChangeDeveloper(int taskId, int developerId, [FromBody] UpdateTaskDeveloperCommand command)
        {
            command.TaskId = taskId;
            command.DeveloperId = developerId;

            return Ok(ApiResult<TaskDto>.Success(
                await Mediator.Send(command)));
        }
    }
}
