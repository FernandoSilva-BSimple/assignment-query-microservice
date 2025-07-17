using Domain.Factory;
using Domain.Factory.AssignmentFactory;
using Domain.IRepository;
using Domain.Visitor;
using Moq;

namespace Domain.Tests.UserDomainTests;

public class UserFactoryTests
{
    [Fact]
    public void WhenCreatingUserWithValidFieldsAndId_ThenUserIsCreated()
    {
        //arrange
        var userFactory = new UserFactory();

        string name = "Carlos";
        string email = "carlos@gmail.com";

        //act
        var result = userFactory.Create(It.IsAny<Guid>(), name, email);

        //assert
        Assert.NotNull(result);
        Assert.Equal(name, result.Name);
        Assert.Equal(email, result.Email);
    }

    [Fact]
    public void WhenCreatingUserFromVisitor_ThenUserIsCreated()
    {
        //arrange
        var userFactory = new UserFactory();

        Mock<IUserVisitor> userVisitor = new Mock<IUserVisitor>();
        userVisitor.Setup(d => d.Id).Returns(Guid.NewGuid());
        userVisitor.Setup(d => d.Name).Returns("Carlos");
        userVisitor.Setup(d => d.Email).Returns("carlos@gmail.com");

        //act
        var result = userFactory.Create(userVisitor.Object);

        //assert
        Assert.NotNull(result);
        Assert.Equal("Carlos", result.Name);
        Assert.Equal("carlos@gmail.com", result.Email);
    }
}