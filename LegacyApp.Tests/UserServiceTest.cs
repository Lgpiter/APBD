using System;
using JetBrains.Annotations;
using LegacyApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LegacyApp.Tests;

[TestClass]
[TestSubject(typeof(UserService))]
public class UserServiceTest
{

    [TestMethod]
    public void AddUser_ReturnsTrue()
    {
        //Arange
        string firstName = "John";
        string lastName = "Doe";
        string email = "john@example.com";
        DateTime birthDate = new DateTime(2001, 12, 08);
        int clientId = 1;
        
        //Act
        bool result = userService.AddUser("John", "Doe", "john@example.com", new DateTime(1990, 1, 1), 1);
        
    }
}