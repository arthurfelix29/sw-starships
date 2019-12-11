using StarWarsShips.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsShips.Application.Interfaces
{
    public interface IStarshipService : IDisposable
    {
        Task<IEnumerable<StarshipViewModel>> GetAllStarshipsAsync(string mgltDistance);
    }
}