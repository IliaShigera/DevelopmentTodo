using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DevelopmentTodo.Domain.DataTransferObjects.Task;
using DevelopmentTodo.Domain.Entities;
using DevelopmentTodo.Domain.Exceptions;
using DevelopmentTodo.Domain.Interfaces.Repository;
using MediatR;

namespace DevelopmentTodo.Application.Handlers.Task.Queries
{
    public record GetTaskByIdQuery(int Id) : IRequest<TaskDto> { }

    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskByIdHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.FindByIdAsync(request.Id, cancellationToken)
                       ?? throw new NotFoundException($"Task with id: {request.Id} not found.");

            return _mapper.Map<TaskDto>(task);
        }
    }
}
