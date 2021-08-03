using AutoMapper;
using DevelopmentTodo.Domain.DataTransferObjects.User;
using DevelopmentTodo.Domain.Entities;

namespace DevelopmentTodo.Application.MapperConfiguration
{
    public class UserMapperConfiguration : Profile
    {
        public UserMapperConfiguration()
        {
            CreateMap<UserEntity, UserDto>();
        }
    }
}
