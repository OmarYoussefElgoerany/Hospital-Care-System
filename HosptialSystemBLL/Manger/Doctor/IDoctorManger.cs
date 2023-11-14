using HealthCareSystem.DAL;
using HospitalCareSystem.BL.DTOs.DoctorDTO;
using HospitalCareSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCareSystem.BL;

public interface IDoctorManger
{
    DoctorReadDto GetDrById(int id);
    List<DoctorReadDto> GetAll();
    DoctorAddDto Add(DoctorAddDto doctor);
    DoctorUpdateDto Update(DoctorUpdateDto doctor);
    DoctorReadDetailsDto? GetDetailsById(int id);
    bool IsDeleted(int id);
}
