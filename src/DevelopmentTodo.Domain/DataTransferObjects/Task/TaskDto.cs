using DevelopmentTodo.Domain.DataTransferObjects.User;
using DevelopmentTodo.Domain.Enums;

namespace DevelopmentTodo.Domain.DataTransferObjects.Task
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public UserDto Provider { get; set; }
        public UserDto Developer { get; set; }
    }
}
