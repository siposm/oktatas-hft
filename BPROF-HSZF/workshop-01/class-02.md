```csharp
public class Teacher
{
    public string Name { get; set; }
    public string NeptunCode { get; set; }
    public int BirthYear { get; set; }
    public DateTime StartOfEmployment { get; set; }
    public bool HasPhd { get; set; }
}

public class Subject
{
    public int Credit { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public bool HasExam { get; set; }
    public List<Teacher> Teachers { get; set; }
}

public class Student
{
    public string Name { get; set; }
    public string NeptunCode { get; set; }
    public int BirthYear { get; set; }
    public int EnrollmentYear { get; set; }
    public int CompletedCredits { get; set; }
    public List<Subject> Subjects { get; set; }
    public bool Absolved { get; set; }
    public bool Graduated { get; set; }
}
```
