namespace L92Exercises1
{
    interface IFilter
    {
        bool IsNameValid(string name);
        bool IsEmailValid(string email);
        bool IsPhoneValid(string phone);
        bool IsEmpIdValid(string empId);
        bool IsDateFormatValid(string dateStr);
    }
}
