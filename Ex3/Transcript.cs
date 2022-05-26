using System;

namespace L92Exercises3
{
    // lớp mô tả thông tin bảng điểm
    class Transcript
    {
        private static int autoId = 1000;
        public int TranscriptId { get; set; }
        public Student Student { get; set; }
        public float GradeLevel1 { get; set; }
        public float GradeLevel2 { get; set; }
        public float GradeLevel3 { get; set; }
        public float Gpa { get; set; }

        public Transcript() { }

        public Transcript(int id)
        {
            TranscriptId = id == 0 ? autoId++ : id;
        }

        public Transcript(int id, Student s, float g1, float g2, float g3, float g4) : this(id)
        {
            Student = s;
            GradeLevel1 = g1;
            GradeLevel2 = g2;
            GradeLevel3 = g3;
            Gpa = g4;
        }

        public void CalculateGpa()
        {
            var gpa = 0.1f * GradeLevel1 + 0.3f * GradeLevel2 + 0.6f * GradeLevel3;
            Gpa = (float)Math.Round(gpa, 2);
        }

        public static void SetAutoId(int v)
        {
            autoId = v;
        }

        public override bool Equals(object obj)
        {
            return obj is Transcript transcript &&
                   TranscriptId == transcript.TranscriptId;
        }

        public override int GetHashCode()
        {
            return 24697014 + TranscriptId.GetHashCode();
        }
    }
}
