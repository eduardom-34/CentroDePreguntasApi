using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CentroDePreguntasApi.Models.Configurations;

public class QuestionConfig : IEntityTypeConfiguration<Question>
{
  public void Configure(EntityTypeBuilder<Question> builder)
  {
    builder.HasKey(q => q.QuestionId);

    // Many to one with users
    builder.HasOne(q => q.User)
        .WithMany(u => u.Questions) 
        .HasForeignKey(q => q.UserId)
        .OnDelete(DeleteBehavior.Restrict);

    // on to Many with Answer
    builder.HasMany(q => q.Answers)
        .WithOne(a => a.Question)
        .HasForeignKey(a => a.QuestionId)
        .OnDelete(DeleteBehavior.Restrict);
  }
}
