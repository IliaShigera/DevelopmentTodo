using System;

namespace DevelopmentTodo.Domain.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
