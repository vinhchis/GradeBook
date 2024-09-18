namespace GradeBook
{
    public class Statistics
    {
        public Statistics()
        {
            Low = double.MaxValue;
            High = double.MinValue;
            Sum = 0.0;
            Count = 0;
        }
        public void Add(double grade)
        {
            Sum += grade;
            Count += 1;
            High = Math.Max(grade, High);
            Low = Math.Min(grade, Low);
        }
        public double Averge
        {
            get
            {
                return Sum / Count;
            }
        }
        public double Low;
        public double High;
        public double Sum;
        public int Count;

        public char Letter
        {
            get
            {
                switch (Averge)
                {
                    case var d when d >= 90:
                        return 'A';

                    case var d when d >= 80:
                        return 'B';

                    case var d when d >= 70:
                        return 'C';
                        
                    case var d when d >= 60:
                        return 'D';
            
                    default:
                        return 'F';
                        
                }
            }
        }
    }
}