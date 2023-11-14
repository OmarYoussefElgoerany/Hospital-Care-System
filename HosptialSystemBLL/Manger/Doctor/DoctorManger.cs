using HealthCareSystem.DAL;
using HospitalCareSystem.BL.DTOs.DoctorDTO;
using HospitalCareSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCareSystem.BL;

public class DoctorManger : IDoctorManger
{
    private readonly IUnitOfWork unitofWork;

    public DoctorManger(IUnitOfWork _unitofWork)
    {
        unitofWork = _unitofWork;
    }
    public DoctorReadDto GetDrById(int id)
    {
        Doctor? dr = unitofWork.DoctorRepo.GetById(id);
        if (dr == null)
        {
            return new DoctorReadDto
            {
                Id = 0,
                Name = "",
                Salary =0,
                PerformanceRate = 0,
                Specialization = ""
            };
        }
        return new DoctorReadDto
        {
            Id=dr.Id,
            Name=dr.Name,
            Salary=dr.Salary,
            PerformanceRate=dr.PerformanceRate,
            Specialization=dr.Specialization
        };
    }
    public DoctorAddDto Add(DoctorAddDto doctorDto)
    {
        if (doctorDto == null)
        {
            throw new ArgumentNullException(nameof(doctorDto), "CANNT BE NULL");
        }
        var doc = new Doctor
        {
          Name = doctorDto.Name,
          Specialization = doctorDto.Specialization,
          Salary = doctorDto.Salary
        };

        unitofWork.DoctorRepo.Add(doc);
        unitofWork.SaveChanges();
        return doctorDto;

    }

    public List<DoctorReadDto> GetAll()
    {
        var dr = unitofWork.DoctorRepo.GetAll();
        return dr.Select(d => new DoctorReadDto
        {
            Id=d.Id,
            Name=d.Name,
            Salary=d.Salary,
            Specialization=d.Specialization,
            PerformanceRate=d.PerformanceRate
        }).ToList();
    }

    public DoctorReadDetailsDto? GetDetailsById(int id)
    {
        Doctor? dr = unitofWork.DoctorRepo.GetDocDetailsById(id);
        if (dr == null)
            return null;
        return new DoctorReadDetailsDto
        {
            Id = dr.Id,
            Name = dr.Name,
            Salary = dr.Salary,
            Specialization = dr.Specialization,
            PerformanceRate = dr.PerformanceRate,
            PatientReadDtos = dr.Patients.Select(p => new PatientReadDto
            {
                Id = p.Id,
                Name = p.Name,
                IssueReadDtos=p.Issues.Select(p => new IssueReadDto
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList()
            }).ToList(),          
        };
    }

    public DoctorUpdateDto Update(DoctorUpdateDto doctor)
    {
        if(doctor.Id==0|| doctor == null)
        {
            return new DoctorUpdateDto
            {
                Name="",
                Salary=0,
                Specialization=""
            };
        }
        Doctor dr = new Doctor()
        {
            Id = doctor.Id,
            Name = doctor.Name,
            Salary = doctor.Salary,
            Specialization=doctor.Specialization
        };
        unitofWork.DoctorRepo.Update(dr);
        unitofWork.SaveChanges();
        return doctor;
    }
    public bool IsDeleted(int id)
    {
        var dr = unitofWork.DoctorRepo.GetById(id);
        if (dr == null)
            return false;
        Doctor doc = new()
        {
            Id = dr.Id
           ,
            Name = dr.Name,
            Salary = dr.Salary,
            Specialization = dr.Specialization,
            PerformanceRate = dr.PerformanceRate
        };
        unitofWork.DoctorRepo.Delete(doc);
        unitofWork.SaveChanges();


        return true;
    }
}
