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
    public record GetAllProviderTasksQuery(int ProviderId) : IRequest<List<TaskDto>> { }

    public class GetAllProviderTasksHandler : IRequestHandler<GetAllProviderTasksQuery, List<TaskDto>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetAllProviderTasksHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<TaskDto>> Handle(GetAllProviderTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.ListAllByProviderIdAsync(request.ProviderId, cancellationToken)
                        ?? throw new NotFoundException($"Any tasks from provider {request.ProviderId} not found.");

            return _mapper.Map<List<TaskDto>>(tasks);
        }
    }
}
