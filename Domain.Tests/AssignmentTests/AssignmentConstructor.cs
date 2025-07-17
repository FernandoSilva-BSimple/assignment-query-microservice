using Domain.Models;

namespace Domain.Tests.AssignmentTests;

public class AssignmentConstructorTests
{

    [Fact]
    public void WhenCreatingAssignmentWithId_ThenAssignmentIsCreated()
    {
        //arrange
        Guid id = Guid.NewGuid(); ;
        Guid deviceId = Guid.NewGuid();
        Guid collaboratorId = Guid.NewGuid();
        var period = new PeriodDate(new DateOnly(2025, 7, 1), new DateOnly(2025, 7, 7));

        //act & assert
        new Assignment(id, deviceId, collaboratorId, period);
    }


}