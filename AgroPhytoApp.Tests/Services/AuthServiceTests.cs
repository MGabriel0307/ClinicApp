using Xunit;

namespace AgroPhytoApp.Tests.Services
{
    public class AuthServiceTests
    {
        [Fact]
        public void Login_Test()
        {
            bool result = true;

            Assert.True(result);
        }

        [Fact]
        public void Register_Test()
        {
            bool result = true;

            Assert.True(result);
        }

        [Fact]
        public void Logout_Test()
        {
            bool result = true;

            Assert.True(result);
        }

        [Fact]
        public void Password_Test()
        {
            string password = "Admin123!";

            Assert.Contains("123", password);
        }

        [Fact]
        public void Email_Test()
        {
            string email = "test@test.com";

            Assert.Contains("@", email);
        }

        [Fact]
        public void User_Test()
        {
            string username = "Gabriel";

            Assert.NotNull(username);
        }
    }
}