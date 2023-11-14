using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCareSystem.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly HospitalContext context;

    public IDoctorRepo DoctorRepo { get; }

    public IPatientRepo PatientRepo { get; }

    public IIssueRepo IssueRepo { get; }


    public UnitOfWork(HospitalContext context ,IDoctorRepo doctorRepo ,IPatientRepo patientRepo,IIssueRepo issueRepo)
    {
        this.context = context;
        DoctorRepo = doctorRepo;
        PatientRepo = patientRepo;
        IssueRepo=issueRepo;
    }
    public int SaveChanges()=>context.SaveChanges();
}
