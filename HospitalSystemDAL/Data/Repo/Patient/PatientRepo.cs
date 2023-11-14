using HealthCareSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCareSystem.DAL;

public class PatientRepo:GenericRepo<Patient>,IPatientRepo
{
    public PatientRepo(HospitalContext context):base(context)
    {
    }
}
