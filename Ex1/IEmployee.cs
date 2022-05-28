namespace L92Exercises1
{
    // interface chỉ ra các hành động của từng sinh viên nói chung
    interface IEmployee
    {
        void CheckIn(string time);
        void CheckOut(string time);
        long CalculateSalary(long profit = 0);
    }
}
