using APITesting.Models;
using RestSharp;

namespace APITesting.Controllers
{
    public class UserController
    {
        private static readonly string _baseURL = "https://reqres.in/api/users";

        // Get all users from the API
        public static int GetAllUsers()
        {
            try
            {
                var client = new RestClient(_baseURL);
                var request = new RestRequest("", Method.Get);
                var response = client.Execute(request);
                string responseContent = response.Content ?? "";
                if (response.IsSuccessful)
                {
                    return 200;
                }
                else
                {
                    var errorMessage = response.ErrorMessage;
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during network request: " + ex.Message);
                throw;
            }
        }

        // Add a new user to the API
        public string AddUser(User user)
        {
            try
            {
                var client = new RestClient(_baseURL);
                var request = new RestRequest("", Method.Post);

                request.AddJsonBody(user);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    return response.StatusCode.ToString();
                }
                else
                {
                    throw new Exception("Failed to add user. Error: " + response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during network request: " + ex.Message);
                throw;
            }
        }

        // Delete a user from the API based on the provided userId
        public static int DeleteUser(int userId)
        {
            try
            {
                var client = new RestClient($"{_baseURL}/{userId}");
                var request = new RestRequest("", Method.Delete);
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    return 200;
                }
                else
                {
                    var errorMessage = response.ErrorMessage;
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during network request: " + ex.Message);
                throw;
            }
        }
    }
}
