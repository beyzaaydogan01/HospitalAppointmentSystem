using HospitalAppointmentSystem.WebApi.Contexts;
using HospitalAppointmentSystem.WebApi.Models;
using HospitalAppointmentSystem.WebApi.Repository.Abstracts;

namespace HospitalAppointmentSystem.WebApi.Repository.Concretes;

public class DoctorRepository : BaseRepository<Doctor, int>
{
    public DoctorRepository(MsSqlContext context) : base(context)
    {
    }
}
