
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class DoctorCommandRepository : GenericCommandRepository<Doctor>, IDoctorCommandRepository
	{
        public DoctorCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {
        }
        
        //public override IQueryable<Doctor> GetQueryable()
        //{
        //    return _entitySet
        //        .Include(d => d.DoctorNavigation)
        //        .Include(d => d.Specialties)
        //        .Include(d => d.Services)
        //        .Include(d => d.DoctorSchedules)
        //            .ThenInclude(ds => ds.Reservations)
        //        .AsNoTracking()
        //        .AsQueryable();
        //}
        
        //public override IQueryable<Doctor> GetQueryable(Expression<Func<Doctor, bool>> expression)
        //{
        //    return _entitySet
        //        .Where(expression)
        //        .Include(d => d.DoctorNavigation)
        //        .Include(d => d.Specialties)
        //            .ThenInclude(s => s.Doctors)
        //        .Include(d => d.Services)
        //        .Include(d => d.DoctorSchedules)
        //            .ThenInclude(ds => ds.Reservations)
        //                .ThenInclude(r => r.Feedback)
        //        .Include(d => d.DoctorSchedules)
        //            .ThenInclude(ds => ds.Service)
        //        .Include(d => d.DoctorSchedules)
        //            .ThenInclude(ds => ds.Room)
        //        .Include(d => d.DoctorSchedules)
        //            .ThenInclude(ds => ds.Slot)
        //        .AsNoTracking();
        //}
    }
}
