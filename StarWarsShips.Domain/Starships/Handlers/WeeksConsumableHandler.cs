using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Handlers
{
    public class WeeksConsumableHandler : ConsumableHandler
    {
        public override async Task<int> CalculateHours(string consumables)
        {
            if (consumables.Contains(" weeks"))
            {
                string weeks = consumables.Replace(" weeks", string.Empty);
                int weeksConsumable = int.Parse(weeks);
                int hoursConsumable = weeksConsumable * 168;

                return await Task.FromResult(hoursConsumable);
            }
            else
            {
                return await _successor.CalculateHours(consumables);
            }
        }
    }
}