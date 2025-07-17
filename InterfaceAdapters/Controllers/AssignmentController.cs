using Application.DTO;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi;

namespace InterfaceAdapters.Controllers;

[Route("api/assignments")]
[ApiController]
public class AssignmentController : ControllerBase
{
    private readonly IAssignmentService _assignmentService;

    public AssignmentController(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AssignmentDTO>>> GetAllAsync()
    {
        var assignments = await _assignmentService.GetAllAsync();
        return assignments.ToActionResult();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AssignmentDTO>> GetByIdAsync(Guid id)
    {
        var assignment = await _assignmentService.GetByIdAsync(id);
        return assignment.ToActionResult();
    }

    [HttpGet("device/{deviceId}")]
    public async Task<ActionResult<IEnumerable<AssignmentDTO>>> GetByDeviceIdAsync(Guid deviceId)
    {
        var assignments = await _assignmentService.GetByDeviceIdAsync(deviceId);
        return assignments.ToActionResult();
    }

    [HttpGet("collaborator/{collaboratorId}")]
    public async Task<ActionResult<IEnumerable<AssignmentDTO>>> GetByCollaboratorIdAsync(Guid collaboratorId)
    {
        var assignments = await _assignmentService.GetByCollaboratorIdAsync(collaboratorId);
        return assignments.ToActionResult();
    }

    [HttpGet("period/{startDate}/{endDate}")]
    public async Task<ActionResult<IEnumerable<AssignmentDTO>>> GetByPeriodDateAsync(DateOnly startDate, DateOnly endDate)
    {
        var periodDate = new PeriodDate(startDate, endDate);
        var assignments = await _assignmentService.GetByPeriodDateAsync(periodDate);
        return assignments.ToActionResult();
    }

    [HttpGet("{id}/details")]
    public async Task<ActionResult<AssignmentDetailsDTO>> GetAssignmentDetailsAsync(Guid id)
    {
        var assignmentDetails = await _assignmentService.GetAssignmentDetailsAsync(id);
        return assignmentDetails.ToActionResult();
    }

    [HttpGet("collaborator/{collaboratorId}/details")]
    public async Task<ActionResult<IEnumerable<AssignmentDetailsDTO>>> GetAllWithDetailsByCollaboratorIdAsync(Guid collaboratorId)
    {
        var result = await _assignmentService.GetAllWithDetailsByCollaboratorIdAsync(collaboratorId);
        return result.ToActionResult();
    }

    [HttpGet("with-details")]
    public async Task<ActionResult<IEnumerable<AssignmentDetailsDTO>>> GetAllWithDetailsAsync()
    {
        var assignmentDetails = await _assignmentService.GetAllWithDetailsAsync();
        return assignmentDetails.ToActionResult();
    }
}
