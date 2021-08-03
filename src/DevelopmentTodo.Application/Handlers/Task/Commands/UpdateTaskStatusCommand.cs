using DevelopmentTodo.Domain.DataTransferObjects.Task;
using MediatR;
using System.Threading;
using DevelopmentTodo.Domain.Interfaces.Repository;
using System.Threading.Tasks;
using AutoMapper;
using DevelopmentTodo.Domain.Exceptions;
using FluentValidation;
using FluentValidation.Validators;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace DevelopmentTodo.Application.Handlers.Task.Commands
{
    public class UpdateTaskStatusCommand : IRequest<TaskDto>
    {
        public int TaskId { get; set; }

        public Domain.Enums.TaskStatus Status { get; set; }
    }

    public class UpdateTaskStatusHandler : IRequestHandler<UpdateTaskStatusCommand, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public UpdateTaskStatusHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.FindByIdAsync(request.TaskId, cancellationToken)
                       ?? throw new NotFoundException($"Task with id: {request.TaskId} not found.");

            task.Status = request.Status;

            await _taskRepository.UpdateAsync(task, cancellationToken);

            return _mapper.Map<TaskDto>(task);
        }
    }

    public class UpdateTaskStatusValidator : AbstractValidator<UpdateTaskStatusCommand>
    {
        public UpdateTaskStatusValidator()
        {
            RuleFor(prop => prop.Status).NotEmpty();
        }
    }
}
