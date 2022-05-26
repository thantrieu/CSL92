using System.Collections.Generic;

namespace L92Exercises3
{
    // interface mô tả các hành động của hệ thống
    interface Icontroller
    {
        // kiểm tra định dạng mã sinh viên
        bool IsStudentIdValid(string studentId);
        // kiểm tra định dạng họ và tên
        bool IsFullNameValid(string fullName);
        // kiểm tra định dạng email
        bool IsEmailValid(string email);
        // kiểm tra định dạng số điện thoại
        bool IsPhoneNumberValid(string phoneNumber);
        // kiểm tra định dạng của mã môn học
        bool IsSubjectIdValid(string subjectId);
        // kiểm tra định dạng của mã lớp học phần
        bool IsCourseIdValid(string courseId);
        // kiểm tra định dạng của mã bảng điểm
        bool IsTranscriptIdValid(string transcriptId);
        // kiểm tra dịnh dạng ngày sinh có hợp lệ không
        bool IsBirthdateValid(string birthdate);
        // đọc file sinh viên
        List<Student> ReadStudentsFromFile(string fileName);
        // ghi thông tin sinh viên ra file
        void WriteStudentDataToFile(List<Student> students, string fileName);
        // đọc file môn học
        List<Subject> ReadSubjectsFromFile(string fileName);
        // ghi thông tin môn học ra file
        void WriteSubjectDataToFile(List<Subject> students, string fileName);
        // đọc file lớp học
        List<Course> ReadCoursesFromFile(string fileName);
        // ghi thông tin lớp học phần ra file
        void WriteCourseDataToFile(List<Course> students, string fileName);
        // đọc file bảng điểm
        List<Transcript> ReadTranscriptsFromFile(string fileName);
        // ghi thông tin bảng điểm ra file
        void WriteTranscriptDataToFile(List<Transcript> students, string fileName);
        // thiết lập mã tự tăng cho lớp sinh viên
        void SetStudentAutoId(List<Student> students);
        // thiết lập mã tự tăng cho lớp môn học
        void SetSubjectAutoId(List<Subject> subjects);
        // thiết lập mã tự tăng cho lớp học phần
        void SetCourseAutoId(List<Course> courses);
        // thiết lập mã tự tăng cho lớp bảng điểm
        void SetTranscriptAutoId(List<Transcript> transcripts);
        // cập nhật thông tin sinh viên cho từng bảng điểm
        void SetStudentInfoOfTranscript(List<Transcript> transcripts, List<Student> students);
        // cập nhật thông tin môn học cho từng lớp học
        void SetSubjectInfoForCourse(List<Course> courses, List<Subject> subjects);
        // cập nhật thông tin cho danh sách bảng điểm
        void SetTranscriptOfCourse(List<Course> courses, List<Transcript> transcripts);
    }
}
