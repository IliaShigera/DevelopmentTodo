using System.Collections.Generic;
using DevelopmentTodo.Common.Enums;
using DevelopmentTodo.DAL.EF.Entities.Common;

namespace DevelopmentTodo.DAL.EF.Entities
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
