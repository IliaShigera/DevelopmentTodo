using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopmentTodo.Domain.Entities;
using DevelopmentTodo.Domain.Enums;
using TaskStatus = DevelopmentTodo.Domain.Enums.TaskStatus;

namespace DevelopmentTodo.DAL.EF
{
    public static class DataSeed
    {
        public static async Task SeedAsync(DataContext context)
        {
            await context.Database.EnsureCreatedAsync();

            var usersExist = context.Users.Any();
            if (usersExist)
            {
                return;
            }

            #region user

            var users = Enumerable.Range(1, 5)
                .Select(i => new UserEntity
                {
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                    Status = UserStatus.Active
                }).ToArray();

            await context.Users.AddRangeAsync(users);

            await context.SaveChangesAsync();

            #endregion

            #region task

            var random = new Random();

            var tasks = Enumerable.Range(1, 25)
                .Select(i => new TaskEntity
                {
                    Name = $"TaskName{i}",
                    Description = $"Description{i}",
                    Status = TaskStatus.ToDo,
                    Provider = random.NextItem(users),
                    Developer = random.NextItem(users)
                }).ToArray();

            await context.Tasks.AddRangeAsync(tasks);

            await context.SaveChangesAsync();

            #endregion

        }

        private static T NextItem<T>(this Random rnd, IList<T> list)
        {
            return list[rnd.Next(list.Count())];
        }
    }
}
