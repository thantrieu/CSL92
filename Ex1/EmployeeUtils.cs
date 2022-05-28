using System;
using System.Collections.Generic;

namespace L92Exercises1
{
    class EmployeeUtils
    {
        private static string EMP_FILE_NAME = "EMP.DAT";
        private Controller controller;

        public EmployeeUtils()
        {
            controller = new Controller();
        }

        public void CreateFakeData(List<Employee> employees)
        {
            employees.Add(new Employee(null, "Ngô Hoàng Anh", "ngohoanganh@xmail.com", "0123456987", 16400, 23, 0, "Dev"));
            employees.Add(new Employee(null, "Trần Văn Minh", "minhtran@xmail.com", "0123456987", 15600, 22, 0, "Dev"));
            employees.Add(new Employee(null, "Hoàng Khánh Duy", "khanhduy@xmail.com", "0123456987", 19600, 21, 0, "Tester"));
            employees.Add(new Employee(null, "Ngô Văn Tài", "ngovantai@xmail.com", "0123456987", 18500, 23, 0, "Tester"));
            employees.Add(new Employee(null, "Mai Văn Nam", "maivannam@xmail.com", "0123456987", 15600, 21, 0, "Dev"));
            employees.Add(new Employee(null, "Lê Trần Nam", "letrannam@xmail.com", "0123456987", 12600, 20, 0, "Dev"));
            employees.Add(new Employee(null, "Nguyễn Hoàng Nhung", "hoangnhung@xmail.com", "0123456987", 16600, 22, 0, "Tester"));
            employees.Add(new Director(null, "Trần Quốc Nam", "quocnam@xmail.com", "0123456987", 16600, 22, 0, 0.75f, "GD kinh doanh", DateTime.Now));
            employees.Add(new Manager(null, "Ma Quý Tùng", "quytung@xmail.com", "0123456987", 18800, 22, 0, 0.5f, "QL nhan su"));
            employees.Add(new Manager(null, "Lương Bằng Bách", "luongbach@xmail.com", "0123456987", 19700, 21, 0, 0.5f, "QL kinh doanh"));
        }

