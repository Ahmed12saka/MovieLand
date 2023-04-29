﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Application.Services.DTO
{
    public sealed class CreateMovieDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quanitity { get; set; }
        public long? CategoryId { get; set; }
        public decimal PriceAmount { get; set; }
        public string PriceCurrency { get; set; }
    }
    public sealed class UpdateMovieDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quanitity { get; set; }
    }
    public sealed class MovieDetailsDTO
    {
        public long? MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quanitity { get; set; }
        public string Price { get; set; }
    }
    public sealed class MovieShortDTO
    {
        public long? MovieId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
    public sealed class UpdateMoviePriceDTO
    {
        public decimal PriceAmount { get; set; }
        public string PriceCurrency { get; set; }
    }
    public sealed class ShoppingCartItemDTO
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Total { get; set; }
        public int Quantity { get; set; }
    }
    public sealed class ShoppingCartDTO
    {
        public long Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public IEnumerable<ShoppingCartItemDTO> Movies { get; set; }
    }
    public sealed class ShoppingCartShortDTO
    {
        public long Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public int MovieCount { get; set; }
    }
    public sealed class CreateUpdateCartDTO
    {
        public long MovieId { get; set; }
        public int MovieCount { get; set; }
    }

    public sealed class CreateUpdateCategoryDTO
    {
        public string Name { get; set; }
    }

    public sealed class CategoryShortDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

}
