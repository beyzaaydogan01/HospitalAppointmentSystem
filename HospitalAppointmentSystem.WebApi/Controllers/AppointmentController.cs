using HospitalAppointmentSystem.WebApi.Dtos.Appointments.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Appointments.Responses;
using HospitalAppointmentSystem.WebApi.Dtos.Doctors.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Doctors.Responses;
using HospitalAppointmentSystem.WebApi.Models;
using HospitalAppointmentSystem.WebApi.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("getall")]
        public List<AppointmentResponseDto> GetAll()
        {
            return _appointmentService.GetAll();
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CreateAppointmentRequest appointment)
        {
            var created = _appointmentService.Add(appointment);
            return Ok(created);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var appointment = _appointmentService.GetById(id);
            return Ok(appointment);
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] CreateAppointmentRequest appointment)
        {
            var deleted = _appointmentService.Remove(appointment);
            return Ok(deleted);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CreateAppointmentRequest appointment)
        {
            var updated = _appointmentService.Update(appointment);
            return Ok(updated);
        }

        [HttpDelete("outDelete")]
        public IActionResult OutDelete([FromBody]Appointment appointment)
        {
            var outDelete = _appointmentService.OutdatedAppointment(appointment);
            return Ok(outDelete);
        }
    }
}
