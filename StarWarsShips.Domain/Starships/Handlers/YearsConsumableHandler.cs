using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Handlers
{
    public class YearsConsumableHandler : ConsumableHandler
    {
        public override async Task<int> CalculateHours(string consumables)
        {
            if (consumables.Contains(" years"))
            {
                string years = consumables.Replace(" years", string.Empty);
                int yearsConsumable = int.Parse(years);
                int hoursConsumable = yearsConsumable * 8760;

                return await Task.FromResult(hoursConsumable);
            }
            else
            {
                return await _successor.CalculateHours(consumables);
            }
        }
    }
}