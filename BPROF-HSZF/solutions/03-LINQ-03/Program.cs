namespace _03_LINQ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            // Melyik hallgató szerezte a legtöbb kreditet?
            var studentWithMostCredits = students
                .OrderByDescending(student => student.CompletedCredits)
                .FirstOrDefault();

            // Melyik hallgató született a legkorábban?
            var studentBornEarliest = students
                .OrderBy(student => student.BirthYear)
                .FirstOrDefault();

            // Melyik tanár kezdte a legkorábban a munkát?
            var teacherWithEarliestEmployment = students
                .SelectMany(student => student.Subjects)
                .SelectMany(subject => subject.Teachers)
                .OrderBy(teacher => teacher.StartOfEmployment)
                .FirstOrDefault();

            // Melyik hallgató rendelkezik a legtöbb tantárggyal, amelyeket Dr. Varga László tanít?
            var studentWithMostVargaSubjects = students
                .OrderByDescending(student => student.Subjects.Count(subject => subject.Teachers.Any(teacher => teacher.Name == "Dr. Varga László")))
                .FirstOrDefault();

            // Hány hallgató abszolválta már az összes tárgyát, de még nem diplomázott?
            var studentsCompletedButNotGraduated = students.Count(student => student.Absolved && !student.Graduated);

            // Melyik tantárgy rendelkezik a legtöbb tanárral?
            var subjectWithMostTeachers = students
                .SelectMany(student => student.Subjects)
                .GroupBy(subject => subject.Code)
                .OrderByDescending(g => g.SelectMany(subject => subject.Teachers).Distinct().Count())
                .Select(g => g.FirstOrDefault())
                .FirstOrDefault();
            
            // Hány hallgató van, akik 2018-ban vagy később iratkoztak be?
            var studentsEnrolled2018OrLater = students.Count(student => student.EnrollmentYear >= 2018);

            // Melyik hallgató rendelkezik a legtöbb olyan tantárggyal, amelyekhez tartozik vizsga?
            var studentWithMostExamSubjects = students
                .OrderByDescending(student => student.Subjects.Count(subject => subject.HasExam))
                .FirstOrDefault();

            // Melyik tanár tanította a legtöbb tantárgyat összesen?
            var teacherWithMostSubjects = students
                .SelectMany(student => student.Subjects)
                .SelectMany(subject => subject.Teachers)
                .GroupBy(teacher => teacher.NeptunCode)
                .OrderByDescending(g => g.SelectMany(teacher => students.SelectMany(student => student.Subjects).Where(subject => subject.Teachers.Contains(g.First()))).Distinct().Count())
                .Select(g => g.First())
                .FirstOrDefault();
            
            // Melyik évben született a legtöbb hallgató?
            var yearWithMostStudents = students
                .GroupBy(student => student.BirthYear)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            // Hány tantárgyat abszolvált egy olyan hallgató, aki már diplomázott is?
            var subjectsCompletedByGraduatedStudents = students
                .Where(student => student.Graduated)
                .SelectMany(student => student.Subjects)
                .Distinct()
                .Count();

            // Hány hallgató van, aki több mint 200 kreditet szerzett?
            var studentsWithMoreThan200Credits = students.Count(student => student.CompletedCredits > 200);

            // Melyik hallgató rendelkezik a legtöbb olyan tantárggyal, amelyeket egyetlen tanár tanít?
            var studentWithMostSingleTeacherSubjects = students
                .OrderByDescending(student => student.Subjects.Count(subject => subject.Teachers.Count == 1))
                .FirstOrDefault();

            // Hány hallgató van, aki még nem abszolválta az összes tantárgyát?
            var studentsNotYetAbsolved = students.Count(student => !student.Absolved);

            // Melyik tantárgyat tanítják a legtöbben olyan tanárok, akiknek nincs PhD fokozatuk?
            var subjectWithMostNonPhdTeachers = students
                .SelectMany(student => student.Subjects)
                .GroupBy(subject => subject.Code)
                .OrderByDescending(g => g.SelectMany(subject => subject.Teachers).Count(teacher => !teacher.HasPhd))
                .Select(g => g.FirstOrDefault())
                .FirstOrDefault();

            // Melyik hallgató rendelkezik a legkevesebb kredittel?
            var studentWithFewestCredits = students
                .OrderBy(student => student.CompletedCredits)
                .FirstOrDefault();

            // Hány hallgató rendelkezik pontosan 180 kredittel?
            var studentsWithExactly180Credits = students.Count(student => student.CompletedCredits == 180);

            // Melyik hallgató tanulja az "Adatbázisok" tantárgyat?
            var studentWithDatabaseSubject = students
                .FirstOrDefault(student => student.Subjects.Any(subject => subject.Name == "Adatbázisok"));

            // Melyik tantárgy tanárai között található a legfiatalabb tanár?
            var subjectWithYoungestTeacher = students
                .SelectMany(student => student.Subjects)
                .OrderBy(subject => subject.Teachers.Min(teacher => teacher.BirthYear))
                .FirstOrDefault();

            // Hány hallgató van, aki pontosan két tantárgyat tanul?
            var studentsWithExactlyTwoSubjects = students.Count(student => student.Subjects.Count == 2);

            
        }
    }
}
