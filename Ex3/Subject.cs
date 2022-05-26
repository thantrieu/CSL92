namespace L92Exercises3
{
    // lớp mô tả thông tin môn học
    class Subject
    {
        private static int autoId = 1000;
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Credit { get; set; }
        public Subject() { }

        public Subject(int id)
        {
            SubjectId = id == 0 ? autoId++ : id;
        }

        public Subject(int id, string name, int credit) : this(id)
        {
            SubjectName = name;
            Credit = credit;
        }

        internal static void SetAutoId(int v)
        {
            autoId = v;
        }

        public override bool Equals(object obj)
        {
            return obj is Subject subject &&
                   SubjectId == subject.SubjectId;
        }

        public override int GetHashCode()
        {
            return -278109614 + SubjectId.GetHashCode();
        }
    }
}
