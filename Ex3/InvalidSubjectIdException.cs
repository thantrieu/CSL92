using System;

namespace L92Exercises3
{
    class InvalidSubjectIdException : Exception
    {
        public string InvalidSubjectId { get; set; }

        public InvalidSubjectIdException() : base() { }
        public InvalidSubjectIdException(string message) : base(message) { }
        public InvalidSubjectIdException(string message, Exception innerException) : base(message, innerException) { }
        public InvalidSubjectIdException(string message, string id) : base(message)
        {
            InvalidSubjectId = id;
        }

        public override string ToString()
        {
            return base.ToString() + "\nGiá trị mã môn học không hợp lệ: " + InvalidSubjectId;
        }
    }
}
