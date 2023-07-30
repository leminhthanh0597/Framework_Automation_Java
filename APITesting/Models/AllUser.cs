namespace APITesting.Models
{
    public class AllUser
    {
        // The current page number of the user collection
        public int page { get; set; }

        // The number of users per page
        public int per_page { get; set; }

        // The total number of users available
        public int total { get; set; }

        // The total number of pages in the user collection
        public int total_pages { get; set; }

        // The list of user objects in the collection
        public List<User> data { get; set; }
    }
}
