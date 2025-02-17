using ITIDotNetMvc.Models.Entites;

namespace ITIDotNetMvc.Models;

public class StudentBL
{
    List<Student> students;
    public StudentBL()
    {
        students = new List<Student>
        {
            new Student{ Id = 1, Name = "Ahmed", ImageUrl = "m.png"},
            new Student{ Id = 2, Name = "Ziad", ImageUrl = "m.png"},
            new Student{ Id = 3, Name = "Reem", ImageUrl = "f.jpg"},
            new Student{ Id = 4, Name = "Radwa", ImageUrl = "f.jpg"}
        };
    }

    public List<Student> GetAll()
    {
        return students;
    }

    public Student GetById(int id)
    {
        return students.FirstOrDefault(s => s.Id == id)!;
    }

}
