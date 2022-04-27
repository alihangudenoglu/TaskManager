using Core.Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEventService:IEntityService<Event>
    {
        IDataResult<List<EventDetailDto>> GetUserEventsByWeek(int userId);
        IDataResult<List<Event>> GetAllEventByUser(int userId);
        IDataResult<List<EventDetailDto>> GetUserEventsByMonth(int userId);
    }
}
