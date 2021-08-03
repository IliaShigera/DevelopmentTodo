using System;

namespace DevelopmentTodo.DAL.EF.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
