using APITesting.Controllers;
using APITesting.Models;
using FluentAssertions;
using NUnit.Framework;

namespace MockProject_ThanhLM10.Tests
{
    [TestFixture]
    [Description("Unit tests for UserController")]
    [Category("API Tests")]
    public class UserAPITest
    {
        private UserController _userController;

        [SetUp]
        public void SetUp()
        {
            _userController = new UserController();
        }

        [Test]
        [Order(1)]
        [Description("Test case to get all users")]
        public void VerifyGetAllUsers()
        {
            // Test retrieving all users from the API
            var result = UserController.GetAllUsers();

            // Assert that the result should be a success (HTTP status code 200)
            result.Should().Be(200);
        }

        [Test]
        [Order(2)]
        [Description("Test case to add a new user")]
        public void VerifyAddUser()
        {
            // Create a new user object with the required properties
            var newUser = new User
            {
                email = "leminhthanh1905@gmail.com",
                first_name = "Thanh",
                last_name = "Le",
                avatar = ""
            };

            // Test adding a new user to the API
            var result = _userController.AddUser(newUser);

            // Assert that the result should indicate a successful creation
            result.Should().Be("Created");
        }

        [Test]
        [Order(3)]
        [Description("Test case to delete a user")]
        public void VerifyDeleteUser()
        {
            // Test deleting a user from the API based on the provided user ID
            int result = UserController.DeleteUser(1);

            // Assert that the result should be a success (HTTP status code 200)
            result.Should().Be(200);
        }
    }
}
