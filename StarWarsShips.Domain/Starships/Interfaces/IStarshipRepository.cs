using StarWarsShips.Domain.Starships.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Interfaces
{
    public interface IStarshipRepository
    {
        Task<IEnumerable<StarshipDetailsWrapper>> GetAllStarshipsAsync();
    }
}