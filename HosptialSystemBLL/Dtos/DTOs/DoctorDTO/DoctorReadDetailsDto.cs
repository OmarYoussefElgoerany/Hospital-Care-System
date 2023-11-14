using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCareSystem.BL;

public class DoctorReadDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public int PerformanceRate { get; set; }
    public List<PatientReadDto> PatientReadDtos { get; set; }=new List<PatientReadDto>();
}
