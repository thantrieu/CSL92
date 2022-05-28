using System;

namespace L92Exercises1
{
    class InvalidDateFormatException : Exception
    {
        public string InvalidDateString { get; set; }
        public InvalidDateFormatException() : base() { }
        public InvalidDateFormatException(string message) : base(message) { }
        public InvalidDateFormatException(string message, Exception innerException) : base(message, innerException) { }
        public InvalidDateFormatException(string messsaeg, string dateStr) : base(messsaeg)
        {
            InvalidDateString = dateStr;
        }

        public override string ToString()
        {
            return base.ToString() + "\nGiá trị ngày không hợp lệ: " + InvalidDateString;
        }
    }
}
