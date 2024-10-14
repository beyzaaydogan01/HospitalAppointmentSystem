using HospitalAppointmentSystem.WebApi.Models;

namespace HospitalAppointmentSystem.WebApi.Dtos.Appointments.Responses;
public sealed record AppointmentResponseDto(
    DateTime AppointmentDate, 
    string DoctorName, 
    string PatientName
    );
