namespace L92Exercises1
{
    // lớp cha của mọi lớp sinh viên
    abstract class BaseEmployee : IEmployee
    {
        protected static int autoId = 1000;

        public string EmpId { get; set; }           // mã nhân viên
        public FullName FullName { get; set; }      // họ và tên
        public string PhoneNumber { get; set; }     // số điện thoại
        public long Salary { get; set; }            // mức lương
        public float WorkingDay { get; set; }       // số ngày làm việc trong tháng
        public long ReceivedSalary { get; set; }    // lương thực lĩnh
        public string Role { get; set; }            // chức vụ
        public string Email { get; set; }

        public BaseEmployee() { }
        public BaseEmployee(string id)
        {
            EmpId = id == null ? $"EMP{autoId++}" : id;
        }
        public BaseEmployee(string id, string fullName, string email,
            string phoneNumber, long salary, float workingDay,
            long receivedSalary, string role) : this(id)
        {
            FullName = new FullName(fullName);
            Email = email;
            PhoneNumber = phoneNumber;
            Salary = salary;
            Role = role;
            ReceivedSalary = receivedSalary;
            WorkingDay = workingDay;
        }

        // phương thức virtual
        public abstract void CheckIn(string time);
        public abstract void CheckOut(string time);
        public abstract long CalculateSalary(long profit = 0);
    }
}
