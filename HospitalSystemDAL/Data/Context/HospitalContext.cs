using HealthCareSystem.DAL;
using HospitalCareSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalCareSystem.DAL;

public class HospitalContext:IdentityDbContext<User>
{
    public DbSet<Doctor>  Doctors { get; set; }
    public DbSet<Issue> Issues { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public HospitalContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        #region Seeding Docs

        var doctors = new List<Doctor>
                {
                  new Doctor {
                    Id= 1,
                    Name= "Jessie",
                    Specialization= "Hematology",
                    Salary= 27064,
                    PerformanceRate= 65,
                  },
                  new Doctor {
                    Id= 2,
                    Name= "Judy",
                    Specialization= "Neurology",
                    Salary= 18711,
                    PerformanceRate= 32,
                  },
                  new Doctor {
                    Id= 3,
                    Name= "Naomi",
                    Specialization= "Pediatrics",
                    Salary= 32145,
                    PerformanceRate= 27,
                  },
                  new Doctor {
                    Id= 4,
                    Name= "Joann",
                    Specialization= "Hematology",
                    Salary= 9232,
                    PerformanceRate= 72,
                  },
                  new Doctor {
                    Id= 5,
                    Name= "Judy",
                    Specialization= "Dermatology",
                    Salary= 48498,
                    PerformanceRate= 19,
                  },
                  new Doctor {
                    Id= 6,
                    Name= "Alyssa",
                    Specialization= "Gastroenterology",
                    Salary= 16586,
                    PerformanceRate= 79,
                  },
                  new Doctor {
                    Id= 7,
                    Name= "Mable",
                    Specialization= "Infectious Disease",
                    Salary= 33706,
                    PerformanceRate= 5,
                  },
                  new Doctor {
                    Id= 8,
                    Name= "Paula",
                    Specialization= "Urology",
                    Salary= 19094,
                    PerformanceRate= 0,
                  },
                  new Doctor {
                    Id= 9,
                    Name= "Rafael",
                    Specialization= "Pediatrics",
                    Salary= 12266,
                    PerformanceRate= 97,
                  },
                  new Doctor {
                    Id= 10,
                    Name= "Sara",
                    Specialization= "Pediatrics",
                    Salary= 45041,
                    PerformanceRate= 82,
                  },
                };

        #endregion
        #region Patients

        var patients = new List<Patient>
                {
                  new Patient { Id= 1, Name= "Dana", DoctorId= 5 },
                  new Patient { Id= 2, Name= "Isaac", DoctorId= 7 },
                  new Patient { Id= 3, Name= "Damon", DoctorId= 9 },
                  new Patient { Id= 4, Name= "Miriam", DoctorId= 8 },
                  new Patient { Id= 5, Name= "Terence", DoctorId= 7 },
                  new Patient { Id= 6, Name= "Roosevelt", DoctorId= 1 },
                  new Patient { Id= 7, Name= "Eduardo", DoctorId= 9 },
                  new Patient { Id= 8, Name= "Wilbert", DoctorId= 8 },
                  new Patient { Id= 9, Name= "Tasha", DoctorId= 5 },
                  new Patient { Id= 10, Name= "Max", DoctorId= 1 },
                  new Patient { Id= 11, Name= "Bridget", DoctorId= 2 },
                  new Patient { Id= 12, Name= "Juan", DoctorId= 8 },
                  new Patient { Id= 13, Name= "Krystal", DoctorId= 10 },
                  new Patient { Id= 14, Name= "Erma", DoctorId= 10 },
                  new Patient { Id= 15, Name= "Orlando", DoctorId= 6 },
                  new Patient { Id= 16, Name= "Marvin", DoctorId= 5 },
                  new Patient { Id= 17, Name= "Lamar", DoctorId= 4 },
                  new Patient { Id= 18, Name= "Joe", DoctorId= 7 },
                  new Patient { Id= 19, Name= "Wendell", DoctorId= 8 },
                  new Patient { Id= 20, Name= "Sandra", DoctorId= 4 },
                  new Patient { Id= 21, Name= "Stephanie", DoctorId= 6 },
                  new Patient { Id= 22, Name= "Ervin", DoctorId= 7 },
                  new Patient { Id= 23, Name= "Beth", DoctorId= 4 },
                  new Patient { Id= 24, Name= "Gretchen", DoctorId= 7 },
                  new Patient { Id= 25, Name= "Gwendolyn", DoctorId= 2 },
                  new Patient { Id= 26, Name= "Jerry", DoctorId= 7 },
                  new Patient { Id= 27, Name= "Mitchell", DoctorId= 6 },
                  new Patient { Id= 28, Name= "Maggie", DoctorId= 8 },
                  new Patient { Id= 29, Name= "Sandy", DoctorId= 3 },
                  new Patient { Id= 30, Name= "Lloyd", DoctorId= 2 },
                };

        #endregion
        #region Issues

        var issues = new List<Issue>
                {
                  new Issue { Id= 1, Name= "Diabetes" },
                  new Issue { Id= 2, Name= "Hypertension" },
                  new Issue { Id= 3, Name= "Asthma" },
                  new Issue { Id= 4, Name= "Depression" },
                  new Issue { Id= 5, Name= "Arthritis" },
                  new Issue { Id= 6, Name= "Allergy" },
                  new Issue { Id= 7, Name= "Flu" },
                };

        #endregion
        modelBuilder.Entity<Doctor>().HasData(doctors);
        modelBuilder.Entity<Patient>().HasData(patients);
        modelBuilder.Entity<Issue>().HasData(issues);
    }
 

}
