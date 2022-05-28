using System.Collections.Generic;

namespace L92Exercises2
{
    interface IIOController
    {
        void SaveStudentsData(List<Student> students, string fileName);
        void SaveSubjectsData(List<Subject> subjects, string fileName);
        void SaveRegistersData(List<Register> registers, string fileName);
        void UpdateRegisterAutoId(List<Register> registers);
        void UpdateSubjectAutoId(List<Subject> subjects);
        List<Student> GetStudents(string fileName);
        List<Subject> GetSubjects(string fileName);
        List<Register> GetRegisters(string fileName);
        Student CreateStudent(string[] data);
        Subject CreateSubject(string[] data);
        Register CreateRegister(string[] data);
        void FillRegisterInfo(List<Register> registers, 
            List<Student> students, List<Subject> subjects);
    }
}
