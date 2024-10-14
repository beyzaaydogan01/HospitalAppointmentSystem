using HospitalAppointmentSystem.WebApi.Models.Enums;

namespace HospitalAppointmentSystem.WebApi.Models;
public sealed class Doctor : Entity<int>
{
    public Doctor()
    {
        Patients = new List<Patient>();
        Appoinments = new List<Appointment>();
    }
    public Doctor(string name, string surname, Branch branch, List<Patient> patients, List<Appointment> appoinments)
    {
        Name = name;
        Surname = surname;
        Branch = branch;
        Patients = patients;
        Appoinments = appoinments;
    }
    private string name;
    private string surname;

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
    public string Surname {
        get
        {
            return surname;
        }
        set 
        { 
            if(string.IsNullOrEmpty(value))
            {
                throw new Exception("Soyisim alanı boş geçilemez");
            }
        } 
    }
    public Branch Branch { get; set; }
    public List<Patient> Patients { get; set; }
    public List<Appointment> Appoinments { get; set; }
}
