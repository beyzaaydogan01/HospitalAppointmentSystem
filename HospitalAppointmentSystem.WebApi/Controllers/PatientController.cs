using HospitalAppointmentSystem.WebApi.Dtos.Doctors.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Doctors.Responses;
using HospitalAppointmentSystem.WebApi.Dtos.Patients.Requests;
using HospitalAppointmentSystem.WebApi.Dtos.Patients.Responses;
using HospitalAppointmentSystem.WebApi.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("getall")]
        public List<PatientResponseDto> GetAll()
        {
            return _patientService.GetAll();
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CreatePatientRequest patient)
        {
            var created = _patientService.Add(patient);
            return Ok(created);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var patient = _patientService.GetById(id);
            return Ok(patient);
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] CreatePatientRequest patient)
        {
            var deleted = _patientService.Remove(patient);
            return Ok(deleted);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CreatePatientRequest patient)
        {
            var updated = _patientService.Update(patient);
            return Ok(updated);
        }
    }
}
