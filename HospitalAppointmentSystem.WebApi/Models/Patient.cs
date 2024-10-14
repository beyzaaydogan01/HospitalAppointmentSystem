
namespace HospitalAppointmentSystem.WebApi.Models;
public sealed class Patient : Entity<int>
{
    public Patient()
    {
        Name=string.Empty;
        Surname = string.Empty;
        Doctor=new Doctor();
    }
    public Patient(string identityNumber,string name, string surname,int doctorId,Doctor doctor ,List<Appointment> appointments)
    {
        IdentityNumber = identityNumber;
        Name = name;
        Surname = surname;
        Appointments = appointments;
        DoctorId = doctorId;
        Doctor = doctor;
    }
    private string name;
    private string surname;
    public string IdentityNumber { get; set; }
    public string Name
    {
        get
        {
            return Name;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("İsim alanı boş geçilemez");
            }
            name = value;
        }
    }
    public string Surname
    {
        get
        {
            return surname;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Soyisim alanı boş geçilemez");
            }
        }
    }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public List<Appointment> Appointments { get; set; }

}
