using LegacyApp;

namespace LegacyAppTest;

public class UnitTest1
{
    [Fact]
    public void AddUser_Should_Return_true_when_email_without_at_and_dot()
    {
        
            //Arrange
            string firstName = "John";
            string lastName = "Doe";
            DateTime birthDate = new DateTime(2001, 12, 08);
            int clientId = 1;
            string email = "doe";
            var userService = new UserService();
            
            //Act
            bool result = userService.AddUser(firstName, lastName, email, birthDate, clientId);
            
            
            //Assert
            Assert.Equal(false, result);
    }
}