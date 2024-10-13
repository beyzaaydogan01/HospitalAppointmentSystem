using HospitalAppointmentSystem.WebApi.Dtos.Appointments.Responses;
using HospitalAppointmentSystem.WebApi.Models;

namespace HospitalAppointmentSystem.WebApi.Dtos.Patients.Responses;

public sealed record PatientResponseDto
    (string Name,
    string Surname
    );
