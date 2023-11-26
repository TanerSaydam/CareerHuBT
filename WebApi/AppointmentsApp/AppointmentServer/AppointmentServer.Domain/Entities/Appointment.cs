using AppointmentServer.Domain.Abstractions;

namespace AppointmentServer.Domain.Entities;
public sealed class Appointment : Entity
{
    public DateTime Date { get; set; }
    public int Hour { get; set; }
    public string PatientId { get; set; }
    public Patient Patient { get; set; }
}
