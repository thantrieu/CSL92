/// <summary>
/// <author>Branium Academy</author>
/// <version>2022.05.26</version>
/// <see cref="Trang chủ" href="https://braniumacademy.net"/>
/// </summary>

using System;
using System.Text;
using System.Collections.Generic;

namespace L92Exercises3
{
    class Exercises3
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var utils = new RegisterManagermentUtils();
            List<Subject> subjects = new List<Subject>();
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();
            List<Transcript> transcripts = new List<Transcript>();
            // đọc các file
            utils.ReadStudents(students);
            utils.ReadSubjects(subjects);
            utils.ReadTranscripts(transcripts, students);
            utils.ReadCourses(courses, transcripts);
            // thiết lập mã tự tăng chạy từ số tiếp theo sau mã id lớn nhất của phiên làm việc trước đó
            // tránh mã các đối tượng trùng nhau
            utils.SetAutoIds(students, subjects, courses, transcripts);
            // nếu sau khi đọc file mà danh sách sinh viên và danh sách môn học vẫn rỗng
            // ta tạo mới danh sách dữ liệu fake để test
            if(students.Count == 0 && subjects.Count == 0)
            {
                utils.CreateFakeStudents(students);
                utils.CreateFakeSubjects(subjects);
                utils.CreateFakeCourses(courses, subjects);
            }

