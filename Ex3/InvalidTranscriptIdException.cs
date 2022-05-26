using System;

namespace L92Exercises3
{
    internal class InvalidTranscriptIdException : Exception
    {
        public string InvalidTransId { get; set; }
        public InvalidTranscriptIdException() : base() { }
        public InvalidTranscriptIdException(string message) : base(message) { }
        public InvalidTranscriptIdException(string message, Exception innerException) : base(message, innerException) { }

        public InvalidTranscriptIdException(string message, string invalidTransId) : base(message)
        {
            InvalidTransId = invalidTransId;
        }

        public override string ToString()
        {
            return base.ToString() + "\nGiá trị mã bảng điểm không hợp lệ: " + InvalidTransId;
        }
    }
}
