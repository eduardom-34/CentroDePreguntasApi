using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentroDePreguntasApi.Models.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(u => u.UserId);

        // One to many with answers
      builder.HasMany(u => u.Answers)
          .WithOne(a => a.User)
          .HasForeignKey(a => a.UserId)
          .OnDelete(DeleteBehavior.Restrict);

          // One to many with questions
      builder.HasMany(u => u.Questions)
            .WithOne(q => q.User)
            .HasForeignKey(q => q.UserId)
            .OnDelete(DeleteBehavior.Restrict);
      
    }
}
