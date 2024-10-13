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
    public class DoctorController : ControllerBase
    {
        private IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("getall")]
        public List<DoctorResponseDto> GetAll()
        {
            return _doctorService.GetAll();
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CreateDoctorRequest doctor)
        {
            var created = _doctorService.Add(doctor);
            return Ok(created);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var doctor = _doctorService.GetById(id);
            return Ok(doctor);
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] CreateDoctorRequest doctor)
        {
            var deleted = _doctorService.Remove(doctor);
            return Ok(deleted);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CreateDoctorRequest doctor)
        {
            var updated = _doctorService.Update(doctor);
            return Ok(updated);
        }
    }
}
