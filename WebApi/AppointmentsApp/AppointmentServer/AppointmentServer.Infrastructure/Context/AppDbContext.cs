using AppointmentServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentServer.Infrastructure.Context;
public sealed class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-3BJ5GK9\\SQLEXPRESS;Initial Catalog=AppointmentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Patient> Patients { get; set; }

}
