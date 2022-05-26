using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace L92Exercises3
{
    class Controller : Icontroller
    {
        public bool IsBirthdateValid(string birthdate)
        {
            var pattern = @"^\d{2}/\d{2}/\d{4}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(birthdate);
        }

        public bool IsCourseIdValid(string courseId)
        {
            var pattern = @"^\d{5}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(courseId))
            {
                var value = int.Parse(courseId);
                return value >= 10000;
            }
            return false;
        }

        public bool IsEmailValid(string email)
        {
            var pattern = @"^[a-z0-9_]+[a-z0-9-_.]*@[a-z0-9]+\.[a-z]{2,4}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public bool IsFullNameValid(string fullName)
        {
            var pattern = @"^[a-z]+[a-z ]*$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(fullName);
        }

        public bool IsPhoneNumberValid(string phoneNumber)
        {
            var pattern = @"^(03|08|09)\d{8}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }

        public bool IsStudentIdValid(string studentId)
        {
            var pattern = @"^ST\d{4}$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(studentId);
        }

        public bool IsSubjectIdValid(string subjectId)
        {
            var pattern = @"^\d{4}$";
            var regex = new Regex(pattern);
            if (regex.IsMatch(subjectId))
            {
                var value = int.Parse(subjectId);
                return value >= 1000;
            }
            return false;
        }

        public bool IsTranscriptIdValid(string transcriptId)
        {
            var pattern = @"^\d{4}$";
            var regex = new Regex(pattern);
            if (regex.IsMatch(transcriptId))
            {
                var value = int.Parse(transcriptId);
                return value >= 1000;
            }
            return false;
        }

        public List<Course> ReadCoursesFromFile(string fileName)
        {
            List<Course> courseList = new List<Course>();
            FileInfo fileReader = new FileInfo(fileName);
            if (!fileReader.Exists)
            {
                return courseList;
            }
            using (var streamReader = fileReader.OpenText())
            {
                var line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    var data = line.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                    var course = CreateCourse(data);
                    if (course != null)
                    {
                        courseList.Add(course);
                    }
                    line = streamReader.ReadLine();
                }
            }
            return courseList;
        }

        private Course CreateCourse(string[] data)
        {
            if (data.Length > 0)
            {
                var course = new Course();
                course.CourseId = int.Parse(data[0]);
                course.Subject = new Subject(int.Parse(data[1]));
                course.Teacher = data[2];
                course.NumberOfStudent = int.Parse(data[3]);
                course.Transcripts = new List<Transcript>();
                if(data[4].CompareTo("null") != 0)
                {
                    var tranIds = data[4].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var tranId in tranIds)
                    {
                        course.Transcripts.Add(new Transcript(int.Parse(tranId)));
                    }
                }
                return course;
            }
            return null;
        }

        public List<Student> ReadStudentsFromFile(string fileName)
        {
            var students = new List<Student>();
            var fileReader = new FileInfo(fileName);
            if(!fileReader.Exists)
            {
                return students;
            }
            using (var streamReader = fileReader.OpenText())
            {
                var line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    var data = line.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                    var student = CreateStudent(data);
                    if (student != null)
                    {
                        students.Add(student);
                    }
                    line = streamReader.ReadLine();
                }
            }
            return students;
        }

        private Student CreateStudent(string[] data)
        {
            if (data.Length == 0)
            {
                return null;
            }
            var dateFormat = "dd/MM/yyyy";
            var birthDate = DateTime.ParseExact(data[2], dateFormat, null);
            return new Student(data[0], data[1], birthDate, data[3], data[4], data[5], data[6]);
        }

        public List<Subject> ReadSubjectsFromFile(string fileName)
        {
            var subjects = new List<Subject>();
            var fileReader = new FileInfo(fileName);
            if (!fileReader.Exists)
            {
                return subjects;
            }
            using (var streamReader = fileReader.OpenText())
            {
                var line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    var data = line.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                    var subject = CreateSubject(data);
                    if (subject != null)
                    {
                        subjects.Add(subject);
                    }
                    line = streamReader.ReadLine();
                }
            }
            return subjects;
        }

        private Subject CreateSubject(string[] data)
        {
            if (data.Length > 0)
            {
                return new Subject(int.Parse(data[0]), data[1], int.Parse(data[2]));
            }
            return null;
        }

        public List<Transcript> ReadTranscriptsFromFile(string fileName)
        {
            var transcripts = new List<Transcript>();
            var fileReader = new FileInfo(fileName);
            if (!fileReader.Exists)
            {
                return transcripts;
            }
            using (var streamReader = fileReader.OpenText())
            {
                var line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    var data = line.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                    var trans = CreateTranscript(data);
                    if (trans != null)
                    {
                        transcripts.Add(trans);
                    }
                    line = streamReader.ReadLine();
                }
            }
            return transcripts;
        }

        private Transcript CreateTranscript(string[] data)
        {
            if (data.Length > 0)
            {
                var student = new Student(data[1]);
                var g1 = float.Parse(data[2]);
                var g2 = float.Parse(data[3]);
                var g3 = float.Parse(data[4]);
                var gpa = float.Parse(data[5]);
                var id = int.Parse(data[0]);
                return new Transcript(id, student, g1, g2, g3, gpa);
            }
            return null;
        }

        public void WriteCourseDataToFile(List<Course> courses, string fileName)
        {
            var fileWriter = new FileInfo(fileName);
            using (var fileStream = fileWriter.OpenWrite())
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    foreach (var course in courses)
                    {
                        var builder = new StringBuilder();
                        foreach (var item in course.Transcripts)
                        {
                            builder.Append(item.TranscriptId + "|");
                        }
                        var transcriptIds = builder.Length == 0 ? "null" : builder.ToString();
                        var data = $"{course.CourseId}*{course.Subject.SubjectId}*" +
                            $"{course.Teacher}*{course.NumberOfStudent}*{transcriptIds}";
                        streamWriter.WriteLine(data);
                    }
                }
            }
        }

        public void WriteStudentDataToFile(List<Student> students, string fileName)
        {
            var fileWriter = new FileInfo(fileName);
            using (var fileStream = fileWriter.OpenWrite())
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    var dateFormat = "dd/MM/yyyy";
                    foreach (var student in students)
                    {
                        var data = $"{student.FullName}*{student.Address}*" +
                            $"{student.BirthDate.ToString(dateFormat)}*" +
                            $"{student.Email}*{student.PhoneNumber}*{student.StudentId}*" +
                            $"{student.Major}";
                        streamWriter.WriteLine(data);
                    }
                }
            }
        }

        public void WriteSubjectDataToFile(List<Subject> subjects, string fileName)
        {
            var fileWriter = new FileInfo(fileName);
            using (var fileStream = fileWriter.OpenWrite())
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    foreach (var subject in subjects)
                    {
                        var data = $"{subject.SubjectId}*{subject.SubjectName}*{subject.Credit}";
                        streamWriter.WriteLine(data);
                    }
                }
            }
        }

        public void WriteTranscriptDataToFile(List<Transcript> transcripts, string fileName)
        {
            var fileWriter = new FileInfo(fileName);
            using (var fileStream = fileWriter.OpenWrite())
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    foreach (var trans in transcripts)
                    {
                        var data = $"{trans.TranscriptId}*{trans.Student.StudentId}*{trans.GradeLevel1}*" +
                            $"{trans.GradeLevel2}*{trans.GradeLevel3}*{trans.Gpa}";
                        streamWriter.WriteLine(data);
                    }
                }
            }
        }

        public void SetStudentAutoId(List<Student> students)
        {
            int maxId = 0;
            foreach (var student in students)
            {
                var idNumberPart = student.StudentId.Substring(2);
                var idNumberValue = int.Parse(idNumberPart);
                if (idNumberValue > maxId)
                {
                    maxId = idNumberValue;
                }
            }
            Student.SetAutoId(maxId + 1);
        }

        public void SetSubjectAutoId(List<Subject> subjects)
        {
            int maxId = 0;
            foreach (var subject in subjects)
            {
                if (subject.SubjectId > maxId)
                {
                    maxId = subject.SubjectId;
                }
            }
            Subject.SetAutoId(maxId + 1);
        }

        public void SetCourseAutoId(List<Course> courses)
        {
            int maxId = 0;
            foreach (var course in courses)
            {
                if (course.CourseId > maxId)
                {
                    maxId = course.CourseId;
                }
            }
            Course.SetAutoId(maxId + 1);
        }

        public void SetTranscriptAutoId(List<Transcript> transcripts)
        {
            int maxId = 0;
            foreach (var tran in transcripts)
            {
                if (tran.TranscriptId > maxId)
                {
                    maxId = tran.TranscriptId;
                }
            }
            Transcript.SetAutoId(maxId + 1);
        }

        public void SetStudentInfoOfTranscript(List<Transcript> transcripts, List<Student> students)
        {
            for (int i = 0; i < transcripts.Count; i++)
            {
                transcripts[i].Student = FindStudentById(transcripts[i].Student);
            }

            Student FindStudentById(Student student)
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
        }

        public void SetSubjectInfoForCourse(List<Course> courses, List<Subject> subjects)
        {

            for (int i = 0; i < courses.Count; i++)
            {
                courses[i].Subject = FindSubjectById(courses[i].Subject);
            }
            Subject FindSubjectById(Subject subject)
            {
                foreach (var item in subjects)
                {
                    if(item.Equals(subject))
                    {
                        return item;
                    }
                }
                return null;
            }
        }

        public void SetTranscriptOfCourse(List<Course> courses, List<Transcript> transcripts)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                var trans = courses[i].Transcripts;
                for (int j = 0; j < trans.Count; j++)
                {
                    trans[i] = FindTranscript(trans[i]);
                }
            }

            Transcript FindTranscript(Transcript transcript)
            {
                foreach (var item in transcripts)
                {
                    if(item.Equals(transcript))
                    {
                        return item;
                    }
                }
                return null;
            }
        }
    }
}
