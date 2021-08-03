using DevelopmentTodo.Domain.Entities.Common;
using DevelopmentTodo.Domain.Enums;

namespace DevelopmentTodo.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public UserEntity Provider { get; set; }
        public UserEntity Developer { get; set; }

        public int ProviderId { get; set; }
        public int DeveloperId { get; set; }
    }
}
