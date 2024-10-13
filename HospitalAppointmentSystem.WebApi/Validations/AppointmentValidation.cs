using HospitalAppointmentSystem.WebApi.Exceptions;
using HospitalAppointmentSystem.WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HospitalAppointmentSystem.WebApi.Validations;
public class AppointmentValidation
{
    public void AppointmentDateValidation(DateTime appointmentDate)
    {
        if (appointmentDate < DateTime.Now.AddDays(3))
        {
            throw new InvalidAppointmentDateException("Randevunuzu minimum 3 gün sonrası için alabilirsiniz");
        }
    }

    public void IdNotFoundValidation(Guid id)
    {
        if (id == null)
        {
            throw new NotFoundException("Bu Id numarasına göre randevu bulunmamaktadır");
        }
    }
}
