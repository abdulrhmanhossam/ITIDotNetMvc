using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIDotNetMvc.Models.Entites;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Salary { get; set; }
    public string JobTitle { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string? Address { get; set; }

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
}
