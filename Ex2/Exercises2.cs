/// <summary>
/// <author>Branium Academy</author>
/// <version>2022.05.28</version>
/// <see cref="Trang chủ" href="https://braniumacademy.net"/>
/// </summary>

using System;
using System.Collections.Generic;
using System.Text;

namespace L92Exercises2
{
    class Exercises2
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var studentUtils = new StudentManagermentUtils();
            List<Student> students = new List<Student>();
            List<Subject> subjects = new List<Subject>();
            List<Register> registers = new List<Register>();
            // đọc dữ liệu từ file
            studentUtils.GetStudents(students);
            studentUtils.GetSubjects(subjects);
            studentUtils.GetRegisters(registers);
            studentUtils.FillRegisterInfo(registers, students, subjects);

            if(students.Count == 0 && subjects.Count == 0 && registers.Count == 0)
            {
                studentUtils.CreateFakeStudents(students);
                studentUtils.CreateFakeSubjects(subjects);
                studentUtils.CreateFakeRegisters(registers, students, subjects);
            } else
            {
                studentUtils.UpdateRegisterAutoId(registers);
                studentUtils.UpdateSubjectAutoId(subjects);
            }
            int choice;

            do
            {
                Console.WriteLine("=========================> CÁC CHỨC NĂNG <========================");
                Console.WriteLine("*    01. Thêm mới sinh viên vào danh sách sinh viên.             *");
                Console.WriteLine("*    02. Thêm mới môn học vào danh sách môn học.                 *");
                Console.WriteLine("*    03. Thêm mới bản đăng ký môn học vào danh sách đăng ký.     *");
                Console.WriteLine("*    04. Hiển thị danh sách sinh viên ra màn hình.               *");
                Console.WriteLine("*    05. Hiển thị danh sách môn học ra màn hình.                 *");
                Console.WriteLine("*    06. Hiển thị danh sách đăng ký ra màn hình.                 *");
                Console.WriteLine("*    07. Sắp xếp danh sách sinh viên theo tên a-z.               *");
                Console.WriteLine("*    08. Sắp xếp danh sách môn học theo số tín chỉ giảm dần.     *");
                Console.WriteLine("*    09. Sắp xếp danh sách đăng ký theo thời gian đăng ký.       *");
                Console.WriteLine("*    10. Sắp xếp danh sách đăng ký theo mã sinh viên.            *");
                Console.WriteLine("*    11. Sắp xếp danh sách đăng ký theo mã môn học.              *");
                Console.WriteLine("*    12. Tìm danh sách đăng ký theo mã môn học.                  *");
                Console.WriteLine("*    13. Tìm danh sách đăng ký theo mã sinh viên.                *");
                Console.WriteLine("*    14. Sửa tên sinh viên theo mã sinh viên cho trước.          *");
                Console.WriteLine("*    15. Sửa số tiết học theo mã môn học cho trước.              *");
                Console.WriteLine("*    16. Xóa môn học khỏi danh sách môn học.                     *");
                Console.WriteLine("*    17. Xóa sinh viên khỏi danh sách sinh viên.                 *");
                Console.WriteLine("*    18. Xóa bản đăng ký theo mã đăng ký.                        *");
                Console.WriteLine("*    19. Lưu dữ liệu ra file.                                    *");
                Console.WriteLine("*    20. Thoát chương trình.                                     *");
                Console.WriteLine("==================================================================");
                Console.WriteLine("==> Xin mời bạn chọn chức năng:  ");

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        try
                        {
                            var newStudent = studentUtils.CreateStudent(students);
                            if (newStudent != null)
                            {
                                students.Add(newStudent);
                                Console.WriteLine("==> Tạo sinh viên thành công!");
                            }
                            else
                            {
                                Console.WriteLine("==> Tạo mới sinh viên thất bại.");
                            }
                        } 
                        catch(InvalidStudentIdException e) { Console.WriteLine(e); }
                        catch (InvalidNameException e) { Console.WriteLine(e); }
                        catch (InvalidPhoneNumberException e) { Console.WriteLine(e); }
                        catch (InvalidEmailException e) { Console.WriteLine(e); }
                        catch (InvalidBirthDateException e) { Console.WriteLine(e); }
                        break;
                    case 2:
                        Subject newSubject = studentUtils.CreateSubject();
                        if (newSubject != null)
                        {
                            subjects.Add(newSubject);
                            Console.WriteLine("==> Tạo môn học thành công. <==");
                        } 
                        else { 
                            Console.WriteLine("Tạo môn học thất bại."); 
                        }
                        break;
                    case 3:
                        if (students.Count > 0 && subjects.Count > 0)
                        {
                            Register newRegister = null;
                            try
                            {
                                newRegister = studentUtils.CreateRegister(students, subjects);
                            }
                            catch (InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                            }
                            catch(InvalidSubjectIdException e)
                            {
                                Console.WriteLine(e);
                            }
                            if (newRegister != null && newRegister.Subject != null && newRegister.Student != null)
                            {
                                if (!studentUtils.Contains(registers, newRegister))
                                {
                                    registers.Add(newRegister);
                                    Console.WriteLine($"==> Sinh viên \"{newRegister.Student.StudentId}\" " +
                                        $"đăng ký thành công môn học \"{newRegister.Subject.SubjectId}\". <==");
                                }
                                else
                                {
                                    Console.WriteLine($"==> Lỗi. Sinh viên \"{newRegister.Student.StudentId}\" " +
                                        $"đã đăng ký môn học \"{newRegister.Subject.SubjectId}\" trước đó. <==");
                                }
                            }
                            else if (newRegister.Subject == null)
                            {
                                Console.WriteLine("==> Môn học cần đăng ký không tồn tại. <==");
                            }
                            else if (newRegister.Student == null)
                            {
                                Console.WriteLine("==> Sinh viên cần đăng ký không tồn tại. <==");
                            }
                        }
                        else
                        {
                            if (students.Count == 0)
                            {
                                Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                            }
                            if (subjects.Count == 0)
                            {
                                Console.WriteLine("==> Danh sách môn học rỗng <==");
                            }
                        }
                        break;
                    case 4:
                        if (students.Count > 0)
                        {
                            studentUtils.ShowStudents(students);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 5:
                        if (subjects.Count > 0)
                        {
                            studentUtils.ShowSubjects(subjects);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 6:
                        if (registers.Count > 0)
                        {
                            studentUtils.ShowRegisters(registers);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 7:
                        if (students.Count > 0)
                        {
                            studentUtils.SortStudentByName(students);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 8:
                        if (subjects.Count > 0)
                        {
                            studentUtils.SortSubjectByCredit(subjects);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 9:
                        if (registers.Count > 0)
                        {
                            studentUtils.SortRegistersByRegTime(registers);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 10:
                        if (registers.Count > 0)
                        {
                            studentUtils.SortRegistersByStudentId(registers);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 11:
                        if (registers.Count > 0)
                        {
                            studentUtils.SortRegistersBySubjectId(registers);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 12:
                        if (registers.Count > 0)
                        {
                            List<Register> result = null;
                            try
                            {
                                studentUtils.FindRegisterBySubjectId(registers);
                            }
                            catch (InvalidSubjectIdException e)
                            {
                                Console.WriteLine(e);
                            }
                            if (result != null && result[0] == null)
                            {
                                Console.WriteLine("==> Không có kết quả tìm kiếm. <==");
                            }
                            else
                            {
                                Console.WriteLine("==> Kết quả tìm kiếm theo mã môn học: <==");
                                studentUtils.ShowRegisters(result);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 13:
                        if (registers.Count > 0)
                        {
                            try
                            {
                                List<Register> result = null;
                                try
                                {
                                    result = studentUtils.FindRegisterByStudentId(registers);
                                }
                                catch (InvalidStudentIdException e)
                                {
                                    Console.WriteLine(e);
                                }
                                if (result != null && result[0] == null)
                                {
                                    Console.WriteLine("==> Không có kết quả tìm kiếm. <==");
                                }
                                else
                                {
                                    Console.WriteLine("==> Kết quả tìm kiếm theo mã sinh viên: <==");
                                    studentUtils.ShowRegisters(result);
                                }
                            }
                            catch (InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 14:
                        if (students.Count > 0)
                        {
                            try
                            {
                                studentUtils.UpdateStudentInfo(students);
                            }
                            catch (InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                            }
                            catch(InvalidNameException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 15:
                        if (subjects.Count > 0)
                        {
                            try
                            {
                                studentUtils.UpdateSubjectLesson(subjects);
                            }
                            catch (InvalidSubjectIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 16:
                        if (subjects.Count > 0)
                        {
                            try
                            {
                                studentUtils.RemoveSubject(subjects);
                            }
                            catch (InvalidSubjectIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 17:
                        if (students.Count > 0)
                        {
                            try
                            {
                                studentUtils.RemoveStudent(students);
                            }
                            catch (InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 18:
                        if (registers.Count > 0)
                        {
                            try
                            {
                                studentUtils.RemoveRegister(registers);
                            }
                            catch (InvalidRegisterIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 19:
                        studentUtils.SaveStudentData(students);
                        studentUtils.SaveSubjectData(subjects);
                        studentUtils.SaveRegisterData(registers);
                        Console.WriteLine("==> Lưu dữ liệu ra file thành công. <==");
                        break;
                    case 20:
                        Console.WriteLine("==> Cảm ơn quý khách đã sử dụng dịch vụ! <==");
                        break;
                    default:
                        Console.WriteLine("==> Sai chức năng. Vui lòng chọn lại! <==");
                        break;
                }
            } while (choice != 20);
        }
    }
}
