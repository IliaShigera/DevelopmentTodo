using DevelopmentTodo.Common.Enums;
using DevelopmentTodo.DAL.EF.Entities.Common;

namespace DevelopmentTodo.DAL.EF.Entities
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
