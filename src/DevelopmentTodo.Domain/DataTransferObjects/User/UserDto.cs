using System.Collections.Generic;
using DevelopmentTodo.Domain.DataTransferObjects.Task;
using DevelopmentTodo.Domain.Entities;
using DevelopmentTodo.Domain.Enums;

namespace DevelopmentTodo.Domain.DataTransferObjects.User
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserStatus Status { get; set; }

        public ICollection<TaskDto> ProviderTasks { get; set; }
        public ICollection<TaskDto> DeveloperTasks { get; set; }
    }
}
