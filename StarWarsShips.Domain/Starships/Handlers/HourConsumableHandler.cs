using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Handlers
{
    public class HourConsumableHandler : ConsumableHandler
    {
        public override async Task<int> CalculateHours(string consumables)
        {
            if (consumables.Contains(" hour"))
            {
                return await Task.FromResult(1);
            }
            else
            {
                return await _successor.CalculateHours(consumables);
            }
        }
    }
}