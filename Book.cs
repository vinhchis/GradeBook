namespace GradeBook
{
    public delegate void AddGradeEvenHandler(object sending, EventArgs args);
    public class NameObject
    {
        public string Name { get; set; }
        public NameObject(string name)
        {
            Name = name;
        }

    }

    internal interface IBook
    {
        string Name
        {
            set;
            get;
        }
        void AddGrade(double grade);

        Statistics GetStatistics();

        event AddGradeEvenHandler GradeAdded;
    }
    public abstract class Book : NameObject, IBook
    {
        public Book(string name) : base(name)
        {

        }
        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

        public abstract event AddGradeEvenHandler GradeAdded;

    }
    public class MemoryBook : Book
    {
        public MemoryBook(string name) : base(name)
        {
            Name = name;
            _grades = new List<double>();
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Out value range: {nameof(grade)}");
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            foreach (var grade in _grades)
            {
                result.Add(grade);
            }

            return result;
        }

        public override event AddGradeEvenHandler? GradeAdded;

        private List<double> _grades;
        public const string CATElORY = "English";
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override event AddGradeEvenHandler? GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                if (grade >= 0 && grade <= 100)
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }
                else
                {
                    throw new ArgumentException($"Out value range: {nameof(grade)}");
                }
            }

        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var grade = Double.Parse(line);
                    result.Add(grade);
                    line = reader.ReadLine();
                }
            }
            return result;

        }

    }

}