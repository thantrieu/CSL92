using System;

namespace L92Exercises1
{
    internal class InvalidEmployeeIdException : Exception {
        public string InvalidId { get; set; }

        public InvalidEmployeeIdException() { }
        public InvalidEmployeeIdException(string message) : base(message) { }
        public InvalidEmployeeIdException(string message, Exception innerException) : base(message, innerException) { }
        public InvalidEmployeeIdException(string message, string id) : base(message) { 
            InvalidId = id;
        }

        public override string ToString()
        {
            return base.ToString() + "\nGiá trị mã nhân viên không hợp lệ: " + InvalidId;
        }
    }
}
