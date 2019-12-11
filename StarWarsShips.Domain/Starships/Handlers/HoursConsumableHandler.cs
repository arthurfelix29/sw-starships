using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Handlers
{
    public class HoursConsumableHandler : ConsumableHandler
    {
        public override async Task<int> CalculateHours(string consumables)
        {
            if (consumables.Contains(" hours"))
            {
                string hours = consumables.Replace(" hours", string.Empty);
                int hoursConsumable = int.Parse(hours);

                return await Task.FromResult(hoursConsumable);
            }
            else
            {
                return await _successor.CalculateHours(consumables);
            }
        }
    }
}