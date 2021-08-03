using System.Collections.Generic;
using DevelopmentTodo.Domain.Entities.Common;
using DevelopmentTodo.Domain.Enums;

namespace DevelopmentTodo.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserStatus Status { get; set; }

        public ICollection<TaskEntity> ProviderTasks { get; set; }
        public ICollection<TaskEntity> DeveloperTasks { get; set; }
    }
}
