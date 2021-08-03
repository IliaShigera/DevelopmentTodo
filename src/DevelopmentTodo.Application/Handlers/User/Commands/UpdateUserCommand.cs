using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DevelopmentTodo.Domain.DataTransferObjects.User;
using DevelopmentTodo.Domain.Exceptions;
using DevelopmentTodo.Domain.Interfaces.Repository;
using FluentValidation;
using MediatR;

namespace DevelopmentTodo.Application.Handlers.User.Commands
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByIdAsync(request.Id, cancellationToken);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;

            await _userRepository.UpdateAsync(user, cancellationToken);

            return _mapper.Map<UserDto>(user);
        }
    }

    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(prop => prop.FirstName).NotEmpty();
            RuleFor(prop => prop.LastName).NotEmpty();
        }
    }
}
