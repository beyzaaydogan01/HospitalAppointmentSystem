using HospitalAppointmentSystem.WebApi.Dtos.Appointments.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Appointments.Responses;
using HospitalAppointmentSystem.WebApi.Dtos.Doctors.Responses;
using HospitalAppointmentSystem.WebApi.Exceptions;
using HospitalAppointmentSystem.WebApi.Models;
using HospitalAppointmentSystem.WebApi.Models.ReturnModels;
using HospitalAppointmentSystem.WebApi.Repository.Concretes;
using HospitalAppointmentSystem.WebApi.Service.Abstracts;
using HospitalAppointmentSystem.WebApi.Service.Mappers;
using HospitalAppointmentSystem.WebApi.Validations;
using System.Net;
using System.Numerics;

namespace HospitalAppointmentSystem.WebApi.Service.Concretes;
public class AppointmentService : IAppointmentService
{
    private readonly AppointmentRepository _appointmentRepository;
    private readonly AppointmentMapper _appointmentMapper;
    private readonly ExceptionHandler _exceptionHandler;
    private readonly AppointmentValidation _appointmentValidation;

    public AppointmentService(AppointmentRepository appointmentRepository, 
        AppointmentMapper appointmentMapper,
        ExceptionHandler exceptionHandler,
        AppointmentValidation appointmentValidation)
    {
        _appointmentRepository = appointmentRepository;
        _appointmentMapper = appointmentMapper;
        _exceptionHandler = exceptionHandler;
        _appointmentValidation = appointmentValidation;

    }
    public ReturnModel<Appointment> Add(CreateAppointmentRequest create)
    {
        try
        {
            _appointmentValidation.AppointmentDateValidation(create.AppointmentDate); 
            Appointment appointment = _appointmentMapper.ConvertToEntity(create);
            _appointmentRepository.Add(appointment);
            return new ReturnModel<Appointment>
            {
                Success = true,
                Message = "Randevu oluşturuldu",
                Data = appointment,
                Code = HttpStatusCode.OK
            };
        }
        catch(Exception ex) 
        {
            return _exceptionHandler.ReturnModelOfException<Appointment>(ex);
        } 
    }

    public List<AppointmentResponseDto> GetAll()
    {
        List<Appointment> appointments = _appointmentRepository.GetAll();
        List<AppointmentResponseDto> responses = appointments.Select(x => _appointmentMapper.ConvertToResponse(x)).ToList();
        return responses;
    }

    public ReturnModel<AppointmentResponseDto>? GetById(Guid id)
    {
        try
        {
            Appointment? appointment = _appointmentRepository.GetById(id);
            _appointmentValidation.IdNotFoundValidation(id);
            AppointmentResponseDto responseDto = _appointmentMapper.ConvertToResponse(appointment);
            return new ReturnModel<AppointmentResponseDto>
            {
                Success = true,
                Message = "Id getirildi",
                Data = responseDto,
                Code = HttpStatusCode.OK
            };
        }
        catch(NotFoundException ex)
        {
            return _exceptionHandler.ReturnModelOfException<AppointmentResponseDto>(ex);
        }
    }

    public ReturnModel<Appointment>? Remove(CreateAppointmentRequest appointment)
    {
        try
        {
            Appointment deleted = _appointmentMapper.ConvertToEntity(appointment);
            _appointmentRepository.Remove(deleted);
            return new ReturnModel<Appointment>
            {
                Success = true,
                Message = "Silindi",
                Data = deleted,
                Code = HttpStatusCode.OK
            };
        }
        catch(Exception ex)
        {
           return _exceptionHandler.ReturnModelOfException<Appointment>(ex);
        }  
    }
    public Appointment OutdatedAppointment(Appointment appointment)
    {
        Appointment deleted = null;
        if (appointment.AppointmentDate < DateTime.Now)
        {
            deleted = _appointmentRepository.Remove(appointment);
        }
        return deleted;
    }
    public ReturnModel<Appointment>? Update(CreateAppointmentRequest appointment)
    {
        try
        {
            Appointment updated = _appointmentMapper.ConvertToEntity(appointment);
            _appointmentRepository.Update(updated);
            return new ReturnModel<Appointment>
            {
                Success = true,
                Message = "Randevu güncellendi",
                Data = updated,
                Code = HttpStatusCode.OK
            };
        }
        catch(Exception ex)
        {
            return _exceptionHandler.ReturnModelOfException<Appointment> (ex);
        }
    }

}
