using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Handlers
{
    public class MonthsConsumableHandler : ConsumableHandler
    {
        public override async Task<int> CalculateHours(string consumables)
        {
            if (consumables.Contains(" months"))
            {
                string months = consumables.Replace(" months", string.Empty);
                int monthsConsumable = int.Parse(months);
                int hoursConsumable = monthsConsumable * 720;

                return await Task.FromResult(hoursConsumable);
            }
            else
            {
                return await _successor.CalculateHours(consumables);
            }
        }
    }
}