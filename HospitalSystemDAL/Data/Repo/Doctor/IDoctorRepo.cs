using HealthCareSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCareSystem.DAL;

public interface IDoctorRepo:IGenericRepo<Doctor>
{
    public Doctor? GetDocDetailsById(int id);

}
