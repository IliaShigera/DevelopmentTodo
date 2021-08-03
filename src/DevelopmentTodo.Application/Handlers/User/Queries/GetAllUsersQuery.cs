using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DevelopmentTodo.Domain.DataTransferObjects.User;
using DevelopmentTodo.Domain.Exceptions;
using DevelopmentTodo.Domain.Interfaces.Repository;
using MediatR;

namespace DevelopmentTodo.Application.Handlers.User.Queries
{
    public record GetAllUsersQuery : IRequest<List<UserDto>> { }

    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.ListAllAsync(cancellationToken)
                ?? throw new NotFoundException($"Any user in db not found.");

            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
