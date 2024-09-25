namespace _02_LINQ_02
{
    class Employee
    {
        public string name;
        public string email;
        public string department;
        public string job;
        public string phone;
        public string room;
        public int salary;
        public bool fullTime;

        public Employee(string name, string email, string department, string job = "", string phone = "", string room = "")
        {
            this.name = name;
            this.email = email;
            this.department = department;
            this.job = job;
            this.phone = phone;
            this.room = room;
        }

        public Employee()
        {

        }
    }
}
