using System.Threading.Tasks;
using RestSharp;

namespace BacheloretteClient.Models
{
    class ApiHelper
    {
        public static async Task<string> GetAllBachelorette()
        {
            RestClient client = new RestClient("http://localhost:5000/api/");
            RestRequest request = new RestRequest($"bachelorettes", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
        public static async Task<string> GetBachelorette(int id)
        {
          RestClient client = new RestClient("http://localhost:5000/api");
          RestRequest request = new RestRequest($"bachelorettes/{id}", Method.GET);
          var response = await client.ExecuteTaskAsync(request);
          return response.Content;
        }
        public static async Task PostBachelorette(string newBachelorette)
        {
          RestClient client = new RestClient("http://localhost:5000/api");
          RestRequest request = new RestRequest($"bachelorettes/", Method.POST); 
          request.AddHeader("Content-Type", "application/json");
          request.AddJsonBody(newBachelorette);
          var response = await client.ExecuteTaskAsync(request);
        } 
        public static async Task PutBachelorette(int id, string newBachelorette)
        {
          RestClient client = new RestClient("http://localhost:5000/api");
          RestRequest request = new RestRequest($"bachelorettes/{id}", Method.PUT); 
          request.AddHeader("Content-Type", "application/json");
          request.AddJsonBody(newBachelorette);
          var response = await client.ExecuteTaskAsync(request);
        }
        public static async Task DeleteBachelorette(int id)
        {
          RestClient client = new RestClient("http://localhost:5000/api");
          RestRequest request = new RestRequest($"bachelorettes/{id}", Method.DELETE); 
          request.AddHeader("Content-Type", "application/json");
          var response = await client.ExecuteTaskAsync(request);
        }

        public static async Task<string> GetAllContestant(int bacheloretteId)
        {
            RestClient client = new RestClient($"http://localhost:5000/api/");  //$"bachelorettes/{id}"
            RestRequest request = new RestRequest($"bachelorettes/{bacheloretteId}/contestants", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
        public static async Task<string> GetContestant(int id, int bacheloretteId)
        {
          RestClient client = new RestClient("http://localhost:5000/api/");
          RestRequest request = new RestRequest($"bachelorettes/{bacheloretteId}/contestants/{id}", Method.GET);
          var response = await client.ExecuteTaskAsync(request);
          return response.Content;
        }
        public static async Task PostContestant(string newBachelorette)
        {
          RestClient client = new RestClient("http://localhost:5000/api/");
          RestRequest request = new RestRequest($"contestants/", Method.POST); 
          request.AddHeader("Content-Type", "application/json");
          request.AddJsonBody(newBachelorette);
          var response = await client.ExecuteTaskAsync(request);
        } 
        public static async Task PutContestant(int id, string newBachelorette)
        {
          RestClient client = new RestClient("http://localhost:5000/api/");
          RestRequest request = new RestRequest($"contestants/{id}", Method.PUT); 
          request.AddHeader("Content-Type", "application/json");
          request.AddJsonBody(newBachelorette);
          var response = await client.ExecuteTaskAsync(request);
        }
        public static async Task DeleteContestant(int id)
        {
          RestClient client = new RestClient("http://localhost:5000/api/");
          RestRequest request = new RestRequest($"contestants/{id}", Method.DELETE); 
          request.AddHeader("Content-Type", "application/json");
          var response = await client.ExecuteTaskAsync(request);
        }
    }
}