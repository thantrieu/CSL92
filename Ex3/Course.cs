using System.Collections.Generic;

namespace L92Exercises3
{
    // lớp mô tả thông tin lớp học phần
    class Course
    {
        private static int autoId = 10000;
        public int CourseId { get; set; }
        public Subject Subject { get; set; }
        public string Teacher { get; set; } // người dạy
        public int NumberOfStudent { get; set; }
        public List<Transcript> Transcripts { get; set; }

        public Course() { }

        public Course(int id)
        {
            CourseId = id == 0 ? autoId++ : id;
        }

        public Course(int id, Subject subject, string teacher, int numberOfStudent) : this(id)
        {
            Teacher = teacher;
            Subject = subject;
            NumberOfStudent = numberOfStudent;
            Transcripts = new List<Transcript>();
        }

        internal static void SetAutoId(int v)
        {
            autoId = v;
        }
    }
}
