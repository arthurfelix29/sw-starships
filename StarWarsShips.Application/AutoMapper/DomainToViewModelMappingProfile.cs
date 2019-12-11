using AutoMapper;
using StarWarsShips.Application.ViewModels;
using StarWarsShips.Domain.Starships;

namespace StarWarsShips.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() => CreateMap<Starship, StarshipViewModel>();
    }
}