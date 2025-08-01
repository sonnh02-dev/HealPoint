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
using AppointmentSchedulingApp.Domain.Commons;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using AppointmentSchedulingApp.Infrastructure.Persistence.Repositories;

namespace AppointmentSchedulingApp.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationCommandDbContext _dbContext;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(ApplicationCommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lazy-loaded Command Repositories

        private IDoctorCommandRepository? _doctorCommandRepository;
        public IDoctorCommandRepository DoctorCommandRepository =>
            _doctorCommandRepository ??= new DoctorCommandRepository(_dbContext);

        private IPatientCommandRepository? _patientCommandRepository;
        public IPatientCommandRepository PatientCommandRepository =>
            _patientCommandRepository ??= new PatientCommandRepository(_dbContext);

        private IMedicalRecordCommandRepository? _medicalRecordCommandRepository;
        public IMedicalRecordCommandRepository MedicalRecordCommandRepository =>
            _medicalRecordCommandRepository ??= new MedicalRecordCommandRepository(_dbContext);

        private IAppointmentCommandRepository? _appointmentCommandRepository;
        public IAppointmentCommandRepository AppointmentCommandRepository =>
            _appointmentCommandRepository ??= new ReservationCommandRepository(_dbContext);

        private IServiceCommandRepository? _serviceCommandRepository;
        public IServiceCommandRepository ServiceCommandRepository =>
            _serviceCommandRepository ??= new ServiceCommandRepository(_dbContext);

        private ISpecialtyCommandRepository? _specialtyCommandRepository;
        public ISpecialtyCommandRepository SpecialtyCommandRepository =>
            _specialtyCommandRepository ??= new SpecialtyCommandRepository(_dbContext);

        private IUserProfileCommandRepository? _userProfileCommandRepository;
        public IUserProfileCommandRepository UserProfileCommandRepository =>
            _userProfileCommandRepository ??= new UserProfileCommandRepository(_dbContext);

       

        private IFeedbackCommandRepository? _feedbackCommandRepository;
        public IFeedbackCommandRepository FeedbackCommandRepository =>
            _feedbackCommandRepository ??= new FeedbackCommandRepository(_dbContext);

        private IPostCommandRepository? _postCommandRepository;
        public IPostCommandRepository PostCommandRepository =>
            _postCommandRepository ??= new PostCommandRepository(_dbContext);

        private ICommentCommandRepository? _commentCommandRepository;
        public ICommentCommandRepository CommentCommandRepository =>
            _commentCommandRepository ??= new CommentCommandRepository(_dbContext);

        private IDoctorScheduleCommandRepository? _doctorScheduleCommandRepository;
        public IDoctorScheduleCommandRepository DoctorScheduleCommandRepository =>
            _doctorScheduleCommandRepository ??= new DoctorScheduleCommandRepository(_dbContext);

        private IRoomCommandRepository? _roomCommandRepository;
        public IRoomCommandRepository RoomCommandRepository =>
            _roomCommandRepository ??= new RoomCommandRepository(_dbContext);

        private ISlotCommandRepository? _slotCommandRepository;
        public ISlotCommandRepository SlotCommandRepository =>
            _slotCommandRepository ??= new SlotCommandRepository(_dbContext);

        private IPaymentCommandRepository? _paymentCommandRepository;
        public IPaymentCommandRepository PaymentCommandRepository =>
            _paymentCommandRepository ??= new PaymentCommandRepository(_dbContext);

        private ICertificationCommandRepository? _certificationCommandRepository;
        public ICertificationCommandRepository CertificationCommandRepository =>
            _certificationCommandRepository ??= new CertificationCommandRepository(_dbContext);

        private IReceptionistCommandRepository? _receptionistCommandRepository;
        public IReceptionistCommandRepository ReceptionistCommandRepository =>
            _receptionistCommandRepository ??= new ReceptionistCommandRepository(_dbContext);

        // Save & Transaction methods

        public void Commit() => _dbContext.SaveChanges();
        public async Task CommitAsync() => await _dbContext.SaveChangesAsync();

        public void Rollback() => _dbContext.Dispose(); // or consider: Clear EF tracking only
        public async Task RollbackAsync() => await _dbContext.DisposeAsync();

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _dbContext.SaveChangesAsync();
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task ExecuteSqlRawAsync(string sql, params object[] parameters)
        {
            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }
}
