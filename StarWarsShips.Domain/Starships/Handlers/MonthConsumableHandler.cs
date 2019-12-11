using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Handlers
{
    public class MonthConsumableHandler : ConsumableHandler
    {
        public override async Task<int> CalculateHours(string consumables)
        {
            if (consumables.Contains(" month"))
            {
                return await Task.FromResult(720);
            }
            else
            {
                return await _successor.CalculateHours(consumables);
            }
        }
    }
}