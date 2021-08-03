using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DevelopmentTodo.Domain.DataTransferObjects.Task;
using DevelopmentTodo.Domain.Exceptions;
using DevelopmentTodo.Domain.Interfaces.Repository;
using FluentValidation;
using MediatR;

namespace DevelopmentTodo.Application.Handlers.Task.Commands
{
    public class UpdateTaskCommand : IRequest<TaskDto>
    {
        public int TaskId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int DeveloperId { get; set; }
    }

    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateTaskHandler(ITaskRepository taskRepository, IUserRepository userRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.FindByIdAsync(request.TaskId, cancellationToken)
                       ?? throw new NotFoundException($"Task with id: {request.TaskId} not found.");

            var developer = await _userRepository.FindByIdAsync(request.TaskId, cancellationToken)
                            ?? throw new NotFoundException($"Developer with id: {request.DeveloperId} not found.");

            task.Name = request.Name;
            task.Description = request.Description;
            task.Developer = developer;

            await _taskRepository.UpdateAsync(task, cancellationToken);

            return _mapper.Map<TaskDto>(task);
        }
    }

    public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskValidator()
        {
            RuleFor(prop => prop.Name).NotEmpty();
            RuleFor(prop => prop.Description).NotEmpty();
        }
    }
}