        public bool RemoveById(List<Employee> employees, string id)
        {
            Console.WriteLine("==> Bạn có chắc chắn muốn xóa không(Y/N)?");
            var ans = Console.ReadLine().ToLower()[0];
            if (ans == 'y')
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i] != null && employees[i].EmpId.CompareTo(id) == 0)
                    {
                        employees.RemoveAt(i);
                        return true; // xóa thành công
                    }
                }
            }
            else
            {
                Console.WriteLine("==> Hành động xóa bị hủy bỏ. <==");
            }
            return false;
        }

        // lưu dữ liệu ra file
        public void WriteDataToFile(List<Employee> employees)
        {
            controller.WriteEmployeeDataToFile(employees, EMP_FILE_NAME);
        }

        // đọc dữ liệu từ file
        public void ReadDataFromFile(List<Employee> employees)
        {
            employees.AddRange(controller.ReadEmployeesFromFile(EMP_FILE_NAME));
        }

        // cập nhật mã nhân viên tự động tăng để đảm bảo không lặp lại mã mỗi khi
        // khởi động lại chương trình
        public void UpdateEmployeeAutoId(List<Employee> employees)
        {
            controller.UpdateEmployeeAutoId(employees);
        }

        // phương thức cập nhật lương cho nhân viên và trả về kết quả cập nhật
        public bool UpdateSalary(List<Employee> employees, string id, long salary)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i] != null && employees[i].EmpId.CompareTo(id) == 0)
                {
                    employees[i].Salary = salary;
                    return true;
                }
            }
            return false;
        }

        // tìm nhân viên theo mã nhân viên cho trước và trả về kết quả tìm kiếm
        // vì mỗi nhân viên chỉ có một mã nên kết quả trả về là 1 đối tượng đơn hoặc null
        // nếu không tìm thấy
        public Employee FindById(List<Employee> employees, string id)
        {
            foreach (var item in employees)
            {
                if (item != null && item.EmpId.CompareTo(id) == 0)
                {
                    return item;
                }
            }
            return null;
        }

        // phương thức tính lương nhân viên
        public void CalculateSalary(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i] != null)
                {
                    if (employees[i].GetType() == typeof(Director))
                    {
                        Console.WriteLine($"Giám đốc {employees[i].FullName}: ");
                        Console.WriteLine("Lợi nhuận tháng hiện tại(đơn vị kđ, 1kđ = 1000đ): ");
                        var profit = long.Parse(Console.ReadLine());
                        employees[i].CalculateSalary(profit);
                    }
                    else
                    {
                        employees[i].CalculateSalary();
                    }
                }
            }
        }

        // phương thức tạo thông tin nhân viên
        public Employee CreateEmployee()
        {
            Console.WriteLine("==> Chọn loại nhân viên cần thêm: ");
            Console.WriteLine("1. Nhân viên thông thường.");
            Console.WriteLine("2. Nhân viên quản lý.");
            Console.WriteLine("3. Giám đốc.");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                try
                {
                    return CreateEmpInfo();
                }
                catch (InvalidNameException e)
                {
                    Console.WriteLine(e);
                }
                catch (InvalidEmailException e)
                {
                    Console.WriteLine(e);

                }
                catch (InvalidPhoneNumberException e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (option == 2)
            {
                try
                {
                    return CreateLeaderInfo();
                }
                catch (InvalidNameException e)
                {
                    Console.WriteLine(e);
                }
                catch (InvalidEmailException e)
                {
                    Console.WriteLine(e);

                }
                catch (InvalidPhoneNumberException e)
                {
                    Console.WriteLine(e);
                }
            }
            else if (option == 3)
            {
                try
                {
                    return CreateDirectorInfo();
                }
                catch (InvalidNameException e)
                {
                    Console.WriteLine(e);
                }
                catch (InvalidEmailException e)
                {
                    Console.WriteLine(e);

                }
                catch (InvalidPhoneNumberException e)
                {
                    Console.WriteLine(e);
                }
                catch (InvalidDateFormatException e)
                {
                    Console.WriteLine(e);
                }
            }
            return null; // nếu không chọn cụ thể thì trả về null
        }

        // tạo thông tin giám đốc
        public Employee CreateDirectorInfo()
        {
            var emp = CreateEmpInfo();
            Console.WriteLine("Ngày nhận chức(vd 22/10/2025): ");
            var date = Console.ReadLine();
            var filter = new Filter();
            if (!filter.IsDateFormatValid(date))
            {
                throw new InvalidDateFormatException("Định dạng ngày tháng không đúng.", date);
            }
            var startDate = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            Console.WriteLine("Hệ số tiền thưởng(% lương): ");
            var bonusRate = float.Parse(Console.ReadLine()) / 100;
            return new Director(emp.EmpId, emp.FullName.ToString(), emp.Email,
                emp.PhoneNumber, emp.Salary, emp.WorkingDay, 0, bonusRate, emp.Role, startDate);
        }

        // tạo thông tin leader
        public Employee CreateLeaderInfo()
        {
            var emp = CreateEmpInfo();
            Console.WriteLine("Hệ số tiền thưởng(% lương): ");
            var bonusRate = float.Parse(Console.ReadLine()) / 100;
            return new Manager(emp.EmpId, emp.FullName.ToString(), emp.Email,
                emp.PhoneNumber, emp.Salary, emp.WorkingDay, 0, bonusRate, emp.Role);
        }

        // tạo thông tin về nhân viên cơ bản
        public Employee CreateEmpInfo()
        {
            IFilter filter = new Filter();
            Employee employee = new Employee(null);
            Console.WriteLine("Họ và tên: ");
            var name = Console.ReadLine();
            if (filter.IsNameValid(name))
            {
                var fullName = new FullName(name);
                employee.FullName = fullName;
                Console.WriteLine("Email: ");
                var email = Console.ReadLine().Trim();
                if (filter.IsEmailValid(email))
                {
                    employee.Email = email;
                }
                else
                {
                    var message = "Email không hợp lệ. Email hợp lệ có dạng: namnguyen123@xmail.com.";
                    throw new InvalidEmailException(message, email);
                }
                Console.WriteLine("Số điện thoại: ");
                string phoneNumber = Console.ReadLine();
                if (filter.IsPhoneValid(phoneNumber))
                {
                    employee.PhoneNumber = phoneNumber;
                }
                else
                {
                    var msg = "Số điện thoại không đúng. Số điện thoại hợp lệ có dạng 0398451265.";
                    throw new InvalidPhoneNumberException(msg, phoneNumber);
                }
                Console.WriteLine("Chức vụ: ");
                var role = Console.ReadLine().Trim();
                employee.Role = role;
                Console.WriteLine("Mức lương: ");
                employee.Salary = long.Parse(Console.ReadLine());
                Console.WriteLine("Số ngày làm việc trong tháng: ");
                employee.WorkingDay = float.Parse(Console.ReadLine());
            }
            else
            {
                var message = "Họ và tên không hợp lệ. Họ và tên chỉ chứa chữ cái và dấu cách.";
                throw new InvalidNameException(message, name);
            }
            return employee;
        }

        // phương thức hiển thị thông tin nhân viên
        public void ShowEmployee(List<Employee> employees)
        {
            var noData = "-";
            var titleId = "Mã NV";
            var titleName = "Họ và tên";
            var titleEmail = "Email";
            var titlePhone = "Số điện thoại";
            var titleSalary = "Mức lương(kđ)";
            var titleWorkingDay = "Số ngày làm việc";
            var titleReceivedSalary = "Lương thực lĩnh(kđ)";
            var titleRole = "Chức vụ";
            var titleBonusRate = "Tiền thưởng(%)";
            var titleStartTime = "Ngày bắt đầu";
            var titleResponsibility = "Tiền trách nhiệm(kđ)";
            Console.WriteLine($"{titleId,-10:d}{titleName,-25:d}{titleEmail,-25:d}" +
                $"{titlePhone,-15:d}{titleSalary,-15:d}{titleWorkingDay,-20:d}" +
                $"{titleReceivedSalary,-20:d}{titleRole,-15:d}{titleBonusRate,-15:d}" +
                $"{titleStartTime,-15:d}{titleResponsibility,-15:d}");
            foreach (var item in employees)
            {
                if (item != null)
                {
                    if (item.GetType() == typeof(Director))
                    {
                        Director d = item as Director;
                        Console.WriteLine($"{d.EmpId,-10:d}{d.FullName,-25:d}{d.Email,-25:d}" +
                        $"{d.PhoneNumber,-15:d}{d.Salary,-15:d}{d.WorkingDay + "",-20:d}" +
                        $"{d.ReceivedSalary,-20:d}{d.Role,-15:d}{d.BonusRate,-15:p}" +
                        $"{d.ReceivedDate.ToString("dd/MM/yyyy"),-15:d}" +
                        $"{(int)(d.Salary * 0.15 * d.WorkingDay / 22),-15:d}");
                    }
                    else if (item.GetType() == typeof(Manager))
                    {
                        Manager m = item as Manager;
                        Console.WriteLine($"{m.EmpId,-10:d}{m.FullName,-25:d}{m.Email,-25:d}" +
                        $"{m.PhoneNumber,-15:d}{m.Salary,-15:d}{m.WorkingDay + "",-20:d}" +
                        $"{m.ReceivedSalary,-20:d}{m.Role,-15:d}{m.BonusRate,-15:p}" +
                        $"{noData,-15:d}{noData,-15:d}");
                    }
                    else
                    {
                        var emp = item as Employee;
                        Console.WriteLine($"{emp.EmpId,-10:d}{emp.FullName,-25:d}{emp.Email,-25:d}" +
                        $"{emp.PhoneNumber,-15:d}{emp.Salary,-15:d}{emp.WorkingDay + "",-20:d}" +
                        $"{emp.ReceivedSalary,-20:d}{emp.Role,-15:d}{noData,-15:d}" +
                        $"{noData,-15:d}{noData,-15:d}");
                    }
                }
            }
            Console.WriteLine("==> QUY ƯỚC: 1kđ = 1000đ. BẰNG CHỮ: 1kđ = MỘT NGHÌN ĐỒNG.");
        }
    }
}
