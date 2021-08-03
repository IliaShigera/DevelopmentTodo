using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DevelopmentTodo.Domain.DataTransferObjects.User;
using DevelopmentTodo.Domain.Exceptions;
using DevelopmentTodo.Domain.Interfaces.Repository;
using FluentValidation;
using MediatR;

namespace DevelopmentTodo.Application.Handlers.User.Queries
{
    public record GetUserByIdQuery(int Id) : IRequest<UserDto> { }

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByIdAsync(request.Id, cancellationToken)
                       ?? throw new NotFoundException($"User with id: {request.Id} not found.");

            return _mapper.Map<UserDto>(user);
        }
    }
}
