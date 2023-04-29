using AutoMapper;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.Extensions.DependencyInjection;
using MovieLand.Application.Models;
using MovieLand.Application.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieLand.Application.Configurations
{
    public static class AutoMapperConfiguration
    {
      public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MovieProfile).Assembly);
            return services;
        }
    }
    internal class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDetailsDTO>(MemberList.None)
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom<string>(src => src.Name))
                .ForMember(dest => dest.Price, opt=>opt.MapFrom(src=>$"{src.Price.Currency} {src.Price.Amount}"))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Quanitity, opt => opt.MapFrom(src => src.Quanitity));

            CreateMap<Movie, MovieShortDTO>(MemberList.None)
                .ForMember(dest=>dest.MovieId, opt=>opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => $"{src.Price.Amount} {src.Price.Currency}"))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CreateMovieDTO, Movie>(MemberList.None)
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => new Price
                (
                    src.PriceAmount,
                    src.PriceCurrency
                )));
            CreateMap<UpdateMovieDTO, Movie>(MemberList.None)
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));


        }


    }

    internal class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryShortDTO>(MemberList.None)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }


    internal class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartDTO>(MemberList.None)
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalPrice))
                   .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                   .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Items
                        .GroupBy(e => e.MovieId)
                        .Select(e => new ShoppingCartItemDTO
                        {
                            Name = e.First().Movie.Name,
                            Price = $"{e.First().Movie.Price.Amount} {e.First().Movie.Price.Currency}",
                            Total = $"{e.Sum(e => e.Movie.Price.Amount)} {e.First().Movie.Price.Currency}"


                        })));
            CreateMap<ShoppingCart, ShoppingCartShortDTO>(MemberList.None)
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalPrice))
              .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
              .ForMember(dest => dest.MovieCount, opt => opt.MapFrom(src => src.Items.Count));



        }
    }
} 
