using HealthCareSystem.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCareSystem.DAL;

public class DoctorRepo:GenericRepo<Doctor>,IDoctorRepo
{
    private readonly HospitalContext context;
    
    public DoctorRepo(HospitalContext context):base(context)
    {
        this.context = context;
    }
    public Doctor? GetDocDetailsById(int id)
    {
        return context.Doctors.Include(i => i.Patients).
            ThenInclude(i => i.Issues).
            FirstOrDefault(i => i.Id == id);
    }
  
}
