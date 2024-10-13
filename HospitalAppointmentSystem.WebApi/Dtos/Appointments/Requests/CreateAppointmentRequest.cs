using HospitalAppointmentSystem.WebApi.Models;

namespace HospitalAppointmentSystem.WebApi.Dtos.Appointments.Requests;

public sealed record CreateAppointmentRequest
    (DateTime AppointmentDate,
    int DoctorId,
    int PatientId
    );
