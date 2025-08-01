using AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.ReceptionistAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;
using AppointmentSchedulingApp.SharedKernel;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.PaymentAggregate;

public partial class Payment:Entity
{
    public int AppointmentId { get; set; }

    public int PayerId { get; set; }

    public DateTime PaymentDate { get; set; }= DateTime.Now;   

    public int? ReceptionistId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public string TransactionId { get; set; } = null!;

	public decimal Amount { get; set; }

    public virtual Patient Payer { get; set; } = null!;

    public virtual Receptionist? Receptionist { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;
}
