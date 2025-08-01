using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.FeedbackAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.MedicalRecordAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PaymentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;
using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;

public partial class Appointment : AuditableEntity
{
    public int AppointmentId { get; set; }

    public int PatientId { get; set; }

    public int DoctorScheduleId { get; set; }

    public string? Reason { get; set; }

    public string? PriorExaminationImg { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Status { get; set; } = null!;

    public string? CancellationReason { get; set; }

    public UserProfile Creator { get; set; } = null!;

    public UserProfile? Modifier { get; set; } = null!;

    public DoctorSchedule DoctorSchedule { get; set; } = null!;

    public Feedback? Feedback { get; set; }

    public MedicalRecord? MedicalRecord { get; set; }

    public Patient Patient { get; set; } = null!;

    public Payment Payment { get; set; } = null!;

    public static Appointment Create(
    int patientId,
    int doctorScheduleId,
    DateTime appointmentDate,
    string reason,
    string? priorExaminationImg,
    int creatorId,
    Func<int, DateTime, bool> isDoctorAvailable
)
    {
        // Validate ngày hẹn phải lớn hơn thời điểm hiện tại
        if (appointmentDate <= DateTime.Now)
        {
            throw new ArgumentException("Ngày hẹn phải ở tương lai.");
        }

        // Kiểm tra bác sĩ có trống không
        if (!isDoctorAvailable(doctorScheduleId, appointmentDate))
        {
            throw new InvalidOperationException("Bác sĩ đã có lịch vào thời điểm này.");
        }

        // Nếu hợp lệ thì tạo mới
        var appointment = new Appointment
        {
            PatientId = patientId,
            DoctorScheduleId = doctorScheduleId,
            AppointmentDate = appointmentDate,



            Reason = reason,
            PriorExaminationImg = priorExaminationImg,
            Status = "Pending"
        };

        // Raise domain event (ghi nhận sự kiện đã xảy ra)
        appointment.Raise(new AppointmentCreatedEvent(patientId, appointment.AppointmentId, reason, appointmentDate,creatorId));



        return appointment;
    }

}
