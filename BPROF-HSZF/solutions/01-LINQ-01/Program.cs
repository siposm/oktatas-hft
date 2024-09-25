namespace _01_LINQ_01
{
    public class Subject
    {
        public string name;
        public int credit;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Subject> subjects = new List<Subject>()
            {
                new Subject() { name = "Matematikai alapismeretek", credit = 6 },
                new Subject() { name = "Az informatika matematikai alapjai", credit = 6 },
                new Subject() { name = "Elektronikai alapismeretek", credit = 5 },
                new Subject() { name = "Tanulásmódszertan", credit = 6 },
                new Subject() { name = "Problema megoldás programozással", credit = 6 },
                new Subject() { name = "Testnevelés 1", credit = 1 },
                new Subject() { name = "Analízis I.", credit = 4 },
                new Subject() { name = "Diszkrét matematika és lineáris algebra", credit = 6 },
                new Subject() { name = "Tutorálás felkészítő és projekt dokumentációs technikák", credit = 5 },
                new Subject() { name = "Szoftverfejlesztés alapjai", credit = 6 },
                new Subject() { name = "Adatbázisok", credit = 5 },
                new Subject() { name = "Elektronika", credit = 5 },
                new Subject() { name = "Testnevelés 2", credit = 1 },
                new Subject() { name = "Analízis II.", credit = 4 },
                new Subject() { name = "Fizika", credit = 4 },
                new Subject() { name = "Tutorálás", credit = 4 },
                new Subject() { name = "Algoritmusok és adatstruktúrák (e)", credit = 6 },
                new Subject() { name = "Haladó szoftverfejlesztés (e)", credit = 4 },
                new Subject() { name = "Digitális rendszerek", credit = 4 },
                new Subject() { name = "Számítógép hálózatok", credit = 4 },
                new Subject() { name = "Testnevelés 3", credit = 1 },
                new Subject() { name = "Valószínűségszámítás és matematikai statisztika", credit = 5 },
                new Subject() { name = "Vállalkozásszervezés és projektmenedzsment", credit = 4 },
                new Subject() { name = "Full-stack szoftverfejlesztés (e)", credit = 6 },
                new Subject() { name = "Szoftvertechnológia", credit = 4 },
                new Subject() { name = "Szofterendszer elmélet", credit = 5 },
                new Subject() { name = "Mesterséges intelligencia", credit = 5 },
                new Subject() { name = "Operációs rendszerek", credit = 6 },
                new Subject() { name = "Szakmai szigorlat", credit = 0 },
                new Subject() { name = "Testnevelés 4", credit = 1 },
                new Subject() { name = "Számítógép architektúrák alapjai (e)", credit = 4 },
                new Subject() { name = "Informatikai biztonság (e)", credit = 5 },
                new Subject() { name = "Mobilprogramozás (e)", credit = 4 },
                new Subject() { name = "Projektmunka I.", credit = 4 },
                new Subject() { name = "Korszerű számítógép architektúrák (e)", credit = 4 },
                new Subject() { name = "Projektmunka II.", credit = 4 },
                new Subject() { name = "Szakdolgozat", credit = 15 }
            };

            var q1 = subjects.Max(x => x.credit);
            var q2 = subjects.OrderByDescending(x => x.name.Length).FirstOrDefault();
            var q3 = subjects.Select(x => x.name.ToUpper()).OrderBy(x => x);
            var q4 = subjects.Sum(x =>  x.credit);
            var q5 = subjects.Average(x =>  x.credit);
            var q6 = subjects.Where(x => x.name.Contains('1') || x.name.Contains("I."));

            var q2_ = (from x in subjects orderby x.name.Length descending select x).FirstOrDefault();
            var q3_ = from x in subjects orderby x.name select x.name.ToUpper();
            var q6_ = from x in subjects where x.name.Contains('1') || x.name.Contains("I.") select x;

            var q7 = from x in subjects 
                     orderby x.credit descending
                     where x.name.Contains("(e)") && x.credit < 6
                     select x;

            ;
        }
    }
}
