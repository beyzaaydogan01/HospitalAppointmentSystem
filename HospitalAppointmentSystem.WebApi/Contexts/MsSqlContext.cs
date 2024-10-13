using HospitalAppointmentSystem.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentSystem.WebApi.Contexts;

public class MsSqlContext : DbContext
{
    public MsSqlContext(DbContextOptions opt) : base(opt)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1453; Database=HospitalAppointmentManagement; " +
                                    "User=sa; Password=admin123456789; TrustServerCertificate=true");
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient> Patients { get; set; }
}
