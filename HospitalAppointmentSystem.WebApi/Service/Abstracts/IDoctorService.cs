using HospitalAppointmentSystem.WebApi.Dtos.Doctors.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Doctors.Responses;
using HospitalAppointmentSystem.WebApi.Models;
using HospitalAppointmentSystem.WebApi.Models.ReturnModels;
using System.Security.Cryptography;

namespace HospitalAppointmentSystem.WebApi.Service.Abstracts;

public interface IDoctorService
{
    ReturnModel<Doctor> Add(CreateDoctorRequest create);
    ReturnModel<Doctor>? Update(CreateDoctorRequest doctor);
    ReturnModel<Doctor>? Remove(CreateDoctorRequest doctor);
    List<DoctorResponseDto> GetAll();
    ReturnModel<DoctorResponseDto>? GetById(int id);
}
