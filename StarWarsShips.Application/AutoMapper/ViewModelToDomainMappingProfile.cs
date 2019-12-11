using AutoMapper;
using StarWarsShips.Application.ViewModels;
using StarWarsShips.Domain.Starships;

namespace StarWarsShips.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() => CreateMap<StarshipViewModel, Starship>();
    }
}