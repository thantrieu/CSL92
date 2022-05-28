using System.Collections.Generic;

namespace L92Exercises1
{
    interface IController
    {
        List<Employee> ReadEmployeesFromFile(string fileName);
        void WriteEmployeeDataToFile(List<Employee> employees, string fileName);
        Director CreateDirector(string[] data);
        Employee CreateEmployee(string[] data);
        Manager CreateManager(string[] data);
        void UpdateEmployeeAutoId(List<Employee> employees);
    }
}
