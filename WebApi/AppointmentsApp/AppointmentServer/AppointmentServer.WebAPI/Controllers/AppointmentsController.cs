using AppointmentServer.Domain.Entities;
using AppointmentServer.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentServer.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly AppDbContext context;
    public AppointmentsController()
    {
        context = new AppDbContext();
    }

    [HttpPost]
    public async Task<IActionResult> GetAppointments(GetAppointments request, CancellationToken cancellationToken)
    {
        DateTime date1 = DateTime.Parse(request.StartDate);
        DateTime date2 = DateTime.Parse(request.EndDate);

        var appointments =
            await context.Appointments.Where(p => p.Date >= date1 && p.Date <= date2)
            .Include(p => p.Patient)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        return Ok(appointments);
    }

    [HttpPost]
    public async Task<IActionResult> SetOrChangeAppointment(SetOrChangeAppointmentDto request, CancellationToken cancellationToken)
    {
        Patient patient = await context.Patients.Where(p => p.IdentityNumber == request.Patient.IdentityNumber).FirstOrDefaultAsync();

        if (patient == null)
        {
            patient = request.Patient;
        }

        Appointment appointment =
            await context.Appointments
                .Where(p => p.Date == DateTime.Parse(request.Date) && p.Hour == request.Hour)
                .FirstOrDefaultAsync();
        if (appointment == null)
        {
            appointment = new Appointment()
            {
                Date = DateTime.Parse(request.Date),
                Hour = request.Hour,
                Patient = patient
            };
            await context.AddAsync(appointment, cancellationToken);
        }
        else
        {
            appointment.Patient = patient;
        }

        await context.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> CancelAppointmentById(string id, CancellationToken cancellationToken)
    {
        Appointment appointment = await context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            return NotFound();
        }
        context.Remove(appointment);
        await context.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    [HttpGet("{identityNumber}")]
    public async Task<IActionResult> GetPatientByIdentityNumber(string identityNumber, CancellationToken cancellationToken)
    {
        Patient patient = await context.Patients.Where(p => p.IdentityNumber == identityNumber).AsNoTracking().FirstOrDefaultAsync();
        return Ok(patient);
    }
}

public sealed record GetAppointments(
    string StartDate,
    string EndDate);
public sealed record SetOrChangeAppointmentDto(    
    string Date,
    int Hour,
    Patient Patient);
