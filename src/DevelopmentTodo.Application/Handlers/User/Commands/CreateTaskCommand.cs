using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DevelopmentTodo.Domain.DataTransferObjects.Task;
using DevelopmentTodo.Domain.Entities;
using DevelopmentTodo.Domain.Exceptions;
using DevelopmentTodo.Domain.Interfaces.Repository;
using FluentValidation;
using MediatR;
using TaskStatus = DevelopmentTodo.Domain.Enums.TaskStatus;

namespace DevelopmentTodo.Application.Handlers.User.Commands
{
    public class CreateTaskCommand : IRequest<TaskDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int ProviderId { get; set; }
        public int DeveloperId { get; set; }
    }

    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateTaskHandler(ITaskRepository taskRepository, IUserRepository userRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var provider = await _userRepository.FindByIdAsync(request.ProviderId, cancellationToken)
                           ?? throw new NotFoundException($"Provider with id: {request.ProviderId} not found.");

            var developer = await _userRepository.FindByIdAsync(request.DeveloperId, cancellationToken)
                           ?? throw new NotFoundException($"Developer with id: {request.DeveloperId} not found.");

            var task = await _taskRepository.AddAsync(new TaskEntity
            {
                Name = request.Name,
                Description = request.Description,
                Provider = provider,
                Developer = developer
            }, cancellationToken) ?? throw new BadRequestException($"Create task is failure.");

            return _mapper.Map<TaskDto>(task);
        }
    }

    public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskValidator()
        {
            RuleFor(prop => prop.Name).NotEmpty();
            RuleFor(prop => prop.Description).NotEmpty();
        }
    }
}
