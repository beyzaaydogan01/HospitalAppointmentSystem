namespace HospitalAppointmentSystem.WebApi.Models;
public sealed class Appointment : Entity<Guid>
{
    public Appointment()
    {
        Patient = new Patient();
        Doctor = new Doctor();
        CreatedDate = DateTime.Now;
    }
    public Appointment(DateTime appoinmentDate, int patientId, Patient patient, int doctorId, Doctor doctor)
    {
        AppointmentDate = appoinmentDate;
        PatientId = patientId;
        Patient = patient;
        DoctorId = doctorId;
        Doctor = doctor;
    }

    public DateTime AppointmentDate { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}
