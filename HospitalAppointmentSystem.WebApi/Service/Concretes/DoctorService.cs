using HospitalAppointmentSystem.WebApi.Dtos.Appointments.Responses;
using HospitalAppointmentSystem.WebApi.Dtos.Doctors.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Doctors.Responses;
using HospitalAppointmentSystem.WebApi.Exceptions;
using HospitalAppointmentSystem.WebApi.Models;
using HospitalAppointmentSystem.WebApi.Models.ReturnModels;
using HospitalAppointmentSystem.WebApi.Repository.Concretes;
using HospitalAppointmentSystem.WebApi.Service.Abstracts;
using HospitalAppointmentSystem.WebApi.Service.Mappers;
using System.Net;
using ValidationException = HospitalAppointmentSystem.WebApi.Exceptions.ValidationException;

namespace HospitalAppointmentSystem.WebApi.Service.Concretes;
public class DoctorService : IDoctorService
{
    private readonly DoctorRepository _doctorRepository;
    private readonly DoctorMapper _doctorMapper;
    private readonly ExceptionHandler _exceptionHandler;
    public DoctorService(DoctorRepository doctorRepository,
        DoctorMapper doctorMapper,
        ExceptionHandler exceptionHandler)
    {
        _doctorRepository = doctorRepository;
        _doctorMapper = doctorMapper;
        _exceptionHandler = exceptionHandler;

    }
    public ReturnModel<Doctor> Add(CreateDoctorRequest create)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(create.Name))
            {
                throw new ValidationException("Doktor adı boş geçilemez.");
            }
            Doctor doctor = _doctorMapper.ConvertToEntity(create);
            _doctorRepository.Add(doctor);
            return new ReturnModel<Doctor>
            {
                Success = true,
                Message = "Doktor eklendi",
                Data = doctor,
                Code = HttpStatusCode.OK
        };
        }
        catch(Exception ex)
        {
            return _exceptionHandler.ReturnModelOfException<Doctor>(ex);
        }
    }
    public List<DoctorResponseDto> GetAll()
    {
        List<Doctor> doctors = _doctorRepository.GetAll();
        List<DoctorResponseDto> responseDtos = doctors.Select(x => _doctorMapper.ConvertToResponse(x)).ToList();
        return responseDtos;    
    }

    public ReturnModel<DoctorResponseDto>? GetById(int id)
    {
        try
        {
            Doctor doctor = _doctorRepository.GetById(id);
            if (doctor == null)
            {
                throw new NotFoundException("Bu Id numarasına göre bir randevu mevcut değildir.");
            }
            DoctorResponseDto responseDtos = _doctorMapper.ConvertToResponse(doctor);
            return new ReturnModel<DoctorResponseDto>
            {
                Success = true,
                Message = "Id getirildi",
                Data = responseDtos,
                Code = HttpStatusCode.OK
            };
        }
        catch(Exception ex)
        {
            return _exceptionHandler.ReturnModelOfException<DoctorResponseDto>(ex);
        }
    }

    public ReturnModel<Doctor>? Remove(CreateDoctorRequest doctor)
    {
        try
        {
            Doctor deleted = _doctorMapper.ConvertToEntity(doctor);
            _doctorRepository.Remove(deleted);
            return new ReturnModel<Doctor>
            {
                Success = true,
                Message = "Silindi",
                Data = deleted,
                Code = HttpStatusCode.OK
            };
        }
        catch(Exception ex)
        {
            return _exceptionHandler.ReturnModelOfException<Doctor>(ex);
        }
    }

    public ReturnModel<Doctor>? Update(CreateDoctorRequest doctor)
    {
        try
        {
            Doctor updated = _doctorMapper.ConvertToEntity(doctor);
            _doctorRepository.Update(updated);
            return new ReturnModel<Doctor>
            {
                Success = true,
                Message = "Randevu güncellendi",
                Data = updated,
                Code = HttpStatusCode.OK
            };
        }
        catch(Exception ex) 
        {
            return _exceptionHandler.ReturnModelOfException<Doctor>(ex);
        }
    }
}
