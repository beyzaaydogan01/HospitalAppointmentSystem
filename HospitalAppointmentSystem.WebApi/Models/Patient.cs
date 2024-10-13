
namespace HospitalAppointmentSystem.WebApi.Models;
public sealed class Patient : Entity<int>
{
    public Patient()
    {
        Name=string.Empty;
        Surname = string.Empty;
        Doctor=new Doctor();
    }
    public Patient(string name, string surname,int doctorId,Doctor doctor ,List<Appointment> appointments)
    {
        Name = name;
        Surname = surname;
        Appointments = appointments;
        DoctorId = doctorId;
        Doctor = doctor;
    }
    public string IdentityNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public List<Appointment> Appointments { get; set; }

}
