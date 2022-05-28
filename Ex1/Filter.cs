using System.Text.RegularExpressions;

namespace L92Exercises1
{
    class Filter : IFilter
    {
        public bool IsEmailValid(string email)
        {
            var pattern = @"^[a-z0-9_]+[a-z-0-9.-_]*@[a-z-0-9]+\.[a-z]{2,4}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public bool IsEmpIdValid(string empId)
        {
            var pattern = @"^EMP\d{4}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(empId);
        }

        public bool IsNameValid(string name)
        {
            var pattern = @"^[\p{L}]+[\p{L} ]*$";
            if (name.Length >= 2 && name.Length <= 40)
            {
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(name.Trim());
            }
            return false;
        }

        public bool IsPhoneValid(string phone)
        {
            var pattern = @"^(03|08|09)\d{8}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(phone);
        }

        public bool IsDateFormatValid(string dateStr)
        {
            var pattern = @"^\d{2}/\d{2}/\d{4}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(dateStr);
        }
    }
}
