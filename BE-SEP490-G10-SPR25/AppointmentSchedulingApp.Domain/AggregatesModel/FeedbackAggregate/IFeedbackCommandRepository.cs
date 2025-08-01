using AppointmentSchedulingApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.FeedbackAggregate
{
    public interface IFeedbackCommandRepository:IGenericCommandRepository<Feedback>
    {
       
        //Task<IEnumerable<Feedback>> GetFeedbacksByServiceId(int serviceId);
    }
} 