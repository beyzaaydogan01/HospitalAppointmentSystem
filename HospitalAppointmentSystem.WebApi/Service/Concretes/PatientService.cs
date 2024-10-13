using HospitalAppointmentSystem.WebApi.Dtos.Appointments.Responses;
using HospitalAppointmentSystem.WebApi.Dtos.Patients.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Patients.Responses;
using HospitalAppointmentSystem.WebApi.Exceptions;
using HospitalAppointmentSystem.WebApi.Models;
using HospitalAppointmentSystem.WebApi.Models.ReturnModels;
using HospitalAppointmentSystem.WebApi.Repository.Concretes;
using HospitalAppointmentSystem.WebApi.Service.Abstracts;
using HospitalAppointmentSystem.WebApi.Service.Mappers;
using System.Net;

namespace HospitalAppointmentSystem.WebApi.Service.Concretes;
public class PatientService : IPatientService
{
    private readonly PatientRepository _patientRepository;
    private readonly PatientMapper _patientMapper;
    private readonly ExceptionHandler _exceptionHandler;

    public PatientService(PatientRepository patientRepository,
        PatientMapper patientMapper,
        ExceptionHandler exceptionHandler)
    {
        _patientRepository = patientRepository;
        _patientMapper = patientMapper;
        _exceptionHandler = exceptionHandler;
    }

    public ReturnModel<Patient> Add(CreatePatientRequest create)
    {
        try
        {
            Patient patient = _patientMapper.ConvertToEntity(create);
            _patientRepository.Add(patient);
            return new ReturnModel<Patient>
            {
                Success = true,
                Message = "Hasta eklendi",
                Data = patient,
                Code = HttpStatusCode.OK
            };
        }
        catch(Exception ex) 
        {
            return _exceptionHandler.ReturnModelOfException<Patient>(ex);
        }
    }

    public List<PatientResponseDto> GetAll()
    {
        List<Patient> patients = _patientRepository.GetAll();
        List<PatientResponseDto> responseDtos = patients.Select(x=> _patientMapper.ConvertToResponse(x)).ToList();
        return responseDtos;
    }

    public ReturnModel<PatientResponseDto>? GetById(int id)
    {
        try
        {
            Patient patient = _patientRepository.GetById(id);
            PatientResponseDto responseDto = _patientMapper.ConvertToResponse(patient);
            return new ReturnModel<PatientResponseDto>
            {
                Success = true,
                Message = "Başarılı",
                Data = responseDto,
                Code = HttpStatusCode.OK
            };
        }
        catch(Exception ex)
        {
            return _exceptionHandler.ReturnModelOfException<PatientResponseDto>(ex);
        }
    }

    public ReturnModel<Patient>? Remove(CreatePatientRequest entity)
    {
        try
        {
            Patient deleted = _patientMapper.ConvertToEntity(entity);
            _patientRepository.Remove(deleted);
            return new ReturnModel<Patient>
            {
                Success = true,
                Message = "Silindi",
                Data = deleted,
                Code = HttpStatusCode.OK
            };
        }
        catch(Exception ex)
        {
            return _exceptionHandler.ReturnModelOfException<Patient>(ex);
        }
    }

    public ReturnModel<Patient>? Update(CreatePatientRequest entity)
    {
        try
        {
            Patient updated = _patientMapper.ConvertToEntity(entity);
            _patientRepository.Update(updated);
            return new ReturnModel<Patient>
            {
                Success = true,
                Message = "Güncellendi",
                Data = updated,
                Code = HttpStatusCode.OK
            };
        }
        catch(Exception ex)
        {
            return _exceptionHandler.ReturnModelOfException<Patient>(ex);
        }
    }
}
