using System.Threading.Tasks;

namespace StarWarsShips.Domain.Starships.Handlers
{
    public abstract class ConsumableHandler
    {
        protected ConsumableHandler _successor;

        public void SetSuccessor(ConsumableHandler successor) => _successor = successor;

        public abstract Task<int> CalculateHours(string consumables);
    }
}