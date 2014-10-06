namespace TicTacToe.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using TicTacToe.Models;
    using TicTacToe.Web.Models;

    public class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:33257/") };

        public static void Main()
        {
            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));

            var user1 = new RegisterBindingModel()
                    {
                        Email = "aha@abv.bg",
                        Password = "121212",
                        ConfirmPassword = "121212"
                    };

            var user2 = new RegisterBindingModel()
                    {
                        Email = "qwe@abv.bg",
                        Password = "232323",
                        ConfirmPassword = "232323"
                    };

            //var creationresponse = CreateUser(user1);
            //if (creationresponse.StatusCode != HttpStatusCode.OK) Console.WriteLine("{0} ({1}) for user 1", (int)creationresponse.StatusCode, creationresponse.ReasonPhrase);

            //creationresponse = CreateUser(user2);
            //if (creationresponse.StatusCode != HttpStatusCode.OK) Console.WriteLine("{0} ({1}) for user 2", (int)creationresponse.StatusCode, creationresponse.ReasonPhrase);

            var user1Token = GetToken(user1);
            var user2Token = GetToken(user2);

            var gameID = CreateGame(user1Token);

            //JoinGame(gameID);

            HttpResponseMessage response = Client.GetAsync("api/games").Result; // Blocking call!

            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsAsync<IEnumerable<Game>>().Result;
                foreach (var p in products)
                {
                    //Console.WriteLine("{0,4} {1,-20} {2}", p.Id, p.Title, p.CreatedOn);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static string CreateGame(string userToken)
        {
            string gameID = string.Empty;

            HttpResponseMessage response = new HttpResponseMessage();
            response.Headers.Add("Authorization", "Bearer " + userToken);
            response = Client.PostAsJsonAsync("api/games/create", "").Result;

            return gameID;
        }

        private static string GetToken(RegisterBindingModel user)
        {
            string token = string.Empty;
            var reqData = new TokenData() 
                {
                    Grant_Type = "password",
                    Username = user.Email,
                    Password = user.Password
                };

            // TO DO: must fix content-type to application/x-www-form-urlencoded
            HttpResponseMessage response = Client.PostAsJsonAsync("token", reqData).Result;
            
            if (user.Password == "121212") token = "MdoFt_eTLYDZvge47-Ec_PWVrhkfxbHufUpetKC5U2RhZcOKfVUeTW6amlXh7pHzNMjqk9O8LCn0AyJ7HCgVjb4LtzI1amzxWZFTT-uG_RV9zHTnIgy41JSmBnGeHxMPPtSEKv1mjfYEcieE4ZuvpbnOtQI6j0009vlhOZzGrzofnvLDYN8hlyOWcH3WE7Za7Chu5TFYlBccwOkHNfnpuvbRkokm1xQT53-ox6OCNWwFOujEpmLteRdsQWSGgp8vWL2IOMenL5nwk3T7tdKRk3cTsuPtdnjS0hgYW1YNsSHtuNSezuB0kv3S88G35z_brImtIDcBNAPkpqLr2mjuVEsOLuqlDPyJ3Jg7hEKlqrwxXiraBqhgon7bbKyMAMJS0BFiaHERO1oaYOwwl0xT0flyrjtAqfeBES5dRFlUUqg-hTwWpCL0nypCHz44Mi-vOJht4ejViKI5Jjhc5hBLMkE6Gdtz2IfkxrkWcAiCU58";
            else token = "XZELYHyJoPRyIOG4SuApU1XTikA-s_fPDVmH6QCWJ4tSHWBm4HU-x0ou0Hi_Iv9dXHrXmujODFzOV1mv-Cv9opbp-Px7loX05Xj-eZe_DU1zlL1MJz_W0ZU85FUi7YFKM0duMCKwGzhzv2SIQy2QBlxsmus4yc5i9KhoXG7xiaG8D9HzZvdmFNGY6Jzx_Tz94KFI55rraFalxErdW_5qWsUrLxluhnGRD0VENo2rQSuhcSfHr5imB_ugNXslGKFe5bkM1azNem0K08kUmc_JoDoFmwSHZbPdS3yR9xy29pKA0crLRwOq9Uj0YiYMkH_AAw3_7MO-UgGJLxvSMarQLy0beWA50T5Vfk3ZCEWQbI9eDBDqRhV-ErwwXavtut4WXdFidg1mY3LyS8qyRVwFK2xrpnMzMuX2xXKG4Uzdn152INzAzxchPD9T0CDnlgSdBvWijGcANmvhyswaGqt3rosqpgflrOwrv9G4kx-2DY";

            return token;
        }

        private static HttpResponseMessage CreateUser(RegisterBindingModel user)
        {
            HttpResponseMessage response = Client.PostAsJsonAsync("api/account/register", user).Result;
            
            return response;
        }
    }

    public class TokenData
    {
        public string Grant_Type { get; set; }

        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
