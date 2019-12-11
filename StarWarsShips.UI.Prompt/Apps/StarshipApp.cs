using StarWarsShips.Application.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsShips.UI.Prompt.Apps
{
    public class StarshipApp
    {
        private readonly IStarshipService _starshipService;

        public StarshipApp(IStarshipService starshipService) => _starshipService = starshipService;

        public async Task Run()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Type the distance in mega lights (MGLT):");

                var mgltDistance = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nCalculating... Please wait.\n");

                var starships = await _starshipService.GetAllStarshipsAsync(mgltDistance);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nDisplaying total amount of stops required to make the distance between planets for star ships:\n");

                foreach (var starship in starships)
                {
                    Console.WriteLine($"{starship.Name}: {starship.AmountStopsRequired}");
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{starships.Count()} STAR SHIPS HAVE DISPLAYED SUCCESSFULLY!!!");

                Console.ReadKey();

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Fail: {ex.Message}");
            }
            finally
            {
                _starshipService?.Dispose();
            }
        }
    }
}