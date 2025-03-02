using ITIDotNetMvc.Models.Entites;
using System.ComponentModel.DataAnnotations;

namespace ITIDotNetMvc.ViewModel;

public class EmployeeDepartmentListViewModel
{
    public int Id { get; set; }
    
    [Display(Name = "Full Name")]
    public string Name { get; set; } = null!;
    public decimal Salary { get; set; }
    public string JobTitle { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string? Address { get; set; }
    public int DepartmentId { get; set; }
    public List<Department> DepartmentList { get; set; }
}
