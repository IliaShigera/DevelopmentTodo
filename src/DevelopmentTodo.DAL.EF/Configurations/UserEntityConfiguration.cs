using DevelopmentTodo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevelopmentTodo.DAL.EF.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder
                .HasMany<TaskEntity>(u => u.ProviderTasks)
                .WithOne(t => t.Provider)
                .HasForeignKey(k => k.ProviderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany<TaskEntity>(u => u.DeveloperTasks)
                .WithOne(t => t.Developer)
                .HasForeignKey(k => k.DeveloperId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
