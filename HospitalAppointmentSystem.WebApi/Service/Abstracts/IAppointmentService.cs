using HospitalAppointmentSystem.WebApi.Dtos.Appointments.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Appointments.Responses;
using HospitalAppointmentSystem.WebApi.Models;
using HospitalAppointmentSystem.WebApi.Models.ReturnModels;

namespace HospitalAppointmentSystem.WebApi.Service.Abstracts;
public interface IAppointmentService
{
    ReturnModel<Appointment> Add(CreateAppointmentRequest create);
    ReturnModel<Appointment>? Update(CreateAppointmentRequest appointment);
    ReturnModel<Appointment>? Remove(CreateAppointmentRequest appointment);
    Appointment OutdatedAppointment(Appointment appointment);
    List<AppointmentResponseDto> GetAll();
    ReturnModel<AppointmentResponseDto>? GetById(Guid id);
}
