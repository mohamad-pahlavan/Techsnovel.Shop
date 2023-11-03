using AutoMapper;
using Techsnovel.Application.Common.Mappings;
using Techsnovel.Domain.Entities;

namespace Techsnovel.Application.Categories.Queries.GetProducts;

public class ProductDto : IMapFrom<Product>
{
    public int Id { get; init; }

    public int CategoryId { get; init; }

    public string? Name { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
    }
}
