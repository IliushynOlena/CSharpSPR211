namespace _12_Events
{
    public delegate void FinishAction();
    public delegate void ExamDelegate(string task);
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public void PassExam(string task)
        {
            Console.WriteLine($"Studnet {LastName} {FirstName} pass the exam {task}");
        }
    }
    class Teacher
    {
        //public ExamDelegate ExamEvent;
        //public event ExamDelegate ExamEvent;
        private ExamDelegate examDelegate;

        public event ExamDelegate ExamEvent
        {
            add 
            { 
                examDelegate+=value;
                Console.WriteLine(value.Method.Name + " was added");            
            }
            remove 
            {
                examDelegate -= value;
                Console.WriteLine(value.Method.Name + " was removed");
            }
        }


        public void CreateExam(string task)
        {
            //exam creating.......
            //some code
            //some test

            //call all members
            examDelegate?.Invoke(task);
        }
    }


    internal class Program
    {
        static void HardWork(FinishAction action)
        {

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Operation {i + 1}  working.....");
                Thread.Sleep(random.Next(500));
                Console.WriteLine($"Operation {i + 1}  finished.....");
            }

            action?.Invoke();
        }
        static void Action1()
        {
            Console.WriteLine("Very good!!!");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello" + 5);


            Student[] students =
            {
                new Student
                {
                     FirstName = "Bill",
                     LastName = "Tomson",
                     Birthdate = new DateTime(2005, 4,7)
                },
                new Student
                {
                     FirstName = "Olga",
                     LastName = "Ivanchuk",
                     Birthdate = new DateTime(2003,10,17)
                },
                new Student
                {
                     FirstName = "Candice",
                     LastName = "Leman",
                     Birthdate = new DateTime(2006, 3,12)
                },
                new Student
                {
                     FirstName = "Nicol",
                     LastName = "Taylor",
                     Birthdate = new DateTime(2004, 7,14),
                }
            };

            Teacher teacher = new Teacher();

            foreach (Student st in students)
            {
                teacher.ExamEvent += new ExamDelegate(st.PassExam);
            }

            teacher.ExamEvent -= students[3].PassExam;
           // teacher.ExamEvent = null;
            teacher.CreateExam("C# exam in Microsoft teams at 12 o'clock ");











            /*
            HardWork(Action1);
            HardWork(delegate () { Console.WriteLine("Normal"); });  
            */
        }
    }
}