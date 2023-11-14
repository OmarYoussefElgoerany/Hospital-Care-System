using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCareSystem.BL;

public class PatientReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }= string.Empty;
    public List<IssueReadDto> IssueReadDtos { get; set; } =new List<IssueReadDto>();

}
