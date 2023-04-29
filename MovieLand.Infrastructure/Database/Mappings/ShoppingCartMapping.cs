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
    public sealed class ShoppingCartMapping
        : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("shopping_cart", "dbo");

            builder.HasKey(c => c.Id).HasName("id");
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.TotalPrice)
                .HasColumnName("total_price")
                .HasColumnType("REAL")
                .IsRequired();

            builder.Property(c => c.Currency)
                .HasColumnName("currency")
                .HasColumnType("TEXT")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(c => c.Status)
                .HasColumnName("status")
                .HasDefaultValue(ShoppingCartStatus.Pending);

            builder.HasMany(c => c.Items)
                 .WithOne(e  => e.ShoppingCart)
                 .HasForeignKey(e    => e.ShoppingCartId);
        }
    }
}
