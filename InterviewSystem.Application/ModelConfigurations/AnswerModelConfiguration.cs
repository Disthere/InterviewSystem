using InterviewSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSystem.Application.ModelConfigurations
{
    internal class AnswerModelConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answers");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Version).IsRequired().HasMaxLength(512);
            builder.Property(x => x.Votes).IsRequired();
            builder.Property(x => x.Percents).IsRequired();

        }
    }
}
