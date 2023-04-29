using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MovieLand.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Infrastructure.Database.Mappings
{
    public sealed class PriceMapping : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("price", "dbo");

            builder.HasKey(c => c.Id).HasName("id");
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Amount)
                .HasColumnName("amount")
                .HasColumnType("REAL")
                .IsRequired();

            builder.Property(c => c.Currency)
                .HasColumnName("currency")
                .HasColumnType("TEXT")
                .HasMaxLength(3)
                .IsRequired();

            builder.HasOne(c => c.movie)
                .WithOne(c => c.Price)
                .HasForeignKey<Movie>(c => c.PriceId)
                .IsRequired();
        }
    }
}
