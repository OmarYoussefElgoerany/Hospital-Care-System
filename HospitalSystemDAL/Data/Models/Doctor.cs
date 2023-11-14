namespace HealthCareSystem.DAL;

public class Doctor
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public int PerformanceRate { get; set; }
    public virtual ICollection<Patient> Patients { get; set; }=new HashSet<Patient>();

}

