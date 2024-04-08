namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        //Arrange

        var userService = new UserService();

        //Act

        var result = userService.AddUser(
            null,
            "Kowalski",
                "kowalskikowalcom",
            DateTime.Parse("2000-01-01"),
            1
        );
        //Assert
        
        //Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        //Arrange

        var userService = new UserService();

        //Act

        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalskikowalcom",
            DateTime.Parse("2000-01-01"),
            1
        );
        //Assert
        
        //Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        var userService = new UserService();

        //Act

        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Now.AddYears(-7),
            1
        );
        //Assert

        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
            //Arrange

            var userService = new UserService();
            
            //Act
            var result = userService.AddUser(
                "Jan",
                "Malewski",
                "malewski@gmail.pl",
                DateTime.Parse("2000-01-01"),
                2
            );
            //Assert
            
            Assert.True(result);
        }

    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        //Arrange

        var userService = new UserService();
            
        //Act
        var result = userService.AddUser(
            "Jan",
            "Smith",
            "smith@gmail.pl",
            DateTime.Parse("2000-01-01"),
            3
        );
        //Assert
            
        Assert.True(result);
    }
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        //Arrange

        var userService = new UserService();
            
        //Act
        var result = userService.AddUser(
            "Jan",
            "Kwiatkowski",
            "kwiatkowski@wp.pl",
            DateTime.Parse("2000-01-01"),
            5
        );
        //Assert
            
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        
        var userService = new UserService();
            
        //Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@wp.pl",
            DateTime.Parse("2000-01-01"),
            5
        );
        //Assert
            
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist(){
        
        var userService = new UserService();

        //Act

        Action action = () => userService.AddUser(
            "Jan",
            "Kowal",
            "kowal@gmail.com",
            DateTime.Parse("2000-01-01"),
            10
        );
        
        //Assert
        
        Assert.Throws<ArgumentException>(action);}

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        var userService = new UserService();

        //Act

        Action action = () => userService.AddUser(
            "Jan",
            "Andrzejewicz",
            "andrzejewicz@wp.pl",
            DateTime.Parse("2000-01-01"),
            6
        );
        
        //Assert
        
        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExist()
    {
        //Arrange

        var userService = new UserService();

        //Act

        Action action = () => userService.AddUser(
             "Jan",
             "Kowalski",
             "kowalski@kowal.com",
             DateTime.Parse("2000-01-01"),
             100
         );
        
        //Assert
        
        Assert.Throws<ArgumentException>(action);
    }
}