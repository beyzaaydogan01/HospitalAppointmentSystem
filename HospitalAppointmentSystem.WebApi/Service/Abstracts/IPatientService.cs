using HospitalAppointmentSystem.WebApi.Dtos.Patients.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Patients.Responses;
using HospitalAppointmentSystem.WebApi.Models;
using HospitalAppointmentSystem.WebApi.Models.ReturnModels;
using System.Security.Cryptography;

namespace HospitalAppointmentSystem.WebApi.Service.Abstracts;
public interface IPatientService 
{
    ReturnModel<Patient> Add(CreatePatientRequest create);
    ReturnModel<Patient>? Update(CreatePatientRequest entity);
    ReturnModel<Patient>? Remove(CreatePatientRequest entity);
    List<PatientResponseDto> GetAll();
    ReturnModel<PatientResponseDto>? GetById(int id);
}
