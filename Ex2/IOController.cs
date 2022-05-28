using System;
using System.Collections.Generic;
using System.IO;

namespace L92Exercises2
{
    class IOController : IIOController
    {
        public Register CreateRegister(string[] data)
        {
            if (data == null || data.Length == 0)
            {
                return null;
            }
            var regTime = DateTime.ParseExact(data[3], "dd/MM/yyyy HH:mm:ss", null);
            return new Register(int.Parse(data[0]), new Student(data[1]), 
                new Subject(int.Parse(data[2])), regTime);
        }

        public Student CreateStudent(string[] data)
        {
            if (data == null || data.Length == 0)
            {
                return null;
            }
            var birthDate = DateTime.ParseExact(data[2], "dd/MM/yyyy", null);
            return new Student(data[0], data[1], birthDate, data[3], data[4], data[5]);
        }

        public Subject CreateSubject(string[] data)
        {
            if(data == null || data.Length == 0)
            {
                return null;
            }
            return new Subject(int.Parse(data[0]), data[1], int.Parse(data[2]), int.Parse(data[3]));
        }

        public void FillRegisterInfo(List<Register> registers, List<Student> students, List<Subject> subjects)
        {
            for (int i = 0; i < registers.Count; i++)
            {
                var subject = FindSubject(subjects, registers[i].Subject);
                var student = FindStudent(students, registers[i].Student);
                if(subject != null)
                {
                    registers[i].Subject = subject;
                }
                if(student != null)
                {
                    registers[i].Student = student;
                }
            }
        }

        private Student FindStudent(List<Student> students, Student student)
        {
            foreach (var item in students)
            {
                if(student.Equals(item))
                {
                    return item;
                }
            }
            return null;
        }

        private Subject FindSubject(List<Subject> subjects, Subject subject)
        {
            foreach (var item in subjects)
            {
                if(subject.Equals(item))
                {
                    return item;
                }
            }
            return null;
        }

        public List<Register> GetRegisters(string fileName)
        {
            FileInfo fileReader = new FileInfo(fileName);
            if (fileReader.Exists)
            {
                List<Register> registers = new List<Register>();
                using (Stream stream = fileReader.OpenRead())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        var line = sr.ReadLine();
                        while (!string.IsNullOrEmpty(line))
                        {
                            var data = line.Split(new char[] { '*' }, 
                                StringSplitOptions.RemoveEmptyEntries);
                            var reg = CreateRegister(data);
                            registers.Add(reg);
                            line = sr.ReadLine();
                        }
                    }
                }
                return registers;
            }
            else
            {
                throw new FileNotFoundException("File dữ liệu đăng ký không tồn tại");
            }
        }

        public List<Student> GetStudents(string fileName)
        {
            FileInfo fileReader = new FileInfo(fileName);
            if (fileReader.Exists)
            {
                List<Student> students = new List<Student>();
                using (Stream stream = fileReader.OpenRead())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        var line = sr.ReadLine();
                        while (!string.IsNullOrEmpty(line))
                        {
                            var data = line.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                            var student = CreateStudent(data);
                            students.Add(student);
                            line = sr.ReadLine();
                        }
                    }
                }
                return students;
            }
            else
            {
                throw new FileNotFoundException("File dữ liệu sinh viên không tồn tại");
            }
        }

        public List<Subject> GetSubjects(string fileName)
        {
            FileInfo fileReader = new FileInfo(fileName);
            if(fileReader.Exists)
            {
                List<Subject> subjects = new List<Subject>();
                using(Stream stream = fileReader.OpenRead())
                {
                    using(StreamReader sr = new StreamReader(stream))
                    {
                        var line = sr.ReadLine();
                        while(!string.IsNullOrEmpty(line))
                        {
                            var data = line.Split(new char[] {'*'}, StringSplitOptions.RemoveEmptyEntries);
                            var student = CreateSubject(data);
                            subjects.Add(student);
                            line = sr.ReadLine();
                        }
                    }
                }
                return subjects;
            } else
            {
                throw new FileNotFoundException("File dữ liệu  môn học không tồn tại");
            }
        }

        public void SaveRegistersData(List<Register> registers, string fileName)
        {
            var dateFormat = "dd/MM/yyyy HH:mm:ss";
            FileInfo fileInfo = new FileInfo(fileName);
            using (StreamWriter sw = new StreamWriter(fileInfo.OpenWrite()))
            {
                foreach (var item in registers)
                {
                    sw.WriteLine($"{item.RegisterId}*{item.Student.StudentId}*{item.Subject.SubjectId}*" +
                        $"{item.RegisterTime.ToString(dateFormat)}");
                }
            }
        }

        public void SaveStudentsData(List<Student> students, string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            using (StreamWriter sw = new StreamWriter(fileInfo.OpenWrite()))
            {
                var dateFormat = "dd/MM/yyyy";
                foreach (var item in students)
                {
                    sw.WriteLine($"{item.StudentId}*{item.FullName}*{item.BirthDate.ToString(dateFormat)}*" +
                        $"{item.PhoneNumber}*{item.Email}*{item.Major}");
                }
            }
        }

        public void SaveSubjectsData(List<Subject> subjects, string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            using (StreamWriter sw = new StreamWriter(fileInfo.OpenWrite()))
            {
                foreach (var item in subjects)
                {
                    sw.WriteLine($"{item.SubjectId}*{item.Name}*{item.Credit}*{item.NumOfLesson}");
                }
            }
        }

        public void UpdateRegisterAutoId(List<Register> registers)
        {
            int maxId = FindMaxId();
            Register.SetAutoId(maxId + 1);  
            int FindMaxId()
            {
                int max = 0;
                foreach (var item in registers)
                {
                    if(item.RegisterId > max)
                    {
                        max = item.RegisterId;
                    }
                }
                return max;
            }
        }

        public void UpdateSubjectAutoId(List<Subject> subjects)
        {
            int maxId = FindMaxId();
            Subject.SetAutoId(maxId + 1);
            int FindMaxId()
            {
                int max = 0;
                foreach (var item in subjects)
                {
                    if (item.SubjectId > max)
                    {
                        max = item.SubjectId;
                    }
                }
                return max;
            }
        }
    }
}
