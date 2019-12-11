using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Handlers
{
    public class YearConsumableHandler : ConsumableHandler
    {
        public override async Task<int> CalculateHours(string consumables)
        {
            if (consumables.Contains(" year"))
            {
                return await Task.FromResult(8760);
            }
            else
            {
                return await _successor.CalculateHours(consumables);
            }
        }
    }
}