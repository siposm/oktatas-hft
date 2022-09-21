using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpDeptCodeFirst
{
    public partial class Dept
    {
        public Dept()
        {
            Emp = new HashSet<Emp>();
        }

        public int Deptno { get; set; }
        public string Dname { get; set; }
        public string Loc { get; set; }

        public virtual ICollection<Emp> Emp { get; set; }
    }

    public partial class Emp
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? Mgr { get; set; }
        public DateTime Hiredate { get; set; }
        public double Sal { get; set; }
        public double? Comm { get; set; }
        public int Deptno { get; set; }

        public virtual Dept DeptnoNavigation { get; set; }
    }

    public partial class ModelContext : DbContext
    {
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("emp-dept-db").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.Deptno)
                    .HasName("SYS_C00220618");

                entity.ToTable("DEPT", "SCOTT");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Dname)
                    .HasColumnName("DNAME")
                    .HasColumnType("varchar2")
                    .HasMaxLength(14);

                entity.Property(e => e.Loc)
                    .HasColumnName("LOC")
                    .HasColumnType("varchar2")
                    .HasMaxLength(13);
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("SYS_C00220619");

                entity.ToTable("EMP", "SCOTT");

                entity.Property(e => e.Empno).HasColumnName("EMPNO");

                entity.Property(e => e.Comm)
                    .HasColumnName("COMM")
                    .HasColumnType("float");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasColumnType("varchar2")
                    .HasMaxLength(10);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasColumnType("varchar2")
                    .HasMaxLength(9);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal)
                    .HasColumnName("SAL")
                    .HasColumnType("float");

                entity.HasOne(d => d.DeptnoNavigation)
                    .WithMany(p => p.Emp)
                    .HasForeignKey(d => d.Deptno)
                    .HasConstraintName("SYS_C00220620");
            });
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            // code src: https://www.devart.com/dotconnect/oracle/articles/efcore-database-first-net-core.html
            
            Console.WriteLine("\n\n:: EMP DEPT TEST ::\n\n");

            using (var db = new ModelContext())
            {
                // Creating a new department and saving it to the database
                var newDept = new Dept();
                newDept.Deptno = 60;
                newDept.Dname = "Development";
                newDept.Loc = "Houston";
                db.Dept.Add(newDept);

                db.Dept.AddRange(new Dept[]
                {
                    new Dept()
                    {
                        Deptno = 10,
                        Dname = "ACCOUNTING",
                        Loc = "NEW YORK"
                    },
                    new Dept()
                    {
                        Deptno = 20,
                        Dname = "RESEARCH",
                        Loc = "DALLAS"
                    },
                    new Dept()
                    {
                        Deptno = 30,
                        Dname = "SALES",
                        Loc = "CHICAGO"
                    },
                    new Dept()
                    {
                        Deptno = 40,
                        Dname = "OPERATIONS",
                        Loc = "BOSTON"
                    },
                });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                // Retrieving and displaying data
                Console.WriteLine();
                Console.WriteLine("All departments in the database:");
                foreach (var dept in db.Dept)
                {
                    Console.WriteLine("{0} | {1}", dept.Dname, dept.Loc);
                }

                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


                Emp e1 = new Emp()
                {
                    Empno = 7839,
                    Ename = "KING",
                    Job = "PRESIDENT",
                    Mgr = null,
                    Hiredate = DateTime.Parse("17-NOV-1981"),
                    Sal = 5000,
                    Comm = null,
                    Deptno = 10
                };
                Emp e2 = new Emp()
                {
                    Empno = 7698,
                    Ename = "BLAKE",
                    Job = "MANAGER",
                    Mgr = 7839,
                    Hiredate = DateTime.Parse("1-MAY-1981"),
                    Sal = 2850,
                    Comm = null,
                    Deptno = 30
                };

                db.Emp.AddRange(e1, e2);

                db.Emp.AddRange(new Emp[]
                {
                    new Emp()
                    {
                        Empno = 7782,
                        Ename = "CLARK",
                        Job = "MANAGER",
                        Mgr = 7839,
                        Hiredate = DateTime.Parse("9-JUN-1981"),
                        Sal = 2450,
                        Comm = null,
                        Deptno = 10
                    },
                    new Emp()
                    {
                        Empno = 7566,
                        Ename = "JONES",
                        Job = "MANAGER",
                        Mgr = 7839,
                        Hiredate = DateTime.Parse("2-APR-1981"),
                        Sal = 2975,
                        Comm = null,
                        Deptno = 20
                    },
                    new Emp()
                    {
                        Empno = 7654,
                        Ename = "MARTIN",
                        Job = "SALESMAN",
                        Mgr = 7698,
                        Hiredate = DateTime.Parse("28-SEP-1981"),
                        Sal = 1250,
                        Comm = 1400,
                        Deptno = 30
                    },
                    new Emp()
                    {
                        Empno = 7499,
                        Ename = "ALLEN",
                        Job = "SALESMAN",
                        Mgr = 7698,
                        Hiredate = DateTime.Parse("20-FEB-1981"),
                        Sal = 1600,
                        Comm = 300,
                        Deptno = 30
                    },
                    new Emp()
                    {
                        Empno = 7844,
                        Ename = "TURNER",
                        Job = "SALESMAN",
                        Mgr = 7698,
                        Hiredate = DateTime.Parse("8-SEP-1981"),
                        Sal = 1500,
                        Comm = 0,
                        Deptno = 30
                    },
                    new Emp()
                    {
                        Empno = 7900,
                        Ename = "JAMES",
                        Job = "CLERK",
                        Mgr = 7698,
                        Hiredate = DateTime.Parse("3-DEC-1981"),
                        Sal = 950,
                        Comm = null,
                        Deptno = 30
                    },
                    new Emp()
                    {
                        Empno = 7521,
                        Ename = "WARD",
                        Job = "SALESMAN",
                        Mgr = 7698,
                        Hiredate = DateTime.Parse("22-FEB-1981"),
                        Sal = 1250,
                        Comm = 500,
                        Deptno = 30
                    },
                    new Emp()
                    {
                        Empno = 7902,
                        Ename = "FORD",
                        Job = "ANALYST",
                        Mgr = 7566,
                        Hiredate = DateTime.Parse("3-DEC-1981"),
                        Sal = 3000,
                        Comm = null,
                        Deptno = 20
                    },
                    new Emp()
                    {
                        Empno = 7369,
                        Ename = "SMITH",
                        Job = "CLERK",
                        Mgr = 7902,
                        Hiredate = DateTime.Parse("17-DEC-1980"),
                        Sal = 800,
                        Comm = null,
                        Deptno = 20
                    },
                    new Emp()
                    {
                        Empno = 7788,
                        Ename = "SCOTT",
                        Job = "ANALYST",
                        Mgr = 7566,
                        Hiredate = DateTime.Parse("09-DEC-1982"),
                        Sal = 3000,
                        Comm = null,
                        Deptno = 20
                    },
                    new Emp()
                    {
                        Empno = 7876,
                        Ename = "ADAMS",
                        Job = "CLERK",
                        Mgr = 7788,
                        Hiredate = DateTime.Parse("12-JAN-1983"),
                        Sal = 1100,
                        Comm = null,
                        Deptno = 20
                    },
                    new Emp()
                    {
                        Empno = 7934,
                        Ename = "MILLER",
                        Job = "CLERK",
                        Mgr = 7782,
                        Hiredate = DateTime.Parse("23-JAN-1982"),
                        Sal = 1300,
                        Comm = null,
                        Deptno = 10
                    },
                });

                db.SaveChanges();

                foreach (var item in db.Emp)
                {
                    Console.WriteLine("{0} {1} {2}",
                        item.Empno,
                        item.Ename,
                        item.Mgr);
                }

                var q1 = from x in db.Emp
                        where x.DeptnoNavigation.Dname == "ACCOUNTING"
                        select new
                        {
                            departmentName = x.DeptnoNavigation.Dname,
                            workerName = x.Ename,
                            HireDate = x.Hiredate
                        };
                ;

                var q2 = from x in db.Emp
                         where x.Mgr != null
                         join y in db.Emp on x.Mgr equals y.Empno
                         select new
                         {
                             bossName = y.Ename,
                             workerName = x.Ename,
                             bossId = y.Empno,
                             workerId = x.Empno
                         };
                ;
                        
            }
        }
    }
}

