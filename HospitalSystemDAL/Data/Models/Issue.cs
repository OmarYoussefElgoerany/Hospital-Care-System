using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.DAL;

public class Issue
{
    public int Id{ get; set; }
    public string Name { get; set; } = "";

    public virtual ICollection<Patient> Patients { get; set; }=new HashSet<Patient>();
}
