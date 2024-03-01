using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain;

namespace ProductService.DataAccess.Configuration
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable(nameof(Product));
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Code).IsRequired();
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.Status).HasConversion<string>();
            entity.Property(p => p.Image);
            entity.Property(p => p.Description);

            entity.OwnsMany(p => p.Covers, opts =>
            {
                opts.Property(c => c.Code);
                opts.Property(c => c.Name);
                opts.Property(c => c.Description);
                opts.Property(c => c.SumInsured);
                opts.Property(c => c.Optional);
            });

            entity.HasMany( p => p.Questions)
                .WithOne(x => x.Product)
                .IsRequired(true);
        }
    }

    internal class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> entity)
        {
            entity.ToTable(nameof(Question));
            entity.HasKey(q => q.Id);
            entity
                 .HasDiscriminator<int>("QuestionType")
                 .HasValue<Question>(0)
                 .HasValue<NumericQuestion>(1)
                 .HasValue<DateQuestion>(2)
                 .HasValue<ChoiceQuestion>(3);
            entity.HasOne(p => p.Product)
                .WithMany(p => p.Questions);
            entity.Property(q => q.Code).IsRequired();
            entity.Property(q => q.Index).IsRequired();
            entity.Property(q => q.Text).IsRequired();
        }
    }

    internal class ChoiceQuestionConfig : IEntityTypeConfiguration<ChoiceQuestion>
    {
        public void Configure(EntityTypeBuilder<ChoiceQuestion> entity)
        {
            entity.HasBaseType<Question>();
            entity.HasMany(c => c.Choices);
        }
    }

    internal class ChoiceConfig : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> entity)
        {
            entity.ToTable("Choice");
            entity.HasKey("Code");
            entity.Property(x => x.Label);
            entity.HasOne(q => q.Question).WithMany(c => c.Choices);

        }
    }

}
