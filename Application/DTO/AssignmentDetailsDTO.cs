using Domain.Models;

namespace Application.DTO;

public class AssignmentDetailsDTO
{
    public Guid Id { get; set; }
    public Guid DeviceId { get; set; }
    public Guid CollaboratorId { get; set; }
    public PeriodDate PeriodDate { get; set; }
    public string CollaboratorName { get; set; }
    public string CollaboratorEmail { get; set; }
    public string DeviceDescription { get; set; }
    public string DeviceBrand { get; set; }
    public string DeviceModel { get; set; }
    public string DeviceSerialNumber { get; set; }


    public AssignmentDetailsDTO() { }

    public AssignmentDetailsDTO(
    Guid id,
    Guid deviceId,
    Guid collaboratorId,
    PeriodDate periodDate,
    string collaboratorName,
    string collaboratorEmail,
    string deviceDescription,
    string deviceBrand,
    string deviceModel,
    string deviceSerialNumber)
    {
        Id = id;
        DeviceId = deviceId;
        CollaboratorId = collaboratorId;
        PeriodDate = periodDate;
        CollaboratorName = collaboratorName;
        CollaboratorEmail = collaboratorEmail;
        DeviceDescription = deviceDescription;
        DeviceBrand = deviceBrand;
        DeviceModel = deviceModel;
        DeviceSerialNumber = deviceSerialNumber;
    }

}