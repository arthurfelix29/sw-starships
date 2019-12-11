using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Handlers
{
    public class UnknownConsumableHandler : ConsumableHandler
    {
        public override async Task<int> CalculateHours(string consumables)
        {
            if (consumables.Contains("unknown") || string.IsNullOrWhiteSpace(consumables))
            {
                return await Task.FromResult(0);
            }
            else
            {
                return await _successor.CalculateHours(consumables);
            }
        }
    }
}