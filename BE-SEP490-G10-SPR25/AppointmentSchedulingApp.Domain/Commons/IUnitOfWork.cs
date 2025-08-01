using System.Threading.Tasks;
using AppointmentSchedulingApp.Domain.AggregatesModel.CertificationAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.CommentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.FeedbackAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.MedicalRecordAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PaymentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.ReceptionistAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.RoomAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.SlotAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.SpecialtyAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;

namespace AppointmentSchedulingApp.Domain.Commons
{
    public interface IUnitOfWork
    {
        IDoctorCommandRepository DoctorCommandRepository { get; }
        IDoctorScheduleCommandRepository DoctorScheduleCommandRepository { get; }
        ICertificationCommandRepository CertificationCommandRepository { get; }

        IPatientCommandRepository PatientCommandRepository { get; }
        IMedicalRecordCommandRepository MedicalRecordCommandRepository { get; }
        IAppointmentCommandRepository AppointmentCommandRepository { get; }

        IServiceCommandRepository ServiceCommandRepository { get; }
        ISpecialtyCommandRepository SpecialtyCommandRepository { get; }

        IPostCommandRepository PostCommandRepository { get; }
        ICommentCommandRepository CommentCommandRepository { get; }
        IFeedbackCommandRepository FeedbackCommandRepository { get; }

        IUserProfileCommandRepository UserProfileCommandRepository { get; }
        IReceptionistCommandRepository ReceptionistCommandRepository { get; }

        IRoomCommandRepository RoomCommandRepository { get; }
        ISlotCommandRepository SlotCommandRepository { get; }

        IPaymentCommandRepository PaymentCommandRepository { get; }

        // Commit / rollback
        void Commit();
        Task CommitAsync();
        void Rollback();
        Task RollbackAsync();

        // Transaction support
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        // Raw SQL
        Task ExecuteSqlRawAsync(string sql, params object[] parameters);
    }
}
