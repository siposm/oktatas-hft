```csharp
List<Student> students = new List<Student>
{
    new Student
    {
        Name = "Kovács István",
        NeptunCode = "ABC123",
        BirthYear = 1998,
        EnrollmentYear = 2017,
        CompletedCredits = 180,
        Absolved = true,
        Graduated = false,
        Subjects = new List<Subject>
        {
            new Subject
            {
                Credit = 6,
                Name = "Matematikai alapismeretek",
                Code = "MATH101",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Dr. Szabó Zoltán",
                        NeptunCode = "XYZ789",
                        BirthYear = 1975,
                        StartOfEmployment = new DateTime(2000, 9, 1),
                        HasPhd = true
                    }
                }
            },
            new Subject
            {
                Credit = 5,
                Name = "Adatbázisok",
                Code = "DB102",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Dr. Kiss Péter",
                        NeptunCode = "PQR123",
                        BirthYear = 1970,
                        StartOfEmployment = new DateTime(1998, 5, 10),
                        HasPhd = true
                    },
                    new Teacher
                    {
                        Name = "Nagy Gábor",
                        NeptunCode = "LMN456",
                        BirthYear = 1980,
                        StartOfEmployment = new DateTime(2005, 2, 15),
                        HasPhd = false
                    }
                }
            }
        }
    },
    new Student
    {
        Name = "Nagy Anna",
        NeptunCode = "DEF456",
        BirthYear = 1999,
        EnrollmentYear = 2018,
        CompletedCredits = 120,
        Absolved = true,
        Graduated = false,
        Subjects = new List<Subject>
        {
            new Subject
            {
                Credit = 4,
                Name = "Analízis I.",
                Code = "ANAL101",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Dr. Varga László",
                        NeptunCode = "UVW654",
                        BirthYear = 1968,
                        StartOfEmployment = new DateTime(1995, 4, 12),
                        HasPhd = true
                    }
                }
            },
            new Subject
            {
                Credit = 4,
                Name = "Fizika",
                Code = "PHY101",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Molnár Katalin",
                        NeptunCode = "EFG321",
                        BirthYear = 1982,
                        StartOfEmployment = new DateTime(2007, 8, 15),
                        HasPhd = false
                    }
                }
            }
        }
    },
    new Student
    {
        Name = "Szabó Dávid",
        NeptunCode = "GHI789",
        BirthYear = 1997,
        EnrollmentYear = 2016,
        CompletedCredits = 210,
        Absolved = true,
        Graduated = true,
        Subjects = new List<Subject>
        {
            new Subject
            {
                Credit = 6,
                Name = "Tanulásmódszertan",
                Code = "LEARN101",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Dr. Farkas Béla",
                        NeptunCode = "ABC321",
                        BirthYear = 1972,
                        StartOfEmployment = new DateTime(2001, 11, 1),
                        HasPhd = true
                    }
                }
            },
            new Subject
            {
                Credit = 4,
                Name = "Számítógép hálózatok",
                Code = "NET103",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Kovács László",
                        NeptunCode = "HJK654",
                        BirthYear = 1978,
                        StartOfEmployment = new DateTime(2003, 3, 10),
                        HasPhd = false
                    }
                }
            }
        }
    },
    new Student
    {
        Name = "Horváth Ádám",
        NeptunCode = "JKL012",
        BirthYear = 2000,
        EnrollmentYear = 2019,
        CompletedCredits = 90,
        Absolved = false,
        Graduated = false,
        Subjects = new List<Subject>
        {
            new Subject
            {
                Credit = 5,
                Name = "Informatikai biztonság",
                Code = "SEC102",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Dr. Horváth Ferenc",
                        NeptunCode = "LMN543",
                        BirthYear = 1965,
                        StartOfEmployment = new DateTime(1990, 6, 20),
                        HasPhd = true
                    }
                }
            },
            new Subject
            {
                Credit = 6,
                Name = "Elektronikai alapismeretek",
                Code = "ELEC101",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Tóth Eszter",
                        NeptunCode = "STU987",
                        BirthYear = 1985,
                        StartOfEmployment = new DateTime(2010, 9, 1),
                        HasPhd = false
                    }
                }
            }
        }
    },
    new Student
    {
        Name = "Tóth László",
        NeptunCode = "MNO345",
        BirthYear = 1996,
        EnrollmentYear = 2015,
        CompletedCredits = 240,
        Absolved = true,
        Graduated = true,
        Subjects = new List<Subject>
        {
            new Subject
            {
                Credit = 6,
                Name = "Problema megoldás programozással",
                Code = "PROG102",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Nagy Gábor",
                        NeptunCode = "LMN456",
                        BirthYear = 1980,
                        StartOfEmployment = new DateTime(2005, 2, 15),
                        HasPhd = false
                    },
                    new Teacher
                    {
                        Name = "Dr. Varga László",
                        NeptunCode = "UVW654",
                        BirthYear = 1968,
                        StartOfEmployment = new DateTime(1995, 4, 12),
                        HasPhd = true
                    }
                }
            },
            new Subject
            {
                Credit = 6,
                Name = "Az informatika matematikai alapjai",
                Code = "CSMATH101",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Dr. Szabó Zoltán",
                        NeptunCode = "XYZ789",
                        BirthYear = 1975,
                        StartOfEmployment = new DateTime(2000, 9, 1),
                        HasPhd = true
                    }
                }
            }
        }
    },
    new Student
    {
        Name = "Kiss Mária",
        NeptunCode = "PQR678",
        BirthYear = 1999,
        EnrollmentYear = 2018,
        CompletedCredits = 90,
        Absolved = false,
        Graduated = false,
        Subjects = new List<Subject>
        {
            new Subject
            {
                Credit = 6,
                Name = "Szoftverfejlesztés alapjai",
                Code = "SW101",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Dr. Varga László",
                        NeptunCode = "UVW654",
                        BirthYear = 1968,
                        StartOfEmployment = new DateTime(1995, 4, 12),
                        HasPhd = true
                    }
                }
            },
            new Subject
            {
                Credit = 4,
                Name = "Analízis II.",
                Code = "ANAL102",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Dr. Farkas Béla",
                        NeptunCode = "ABC321",
                        BirthYear = 1972,
                        StartOfEmployment = new DateTime(2001, 11, 1),
                        HasPhd = true
                    }
                }
            },
            new Subject
            {
                Credit = 5,
                Name = "Adatbázisok",
                Code = "DB102",
                HasExam = true,
                Teachers = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Nagy Gábor",
                        NeptunCode = "LMN456",
                        BirthYear = 1980,
                        StartOfEmployment = new DateTime(2005, 2, 15),
                        HasPhd = false
                    }
                }
            }
        }
    }
};
```
