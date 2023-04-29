using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieLand.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Infrastructure.Database.Mappings
{
    public sealed class MovieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("movie", "dbo");

            builder.HasKey(c => c.Id).HasName("id");
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("TEXT")
                .HasMaxLength(254)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnName("description")
                .HasColumnType("TEXT")
                .HasMaxLength(2049);

            builder.Property(c => c.Status)
                .HasColumnName("status")
                .HasDefaultValue(MovieStatus.Inactive);

            

            builder.Property(c => c.FileId)
              .HasColumnName("file_id")
              .HasColumnType("TEXT")
              .HasMaxLength(32);

            builder.Property(c => c.CategoryId)
                .HasColumnName("category_id")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.Property(c => c.PriceId)
                .HasColumnName("price_id")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.HasOne(c => c.Category)
                .WithMany(c => c.Movies)
                .HasForeignKey(c => c.CategoryId);

            builder.HasOne(c => c.Price)
                .WithOne(c => c.movie)
                .HasForeignKey<Movie>(c => c.PriceId)
                .IsRequired();

            
        }
    }
}