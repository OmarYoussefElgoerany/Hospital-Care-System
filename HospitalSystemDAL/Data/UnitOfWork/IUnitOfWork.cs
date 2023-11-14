using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCareSystem.DAL;

public interface IUnitOfWork
{
    public IDoctorRepo DoctorRepo { get; }
    public IPatientRepo PatientRepo { get; }
    public IIssueRepo IssueRepo { get; }

    public int SaveChanges();
}
