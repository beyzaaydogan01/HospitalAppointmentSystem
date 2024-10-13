using HospitalAppointmentSystem.WebApi.Contexts;
using HospitalAppointmentSystem.WebApi.Models;
using HospitalAppointmentSystem.WebApi.Repository.Abstracts;

namespace HospitalAppointmentSystem.WebApi.Repository.Concretes;

public class PatientRepository : BaseRepository<Patient, int>
{
    public PatientRepository(MsSqlContext context) : base(context)
    {
    }
}
