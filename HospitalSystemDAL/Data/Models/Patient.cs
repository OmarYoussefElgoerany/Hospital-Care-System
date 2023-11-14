using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareSystem.DAL;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;

    public virtual ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();

}