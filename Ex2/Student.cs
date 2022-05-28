using System;
using System.Collections.Generic;

namespace L92Exercises2
{
    // lớp mô tả thông tin sinh viên
    class Student
    {
        public string StudentId { get; set; }
        public FullName FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Major { get; set; }

        public Student() { }

        public Student(string id)
        {
            StudentId = id;
        }

        public Student(string id, string fullName, DateTime dob,
            string email, string phoneNumber, string major) : this(id)
        {
            FullName = new FullName(fullName);
            BirthDate = dob;
            Email = email;
            PhoneNumber = phoneNumber;
            Major = major;
        }

        public override bool Equals(object obj) // hai sinh viên là 1 nếu trùng mã sinh viên
        {
            return obj is Student student &&
                   StudentId == student.StudentId;
        }

        public override int GetHashCode()
        {
            return 610864741 + EqualityComparer<string>.Default.GetHashCode(StudentId);
        }
    }
}
