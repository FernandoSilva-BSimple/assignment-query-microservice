using Domain.Factory;
using Domain.Factory.AssignmentFactory;
using Domain.IRepository;
using Domain.Visitor;
using Moq;

namespace Domain.Tests.CollaboratorTests;

public class CollaboratorFactoryTests
{
    [Fact]
    public void WhenCreatingCollaboratorWithValidFieldsAndId_ThenCollaboratorIsCreated()
    {
        //arrange
        var collaboratorFactory = new CollaboratorFactory();

        Guid id = Guid.NewGuid();
        Guid userId = Guid.NewGuid();

        //act
        var result = collaboratorFactory.Create(id, userId);

        //assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(userId, result.UserId);
    }

    [Fact]
    public void WhenCreatingCollaboratorFromVisitor_ThenCollaboratorIsCreated()
    {
        //arrange
        var collaboratorFactory = new CollaboratorFactory();

        var id = Guid.NewGuid();
        var userId = Guid.NewGuid();

        Mock<ICollaboratorVisitor> collaboratorVisitor = new Mock<ICollaboratorVisitor>();
        collaboratorVisitor.Setup(d => d.Id).Returns(id);
        collaboratorVisitor.Setup(d => d.UserId).Returns(userId);

        //act
        var result = collaboratorFactory.Create(collaboratorVisitor.Object);

        //assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(userId, result.UserId);
    }
}