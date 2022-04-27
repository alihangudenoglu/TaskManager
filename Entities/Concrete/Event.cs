using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Event:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
    }
}
