using HospitalAppointmentSystem.WebApi.Dtos.Appointments.Responses;
using HospitalAppointmentSystem.WebApi.Dtos.Patients.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Patients.Responses;
using HospitalAppointmentSystem.WebApi.Models;

namespace HospitalAppointmentSystem.WebApi.Service.Mappers;
public class PatientMapper
{
    public Patient ConvertToEntity(CreatePatientRequest request)
    {
        return new Patient
        {
            Name = request.Name,
            Surname = request.Surname,
            DoctorId = request.DoctorId,
        };
    }

    public PatientResponseDto ConvertToResponse(Patient patient)
    {
        return new PatientResponseDto
        (
            Name : patient.Name,
            Surname : patient.Surname
        ); 
    }
}
