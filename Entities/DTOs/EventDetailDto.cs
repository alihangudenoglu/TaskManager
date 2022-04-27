using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class EventDetailDto
    {
        public string Filter { get; set; }
        public List<Event> Events { get; set; }
    }
}
