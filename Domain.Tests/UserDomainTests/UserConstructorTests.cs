namespace Domain.Tests.UserDomainTests;

using Domain.Models;
using Moq;

public class UserConstructorTests
{

    [Fact]
    public void WhenCreatingUserWithId_ThenUserIsCreated()
    {
        //arrange
        Guid id = Guid.NewGuid(); ;
        string names = It.IsAny<string>();
        string email = It.IsAny<string>();

        //act & assert
        new User(id, names, email);
    }


}