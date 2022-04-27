using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.IoC;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        IEventService _eventService;
        private IHttpContextAccessor _httpContextAccessor;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        [HttpPost("add")]
        public IActionResult Add(Event _event)
        {
            var result = _eventService.Add(_event);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Event _event)
        {
            var result = _eventService.Delete(_event);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Event _event)
        {
            var result = _eventService.Update(_event);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _eventService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _eventService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getusereventweek")]
        public IActionResult GetUserEventsByWeek()
        {

            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = _eventService.GetUserEventsByWeek(int.Parse(userId));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getusereventmony")]
        public IActionResult GetUserEventsByMonth()
        {

            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = _eventService.GetUserEventsByMonth(int.Parse(userId));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getalleventbyuser")]
        public IActionResult GetAllEventByUser()        
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = _eventService.GetAllEventByUser(int.Parse(userId));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
