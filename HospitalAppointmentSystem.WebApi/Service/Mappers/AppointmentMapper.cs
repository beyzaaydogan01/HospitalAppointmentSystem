using HospitalAppointmentSystem.WebApi.Dtos.Appointments.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Appointments.Responses;
using HospitalAppointmentSystem.WebApi.Models;

namespace HospitalAppointmentSystem.WebApi.Service.Mappers;
public class AppointmentMapper
{
    public Appointment ConvertToEntity(CreateAppointmentRequest request)
    {
        return new Appointment
        {
            AppointmentDate = request.AppointmentDate,
            DoctorId = request.DoctorId,
            PatientId = request.PatientId,
        };
    }

    public AppointmentResponseDto ConvertToResponse(Appointment appointment)
    {
        return new AppointmentResponseDto
        (
            AppointmentDate : appointment.AppointmentDate,
            DoctorName : appointment.Doctor.Name,
            PatientName : appointment.Patient.Name
        );
    }
}
