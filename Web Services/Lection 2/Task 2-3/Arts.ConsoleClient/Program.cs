namespace Arts.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Model;

    public enum DataType
    {
        JSON,
        XML
    }

    public class Program
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:60920/") };

        public static void Main()
        {
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));

            var artists = GetAllArtists();
            foreach (var currentArtist in artists)
            {
                Console.WriteLine(string.Format("{0} - {1} from {2} born on {3}", currentArtist.Id, currentArtist.Name, currentArtist.Country, currentArtist.DateOfBirth));
            } 

            //AddNewArtist("Emil Dimitrov", "Bulgaria", new DateTime(1940,12,23), DataType.XML);
            //UpdateArtist(2, new Artist() { Country = "Bulgaria"}, DataType.XML);
            //DeleteArtist(3);
            //DeleteArtist(new Artist() { Id = 5});
        }
        
        public static ICollection<Artist> GetAllArtists()
        {
            HttpResponseMessage response = client.GetAsync("api/artists").Result; // Blocking call!
            ICollection<Artist> allArtists = new List<Artist>();

            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;

                foreach (var currentArtist in artists)
                {
                    allArtists.Add(currentArtist);
                } 
            }
            else Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            return allArtists;
        }

        public static Artist GetArtistById(int id)
        {
            Artist artist = GetAllArtists().Where(a => a.Id == id).First();

            return artist;
        }

        public static void AddNewArtist(string name, string country, DateTime date, DataType type)
        {
            var artist = new Artist 
                                { 
                                    Name = name, 
                                    Country = country, 
                                    DateOfBirth = date 
                                };

            HttpResponseMessage response = new HttpResponseMessage();

            if (type == DataType.JSON) response = client.PostAsJsonAsync("api/artists", artist).Result;
            else if (type == DataType.XML) response = client.PostAsXmlAsync("api/artists", artist).Result;
            
            if (response.IsSuccessStatusCode) Console.WriteLine("Artist added!");
            else Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }

        public static void UpdateArtist(int id, Artist newArtist, DataType type)
        {
            var artist = GetArtistById(id);

            if (newArtist.Name != null) artist.Name = newArtist.Name;
            if (newArtist.Country != null) artist.Country = newArtist.Country;
            if (newArtist.DateOfBirth.Year > 1000) artist.DateOfBirth = newArtist.DateOfBirth;

            HttpResponseMessage response = new HttpResponseMessage();

            if (type == DataType.JSON) response = client.PutAsJsonAsync(string.Format("api//artists//{0}", id), artist).Result;
            else if (type == DataType.XML) response = client.PutAsXmlAsync(string.Format("api//artists//{0}", id), artist).Result;

            if (response.IsSuccessStatusCode) Console.WriteLine("Artist updated!");
            else Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }

        public static Artist DeleteArtist(int id)
        {
            var artist = GetArtistById(id);

            var response = client.DeleteAsync(string.Format("api//artists//{0}", id)).Result;

            if (response.IsSuccessStatusCode) Console.WriteLine("Artist deleted!");
            else Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            return artist;
        }

        public static Artist DeleteArtist(Artist artist)
        {
            int id = GetAllArtists().Where(a => a.Id == artist.Id).First().Id;

            artist = DeleteArtist(id);

            return artist;
        }
    }
}
