using HospitalAppointmentSystem.WebApi.Dtos.Doctors.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Doctors.Responses;
using HospitalAppointmentSystem.WebApi.Models;

namespace HospitalAppointmentSystem.WebApi.Service.Mappers;
public class DoctorMapper
{
    public Doctor ConvertToEntity(CreateDoctorRequest request)
    {

        return new Doctor
        {
            Name = request.Name,
            Surname = request.Surname,
            Branch = request.Branch
        };
    }
    public DoctorResponseDto ConvertToResponse(Doctor doctor)
    {
        return new DoctorResponseDto
        (
            Name : doctor.Name,
            Surname : doctor.Surname,
            Branch : doctor.Branch
        );
    }
}
