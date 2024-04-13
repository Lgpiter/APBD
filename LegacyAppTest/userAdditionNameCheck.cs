namespace LegacyAppTest;

using LegacyApp;

public class userAdditionNameCheck
{
    [Fact]
    public void AddUser_Should_Return_false_when_name_is_empty()
    {
        
        //Arrange
        string firstName = "";
        string lastName = "Doe";
        DateTime birthDate = new DateTime(2001, 12, 08);
        int clientId = 1;
        string email = "johndoe@gmail.com";
        var userService = new UserService();
            
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientId);
            
            
        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_false_when_name_is_null()
    {
        
        //Arrange
        string firstName = null;
        string lastName = "Doe";
        DateTime birthDate = new DateTime(2001, 12, 08);
        int clientId = 1;
        string email = "johndoe@gmail.com";
        var userService = new UserService();
            
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientId);
            
            
        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_false_when_last_name_is_null()
    {
        
        //Arrange
        string firstName = "Joe";
        string lastName = null;
        DateTime birthDate = new DateTime(2001, 12, 08);
        int clientId = 1;
        string email = "johndoe@gmail.com";
        var userService = new UserService();
            
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientId);
            
            
        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_false_when_last_name_is_empty()
    {
        
        //Arrange
        string firstName = "Joe";
        string lastName = "";
        DateTime birthDate = new DateTime(2001, 12, 08);
        int clientId = 1;
        string email = "johndoe@gmail.com";
        var userService = new UserService();
            
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientId);
            
            
        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_false_when_the_names_are_proper()
    {
        
        //Arrange
        string firstName = "Joe";
        string lastName = "Doe";
        DateTime birthDate = new DateTime(2001, 12, 08);
        int clientId = 1;
        string email = "johndoe@gmail.com";
        var userService = new UserService();
            
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientId);
            
            
        //Assert
        Assert.Equal(true, result);
    }
}