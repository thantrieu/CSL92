using System;
using System.Collections.Generic;
using System.IO;

namespace L92Exercises1
{
    class Controller : IController
    {
        public Director CreateDirector(string[] data)
        {
            var dateFormat = "dd/MM/yyyy";
            var startDate = DateTime.ParseExact(data[8], dateFormat, null);
            float workingDay = float.Parse(data[6]);
            long salary = long.Parse(data[5]);
            long received = long.Parse(data[7]);
            float bonus = float.Parse(data[9]);
            return new Director(data[0], data[1], data[2], data[3],
                salary, workingDay, received, bonus, data[4], startDate);
        }

        public Employee CreateEmployee(string[] data)
        {
            float workingDay = float.Parse(data[6]);
            long salary = long.Parse(data[5]);
            long received = long.Parse(data[7]);
            return new Employee(data[0], data[1], data[2], data[3], 
                salary, workingDay, received, data[7]);
        }

        public Manager CreateManager(string[] data)
        {
            float workingDay = float.Parse(data[6]);
            long salary = long.Parse(data[5]);
            long received = long.Parse(data[7]);
            float bonus = float.Parse(data[8]);
            return new Manager(data[0], data[1], data[2], data[3],
                salary, workingDay, received, bonus, data[4]);
        }

        public List<Employee> ReadEmployeesFromFile(string fileName)
        {
            FileInfo file = new FileInfo(fileName);
            List<Employee> employees = new List<Employee>();
            try
            {
                using (StreamReader sr = file.OpenText())
                {
                    var line = sr.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        var data = line.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                        if (data.Length == 8)
                        {
                            employees.Add(CreateEmployee(data));
                        }
                        else if (data.Length == 9)
                        {
                            employees.Add(CreateManager(data));
                        }
                        else
                        {
                            employees.Add(CreateDirector(data));
                        }
                        line = sr.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File cần đọc không tồn tại.");
                Console.WriteLine(e);
            }
            return employees;
        }

        public void UpdateEmployeeAutoId(List<Employee> employees)
        {
            Employee.SetAutoId(FindMaxId() + 1);
            int FindMaxId()
            {
                int maxId = 0;
                foreach (Employee employee in employees)
                {
                    var idNumber = int.Parse(employee.EmpId.Substring(3));
                    if (idNumber > maxId)
                    {
                        maxId = idNumber;
                    }
                }
                return maxId;
            }
        }

        public void WriteEmployeeDataToFile(List<Employee> employees, string fileName)
        {
            FileInfo fileWriter = new FileInfo(fileName);
            using(StreamWriter writer = new StreamWriter(fileWriter.OpenWrite()))
            {
                foreach (var emp in employees)
                {
                    var data = "";
                    if (emp.GetType() == typeof(Director))
                    {
                        var e = emp as Director;
                        var dateFormat = "dd/MM/yyyy";
                        data = $"{e.EmpId}*{e.FullName}*{e.Email}*{e.PhoneNumber}*" +
                            $"{e.Role}*{e.Salary}*{e.WorkingDay}*{e.ReceivedSalary}*" +
                            $"{e.ReceivedDate.ToString(dateFormat)}*{e.BonusRate}";
                    }
                    else if (emp.GetType() == typeof(Manager))
                    {
                        var e = emp as Manager;
                        data = $"{e.EmpId}*{e.FullName}*{e.Email}*{e.PhoneNumber}*" +
                            $"{e.Role}*{e.Salary}*{e.WorkingDay}*{e.ReceivedSalary}*" +
                            $"{e.BonusRate}";
                    }
                    else
                    {
                        var e = emp;
                        data = $"{e.EmpId}*{e.FullName}*{e.Email}*{e.PhoneNumber}*" +
                            $"{e.Role}*{e.Salary}*{e.WorkingDay}*{e.ReceivedSalary}";
                    }
                    writer.WriteLine(data);
                }
            }
        }
    }
}
