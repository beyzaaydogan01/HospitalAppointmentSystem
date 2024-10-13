using HospitalAppointmentSystem.WebApi.Contexts;
using HospitalAppointmentSystem.WebApi.Models;
using HospitalAppointmentSystem.WebApi.Repository.Abstracts;

namespace HospitalAppointmentSystem.WebApi.Repository.Concretes;

public class AppointmentRepository : BaseRepository<Appointment, Guid>
{
    public AppointmentRepository(MsSqlContext context) : base(context)
    {
    }
}
