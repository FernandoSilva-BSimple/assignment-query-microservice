using Domain.Factory;
using Domain.Factory.AssignmentFactory;
using Domain.IRepository;
using Domain.Models;
using Domain.Visitor;
using Moq;

namespace Domain.Tests.AssignmentTests;

public class AssignmentFactoryTests
{
    [Fact]
    public void WhenCreatingAssignmentWithValidFieldsAndId_ThenAssignmentIsCreated()
    {
        //arrange
        var assignmentFactory = new AssignmentFactory();

        Guid id = Guid.NewGuid();
        Guid deviceId = Guid.NewGuid();
        Guid collaboratorId = Guid.NewGuid();
        var period = new PeriodDate(new DateOnly(2025, 7, 1), new DateOnly(2025, 7, 7));

        //act
        var result = assignmentFactory.Create(id, deviceId, collaboratorId, period);

        //assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(deviceId, result.DeviceId);
        Assert.Equal(collaboratorId, result.CollaboratorId);
        Assert.Equal(period, result.PeriodDate);
    }

    [Fact]
    public void WhenCreatingAssignmentFromVisitor_ThenAssignmentIsCreated()
    {
        //arrange
        var assignmentFactory = new AssignmentFactory();

        var id = Guid.NewGuid();
        var deviceId = Guid.NewGuid();
        var collaboratorId = Guid.NewGuid();
        var period = new PeriodDate(new DateOnly(2025, 7, 1), new DateOnly(2025, 7, 7));

        Mock<IAssignmentVisitor> assignmentVisitor = new Mock<IAssignmentVisitor>();
        assignmentVisitor.Setup(d => d.Id).Returns(id);
        assignmentVisitor.Setup(d => d.DeviceId).Returns(deviceId);
        assignmentVisitor.Setup(d => d.CollaboratorId).Returns(collaboratorId);
        assignmentVisitor.Setup(d => d.PeriodDate).Returns(period);

        //act
        var result = assignmentFactory.Create(assignmentVisitor.Object);

        //assert
        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.Equal(deviceId, result.DeviceId);
        Assert.Equal(collaboratorId, result.CollaboratorId);
        Assert.Equal(period, result.PeriodDate);
    }
}