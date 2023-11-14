using HospitalCareSystem.BL;
using HospitalCareSystem.BL.DTOs.DoctorDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalCareSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorManger doctorManger;

        public DoctorController(IDoctorManger doctorManger)
        {
            this.doctorManger = doctorManger;
        }
        [Authorize]
        [HttpGet]
        [Route("doctors")]
        public ActionResult GetAll()
        {
           return Ok(doctorManger.GetAll());
        }
        [HttpGet]
        [Authorize(Policy ="Data")]
        [Route("/details/{id}")]
        public ActionResult<DoctorReadDetailsDto> GetDrDetailsById(int id) 
        {
            var idOdCurrentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var dr = doctorManger.GetDetailsById(id);
            if (dr == null)
                return NotFound();
            return dr;
        }
        [HttpPost]
        public ActionResult<DoctorAddDto> Add(DoctorAddDto dr)
        {
           var drAdd = doctorManger.Add(dr);
            return drAdd;
        }
        [HttpPut]
        public ActionResult Edit(DoctorUpdateDto drUp)
        {
            var dr =doctorManger.Update(drUp);
            return Ok(dr);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var isDel =doctorManger.IsDeleted(id);
            if (isDel == false)
                return BadRequest();
            return NoContent();
        }
    }
}