            int choice;
            do
            {
                Console.WriteLine("=========================== CÁC CHỨC NĂNG ============================");
                Console.WriteLine("*    01. Thêm mới sinh viên vào danh sách.                           *");
                Console.WriteLine("*    02. Thêm mới môn học vào danh sách.                             *");
                Console.WriteLine("*    03. Thêm mới lớp học phần vào danh sách.                        *");
                Console.WriteLine("*    04. Nhập bảng điểm cho sinh viên trong một lớp.                 *");
                Console.WriteLine("*    05. Hiển thị danh sách sinh viên ra màn hình.                   *");
                Console.WriteLine("*    06. Hiển thị danh sách môn học ra màn hình.                     *");
                Console.WriteLine("*    07. Hiển thị danh sách bảng điểm của từng lớp học phần.         *");
                Console.WriteLine("*    08. Sắp xếp danh sách sinh viên theo tên tăng dần.              *");
                Console.WriteLine("*    09. Tìm sinh viên theo mã sinh viên cho trước.                  *");
                Console.WriteLine("*    10. Xóa sinh viên theo mã cho trước khỏi danh sách.             *");
                Console.WriteLine("*    11. Sắp xếp danh sách bảng điểm của một lớp học phần.           *");
                Console.WriteLine("*    12. Liệt kê số lượng các sinh viên có điểm TB loại giỏi.        *");
                Console.WriteLine("*    13. Liệt kê số lượng sinh viên trượt môn trong từng lớp.        *");
                Console.WriteLine("*    14. Sửa điểm cho sinh viên theo mã lớp và mã sinh viên.         *");
                Console.WriteLine("*    15. Tìm các sinh viên có điểm TB >= x nhập vào từ bàn phím.     *");
                Console.WriteLine("*    16. Xóa bảng điểm của sinh viên x trong lớp học phần p nào đó.  *");
                Console.WriteLine("*    17. Lưu dữ liệu vào file.                                       *");
                Console.WriteLine("*    18. Thoát chương trình.                                         *");
                Console.WriteLine("======================================================================");
                Console.WriteLine("==> Xin mời bạn chọn 1 chức năng: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        try
                        {
                            var newStudent = utils.CreateStudent();
                            if (newStudent != null)
                            {
                                students.Add(newStudent);
                                Console.WriteLine("==> Thêm sinh viên thành công.");
                            }
                            else
                            {
                                Console.WriteLine("==> Thêm sinh viên thất bại.");
                            }
                        }
                        catch (InvalidNameException e)
                        {
                            Console.WriteLine(e);
                        }
                        catch(InvalidEmailException e)
                        {
                            Console.WriteLine(e);
                        } catch (InvalidBirthDateException e)
                        {
                            Console.WriteLine(e);
                        }
                        catch(InvalidPhoneNumberException e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 2:
                        var subject = utils.CreateSubject();
                        if (subject != null)
                        {
                            subjects.Add(subject);
                            Console.WriteLine("==> Thêm mới môn học thành công.");
                        }
                        else
                        {
                            Console.WriteLine("==> Thêm môn học thất bại.");
                        }
                        break;
                    case 3:
                        try
                        {
                            var course = utils.CreateCourse(subjects);
                            if (course != null)
                            {
                                courses.Add(course);
                                Console.WriteLine("==> Thêm mới lớp học phần thành công.");
                            }
                            else
                            {
                                Console.WriteLine("==> Thêm mới lớp học phần thất bại.");
                            }
                        }
                        catch (InvalidSubjectIdException e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 4:
                        if (courses.Count > 0)
                        {
                            try
                            {
                                utils.FillTranscript(courses, students);
                            }
                            catch (InvalidCourseIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 5:
                        if (courses.Count > 0)
                        {
                            utils.ShowStudents(students);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 6:
                        if (courses.Count > 0)
                        {
                            utils.ShowSubjects(subjects);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 7:
                        if (courses.Count > 0)
                        {
                            utils.ShowTranscript(courses);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 8:
                        if (courses.Count > 0)
                        {
                            utils.SortStudentsByName(students);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 9:
                        if (courses.Count > 0)
                        {
                            Student student = null;
                            try
                            {
                                student = utils.FindStudentById(students);
                            }
                            catch (InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                            }
                            if (student != null)
                            {
                                Console.WriteLine("==> Sinh viên cần tìm: <==");
                                utils.ShowStudents(new List<Student> { student });
                            }
                            else
                            {
                                Console.WriteLine("==> Không tìm thấy sinh viên cần tìm. <==");
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 10:
                        if (courses.Count > 0)
                        {
                            try
                            {
                                utils.RemoveStudentById(students);
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
                    case 11:
                        if (courses.Count > 0)
                        {
                            utils.SortTranscripts(courses);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 12:
                        if (courses.Count > 0)
                        {
                            utils.GoodStudents(courses);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 13:
                        if (courses.Count > 0)
                        {
                            utils.FailedStudents(courses);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 14:
                        if (courses.Count > 0)
                        {
                            try
                            {
                                utils.UpdateGrade(courses);
                            }
                            catch (InvalidCourseIdException e)
                            {
                                Console.WriteLine(e);
                            }
                            catch(InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 15:
                        if (courses.Count > 0)
                        {
                            try
                            {
                                var result = utils.FindStudentByGpa(courses);
                                if (result != null && result[0] != null)
                                {
                                    Console.WriteLine("==> Kết quả tìm kiếm: <==");
                                    foreach (var item in result)
                                    {
                                        if (item != null)
                                        {
                                            Console.WriteLine($"{item.Student.StudentId,-15:d}" +
                                                $"{item.Student.FullName,-25:d}{item.Gpa + "",-15:d}");
                                        }
                                    }
                                }
                            }
                            catch (InvalidCourseIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 16:
                        if (courses.Count > 0)
                        {
                            try
                            {
                                utils.RemoveTranscript(courses);
                            }
                            catch (InvalidCourseIdException e)
                            {
                                Console.WriteLine(e);
                            }
                            catch(InvalidTranscriptIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách lớp học phần rỗng <==");
                        }
                        break;
                    case 17:
                        utils.SaveCourses(courses);
                        utils.SaveStudents(students);
                        utils.SaveSubjects(subjects);
                        utils.SaveTranscripts(courses);
                        Console.WriteLine("==> Ghi dữ liệu ứng dụng ra file thành công.");
                        break;
                    case 18:
                        Console.WriteLine("==> Cảm ơn quý khách đã sử dụng dịch vụ! <==");
                        break;
                    default:
                        Console.WriteLine("==> Sai chức năng. Vui lòng chọn lại! <==");
                        break;
                }
            } while (choice != 18);
        }
    }
}
