namespace L92Exercises1
{
    // lớp mô tả thông tin của một quản lý
    class Manager : Employee
    {
        public float BonusRate { get; set; } // phần trăm tiền thưởng

        public Manager() { }

        public Manager(string id, string fullName, string email, string phone,
            long salary, float workingDay, long received, float bonus, string role) :
            base(id, fullName, email, phone, salary, workingDay, received, role)
        {
            BonusRate = bonus;
        }

        public override long CalculateSalary(long profit = 0)
        {
            var baseSalary = base.CalculateSalary();
            ReceivedSalary = baseSalary + (long)(baseSalary * BonusRate);
            return ReceivedSalary;
        }
    }
}
