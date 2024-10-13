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
    public string Name { get; set; }
    public string Surname { get; set; }
    public Branch Branch { get; set; }
    public List<Patient> Patients { get; set; }
    public List<Appointment> Appoinments { get; set; }
}
