using System;

namespace L92Exercises1
{
    // lớp mô tả thông tin nhân viên
    class Employee : BaseEmployee
    {
        // các constructor
        public Employee() { }

        public Employee(string id) : base(id) { }

        public Employee(string id, string fullName, string email,
            string phone, long salary, float workingDay, long received, string role) :
            base(id, fullName, email, phone, salary, workingDay, received, role)
        {
        }

        public override void CheckIn(string time)
        {
            Console.WriteLine($"Nhân viên {FullName} checkin lúc {time}.");
        }

        public override void CheckOut(string time)
        {
            Console.WriteLine($"Nhân viên {FullName} checkout lúc {time}.");
        }

        public override long CalculateSalary(long profit = 0)
        {
            var calculatedSalary = (long)WorkingDay * Salary / 22;
            var bonus = (long)(WorkingDay >= 22 ? calculatedSalary * 0.2 : 0);
            ReceivedSalary = calculatedSalary + bonus;
            return ReceivedSalary;
        }

        public static void SetAutoId(int v)
        {
            autoId = v;
        }
    }
}
