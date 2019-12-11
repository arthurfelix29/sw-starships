using StarWarsShips.Domain.Core.Models;
using StarWarsShips.Domain.Starships.Handlers;
using System;
using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships
{
    public class Starship : Entity
    {
        private Starship() { }

        public string Name { get; private set; }
        public int MgltDistance { get; private set; }
        public string Consumables { get; private set; }
        public int AmountStopsRequired { get; private set; }

        public static async Task<Starship> AddAsync(string name, string mgltDistance, string consumables, decimal distanceToCalculate)
        {
            _ = int.TryParse(mgltDistance, out int mglt);

            return await Task.FromResult(new Starship
            {
                Id = Guid.NewGuid(),
                Name = name,
                MgltDistance = mglt,
                Consumables = consumables,
                AmountStopsRequired = await CalculateAmountOfStopsAsync(consumables, mglt, distanceToCalculate)
            });
        }

        private static async Task<int> CalculateAmountOfStopsAsync(string consumables, int mgltDistance, decimal distanceToCalculate)
        {
            ConsumableHandler unknownConsumable = new UnknownConsumableHandler();
            ConsumableHandler hoursConsumable = new HoursConsumableHandler();
            ConsumableHandler hourConsumable = new HourConsumableHandler();
            ConsumableHandler daysConsumable = new DaysConsumableHandler();
            ConsumableHandler dayConsumable = new DayConsumableHandler();
            ConsumableHandler weeksConsumable = new WeeksConsumableHandler();
            ConsumableHandler weekConsumable = new WeekConsumableHandler();
            ConsumableHandler monthsConsumable = new MonthsConsumableHandler();
            ConsumableHandler monthConsumable = new MonthConsumableHandler();
            ConsumableHandler yearsConsumable = new YearsConsumableHandler();
            ConsumableHandler yearConsumable = new YearConsumableHandler();

            unknownConsumable.SetSuccessor(hoursConsumable);
            hoursConsumable.SetSuccessor(hourConsumable);
            hourConsumable.SetSuccessor(daysConsumable);
            daysConsumable.SetSuccessor(dayConsumable);
            dayConsumable.SetSuccessor(weeksConsumable);
            weeksConsumable.SetSuccessor(weekConsumable);
            weekConsumable.SetSuccessor(monthsConsumable);
            monthsConsumable.SetSuccessor(monthConsumable);
            monthConsumable.SetSuccessor(yearsConsumable);
            yearsConsumable.SetSuccessor(yearConsumable);

            var hours = await unknownConsumable.CalculateHours(consumables);

            return hours > 0 && mgltDistance > 0 ? await Task.FromResult((int)(distanceToCalculate / (hours * mgltDistance))) : await Task.FromResult(0);
        }
    }
}