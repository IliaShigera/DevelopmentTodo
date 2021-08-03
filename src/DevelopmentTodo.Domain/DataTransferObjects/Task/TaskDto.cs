using DevelopmentTodo.Domain.Enums;

namespace DevelopmentTodo.Domain.DataTransferObjects.Task
{
    public class TaskDto
    {
        public int Id { get; set; }

        public int ProviderId { get; set; }
        public int DeveloperId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public TaskStatus Status { get; set; }
    }
}
