using System;

namespace L92Exercises3
{
    // lớp mô tả thông tin người
    class Person
    {
        public FullName FullName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Person() { }
        public Person(string fullName, string address,
            DateTime birthDate, string email, string phoneNumber)
        {
            FullName = new FullName(fullName);
            Address = address;
            BirthDate = birthDate;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
