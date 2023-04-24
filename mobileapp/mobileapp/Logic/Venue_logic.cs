using System;
using System.Collections.Generic;
using System.Text;
using mobileapp.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace mobileapp.Logic
{
    public class Venue_logic
    {
        public async static Task<List<Venue>> GetVenues(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();
            var url = Venue.GenerateURL(latitude, longitude);
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),
                    Headers =
                    {
                        { "Accept", "application/json" },
                        { "Authorization", "fsq3ZWRYu3eS2fTA/yWKllYBb7O7FmPXCeG+3xZVlc3AOt4=" }
                    }


                };
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);

            }

                //var ll = $"{ latitude},{ longitude}";
                //var request = new HttpRequestMessage
                //{
                //    Method = HttpMethod.Get,
                //    RequestUri = new Uri(url),
                //    Headers =
                //        {


                //            { "Accept", "application/json" },
                //            { "Authorization", "fsq3ZWRYu3eS2fTA/yWKllYBb7O7FmPXCeG+3xZVlc3AOt4=" }

                //        }
                //};

                //using (HttpClient client = new HttpClient())
                //{

                //    var response = await client.SendAsync(request);
                //    var json = response.Content.ReadAsStringAsync();
                //    Console.WriteLine(json);
                //var response = await client.GetAsync(url);
                //var json = response.Content.ReadAsStringAsync();
                //}
                return venues;
        }
    }
}
