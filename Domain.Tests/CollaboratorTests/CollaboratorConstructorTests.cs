using Domain.Models;

namespace Domain.Tests.CollaboratorTests;

public class CollaboratorsConstructorTests
{

    [Fact]
    public void WhenCreatingCollaboratorWithId_ThenCollaboratorIsCreated()
    {
        //arrange
        Guid id = Guid.NewGuid(); ;
        Guid userId = Guid.NewGuid();

        //act & assert
        new Collaborator(id, userId);
    }


}