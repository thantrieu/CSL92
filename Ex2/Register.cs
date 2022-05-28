using System;
using System.Collections.Generic;

namespace L92Exercises2
{
    // lớp mô tả thông tin đăng ký
    class Register
    {
        private static int autoId = 10000;
        public int RegisterId { get; set; }
        public DateTime RegisterTime { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public Register() { }

        public Register(int id)
        {
            if (id == 0)
            {
                RegisterId = autoId++;
            }
            else
            {
                RegisterId = id;
            }
        }

        public Register(int id, Student student, Subject subject, DateTime registerTime) : this(id)
        {
            Student = student;
            Subject = subject;
            RegisterTime = registerTime;
        }

        public override bool Equals(object obj)
        {
            return obj is Register register &&
                   EqualityComparer<Student>.Default.Equals(Student, register.Student) &&
                   EqualityComparer<Subject>.Default.Equals(Subject, register.Subject);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal static void SetAutoId(int v)
        {
            autoId = v;
        }
    }
}
