using AppointmentServer.Domain.Abstractions;

namespace AppointmentServer.Domain.Entities;
public sealed class Patient : Entity
{
    public string Name { get; set; }
    public string IdentityNumber { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
