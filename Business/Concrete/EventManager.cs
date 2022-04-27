using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class EventManager : IEventService
    {
        IEventDal _eventDal;

        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public IResult Add(Event entity)
        {
            _eventDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Event entity)
        {
            _eventDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Event>> GetAll()
        {

            return new SuccessDataResult<List<Event>>(_eventDal.GetAll());
        }

        public IDataResult<Event> GetById(int id)
        {
            return new SuccessDataResult<Event>(_eventDal.Get(x => x.Id == id));
        }
        public IDataResult<List<Event>> GetAllEventByUser(int userId)
        {
            return new SuccessDataResult<List<Event>>(_eventDal.GetAll(x => x.UserId==userId));
        }
        public IDataResult<List<EventDetailDto>> GetUserEventsByMonth(int userId)
        {
            List<EventDetailDto> result = new List<EventDetailDto>();

            var allEvent = _eventDal.GetAll(x => x.UserId == userId);

            for (int i = 1; i <= 12; i++)
            {
                var result2 = new EventDetailDto();
                List<Event> events = new List<Event>();
                foreach (var item in allEvent)
                {
                    int monthNumber = GetMonthNumber(item.StartDate);
                    int monthNumberEnd = GetMonthNumber(item.EndDate);
                    if ((monthNumber == monthNumberEnd) && monthNumber == i || monthNumber < i && i < monthNumberEnd + 1)
                    {
                        events.Add(item);
                    }
                }

                if (events.Count != 0)
                {
                    result2.Filter = i + ".Ay";
                    result2.Events = events;
                    result.Add(result2);

                }
            }


            return new SuccessDataResult<List<EventDetailDto>>(result);
        }

        public IDataResult<List<EventDetailDto>> GetUserEventsByWeek(int userId)
        {
            List<EventDetailDto> result = new List<EventDetailDto>();
            
            var allEvent = _eventDal.GetAll(x => x.UserId == userId);
            
            for (int i = 1; i <= 52; i++)
            {
                var result2 = new EventDetailDto();
                List<Event> events = new List<Event>();
                foreach (var item in allEvent)
                {
                    int weekNumber = GetWeekNumber(item.StartDate);
                    int weekNumberEnd = GetWeekNumber(item.EndDate);
                    if ((weekNumber==weekNumberEnd)&&weekNumber==i|| weekNumber < i && i < weekNumberEnd + 1)
                    {
                        events.Add(item);
                    }
                }//18
                
                if (events.Count!=0)
                {
                    result2.Filter = i + "hafta";
                    result2.Events = events;
                    result.Add(result2);
                    
                }
            }


            return new SuccessDataResult<List<EventDetailDto>>(result);
        }

        public IResult Update(Event entity)
        {
            _eventDal.Update(entity);
            return new SuccessResult();
        }

        public int GetWeekNumber(DateTime Tarih)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(Tarih);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                Tarih = Tarih.AddDays(3);
            }
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(Tarih, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        }
        public int GetMonthNumber(DateTime Tarih)
        {          
            
            return CultureInfo.InvariantCulture.Calendar.GetMonth(Tarih);

        }
    }
}
