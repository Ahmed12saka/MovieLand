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
    public sealed class ShoppingCartItemMapping : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable("shopping_cart_item", "dbo");

            builder.HasKey(c => c.Id).HasName("id");
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.MovieId)
                .HasColumnName("movie_id")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.Property(c => c.ShoppingCartId)
                .HasColumnName("shopping_cart_id")
                .HasColumnType("INTEGER")
                .IsRequired();

            builder.HasOne(c => c.ShoppingCart)
                .WithMany(c => c.Items)
                .HasForeignKey(c => c.ShoppingCartId);

            builder.HasOne(c => c.Movie)
                .WithMany()
                .HasForeignKey(c => c.MovieId);
        }
    }


}
