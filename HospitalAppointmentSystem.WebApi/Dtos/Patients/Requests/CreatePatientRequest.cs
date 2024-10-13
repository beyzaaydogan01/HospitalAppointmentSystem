namespace HospitalAppointmentSystem.WebApi.Dtos.Patients.Requests;

public sealed record CreatePatientRequest
    (string IdentityNumber,
    string Name,
    string Surname,
    int DoctorId
    );
