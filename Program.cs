namespace GradeBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            IBook? book = new DiskBook("Windy's Book");
            book.GradeAdded += GradeAddedSub1;
            book.GradeAdded += GradeAddedSub2;
            book.GradeAdded -= GradeAddedSub1;

            EnterGrade(book);

            var stat = book.GetStatistics();

            Console.WriteLine($"Book Name: {book.Name}");
            Console.WriteLine($"Max : {stat.High}");
            Console.WriteLine($"Min : {stat.Low}");
            Console.WriteLine($"Average: {stat.Averge:N2}");
            Console.WriteLine($"Letter: {stat.Letter}");
            Console.WriteLine($"Category: {MemoryBook.CATElORY}");

        }

        private static void EnterGrade(IBook book) 
        {
            while (true)
            {
                Console.WriteLine("Enter a grades or 'q' to quit: ");
                string? line = Console.ReadLine();

                if (line == "q")
                {
                    break;
                }

                try
                {
                    if(line != null)
                    {
                        var grade = double.Parse(line);
                        book.AddGrade(grade);
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("***");
                }

            }
        }

        private static void GradeAddedSub1(object sending,EventArgs args)
        {
            Console.WriteLine($"__a grade added__.");
        }

        private static void GradeAddedSub2(object sending,EventArgs args)
        {
            Console.WriteLine($"__A grade added__.");
        }
    }
}
