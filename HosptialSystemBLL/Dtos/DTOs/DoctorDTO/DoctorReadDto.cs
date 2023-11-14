using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCareSystem.BL.DTOs.DoctorDTO;

public class DoctorReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public int PerformanceRate { get; set; }
}
