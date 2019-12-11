using AutoMapper;
using StarWarsShips.Application.Interfaces;
using StarWarsShips.Application.ViewModels;
using StarWarsShips.Domain.Starships;
using StarWarsShips.Domain.Starships.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsShips.Application.Services
{
    public class StarshipService : IStarshipService
    {
        private readonly IMapper _mapper;
        private readonly IStarshipRepository _starshipRepository;

        public StarshipService(IMapper mapper, IStarshipRepository starshipRepository)
        {
            _mapper = mapper;
            _starshipRepository = starshipRepository;
        }

        public async Task<IEnumerable<StarshipViewModel>> GetAllStarshipsAsync(string mgltDistance)
        {
            decimal distance = !string.IsNullOrWhiteSpace(mgltDistance) ? decimal.Parse(mgltDistance) : 0;

            var starships = new List<Starship>();
            var starshipsDetails = await _starshipRepository.GetAllStarshipsAsync();

            foreach (var item in starshipsDetails)
            {
                Starship starship = await Starship.AddAsync(item.Name, item.MgltDistance, item.Consumables, distance);
                starships.Add(starship);
            }

            var orderedList = starships.OrderBy(x => x.Name);

            return _mapper.Map<IEnumerable<StarshipViewModel>>(orderedList).ToList();
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}