using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DevelopmentTodo.Domain.DataTransferObjects.User;
using MediatR;

namespace DevelopmentTodo.Application.Handlers.User.Queries
{
    public record GetAllUsersQuery : IRequest<IList<UserDto>> { }

    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IList<UserDto>>
    {
        public Task<IList<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
