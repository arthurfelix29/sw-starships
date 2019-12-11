using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Handlers
{
    public class DaysConsumableHandler : ConsumableHandler
    {
        public override async Task<int> CalculateHours(string consumables)
        {
            if (consumables.Contains(" days"))
            {
                string days = consumables.Replace(" days", string.Empty);
                int daysConsumable = int.Parse(days);
                int hoursConsumable = daysConsumable * 24;

                return await Task.FromResult(hoursConsumable);
            }
            else
            {
                return await _successor.CalculateHours(consumables);
            }
        }
    }
}