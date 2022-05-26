using System;

namespace L92Exercises3
{
    internal class InvalidCourseIdException : Exception
    {
        public string InvalidCourseId { get; set; }
        public InvalidCourseIdException() : base() { }
        public InvalidCourseIdException(string message) : base(message) { }
        public InvalidCourseIdException(string message, Exception innerException) : base(message, innerException) { }
        public InvalidCourseIdException(string message, string courseId) : base(message)
        {
            InvalidCourseId = courseId;
        }

        public override string ToString()
        {
            return base.ToString() + "\nGiá trị mã lớp học không hợp lệ: " + InvalidCourseId;
        }
    }
}
