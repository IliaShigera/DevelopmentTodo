using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DevelopmentTodo.Domain.DataTransferObjects.Task;
using DevelopmentTodo.Domain.Exceptions;
using DevelopmentTodo.Domain.Interfaces.Repository;
using MediatR;

namespace DevelopmentTodo.Application.Handlers.Task.Queries
{
    public record GetAllDeveloperTasksQuery(int DeveloperId) : IRequest<List<TaskDto>> { }

    public class GetAllDeveloperTasksHandler : IRequestHandler<GetAllDeveloperTasksQuery, List<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetAllDeveloperTasksHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<TaskDto>> Handle(GetAllDeveloperTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.ListAllByDeveloperIdAsync(request.DeveloperId, cancellationToken) 
                        ?? throw new NotFoundException($"Any tasks to developer {request.DeveloperId} not found.");

            return _mapper.Map<List<TaskDto>>(tasks);
        }
    }
}
