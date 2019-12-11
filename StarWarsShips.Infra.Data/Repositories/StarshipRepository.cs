using Newtonsoft.Json;
using StarWarsShips.Domain.Starships.Interfaces;
using StarWarsShips.Domain.Starships.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsShips.Infra.Data.Repositories
{
    public class StarshipRepository : IStarshipRepository
    {
        public async Task<IEnumerable<StarshipDetailsWrapper>> GetAllStarshipsAsync()
        {
            try
            {
                Uri baseAddress = new Uri("https://swapi.co/api");
                string nextUrl = baseAddress + "/starships/";

                List<StarshipDetailsWrapper> list = new List<StarshipDetailsWrapper>();

                do
                {
                    string json = await RequestAsync(nextUrl, HttpMethod.Get);
                    StarshipWrapper response = JsonConvert.DeserializeObject<StarshipWrapper>(json);

                    if (response != null && response.StarshipDetails.Any())
                    {
                        list.AddRange(response.StarshipDetails.ToList());
                    }

                    nextUrl = response.NextUrl ?? string.Empty;
                }
                while (!string.IsNullOrWhiteSpace(nextUrl));

                return list;
            }
            catch
            {
                throw;
            }
        }

        private async Task<string> RequestAsync(string url, HttpMethod httpMethod)
        {
            try
            {
                string result = string.Empty;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = httpMethod.ToString();

                HttpWebResponse httpWebResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream());
                result = await reader.ReadToEndAsync();
                reader.Dispose();

                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}