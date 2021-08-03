using AutoMapper;
using DevelopmentTodo.Domain.DataTransferObjects.Task;
using DevelopmentTodo.Domain.Entities;

namespace DevelopmentTodo.Application.MapperConfiguration
{
    public class TaskMapperConfiguration : Profile
    {
        public TaskMapperConfiguration()
        {
            CreateMap<TaskEntity, TaskDto>();
        }
    }
}
