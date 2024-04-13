namespace LegacyAppTest;

using LegacyApp;

public class userAge
{
    [Fact]
    public void AddUser_Should_Return_false_when_the_name_under_22()
    {
        
        //Arrange
        string firstName = "Joe";
        string lastName = "Doe";
        DateTime birthDate = new DateTime(2005, 12, 08);
        int clientId = 1;
        string email = "johndoe@gmail.com";
        var userService = new UserService();
            
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientId);
            
            
        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_false_when_the_name_above_22()
    {
        
        //Arrange
        string firstName = "Joe";
        string lastName = "Doe";
        DateTime birthDate = new DateTime(2001, 12, 8);
        int clientId = 1;
        string email = "johndoe@gmail.com";
        var userService = new UserService();
            
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientId);
            
            
        //Assert
        Assert.Equal(true, result);
    }
}