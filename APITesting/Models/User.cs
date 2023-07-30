namespace APITesting.Models
{
    public class User
    {
        // The ID of the user
        public int id { get; set; }

        // The email address of the user
        public string email { get; set; }

        // The first name of the user
        public string first_name { get; set; }

        // The last name of the user
        public string last_name { get; set; }

        // The URL or path to the user's avatar image
        public string avatar { get; set; }
    }
}
