namespace _08_Inheritance
{
    //protected - allow access for child class
    abstract class Person// : Object
    {
        protected string name;
        private readonly DateTime birthday;
        public Person()
        {
            name = "no name";
            birthday = new DateTime();            
        }
        public Person(string n, DateTime d)
        {
            name = n;
            if(d > DateTime.Now)
                birthday = new DateTime();
            else
                birthday = d;   
        }
        public virtual void Print()
        {
            Console.WriteLine($"Name {name} \nBirthday : {birthday.ToShortDateString()}");
        }
        public override string ToString()
        {
            return $"Name {name}  Birthday : {birthday.ToShortDateString()}";
        }
        public abstract void DoWork();

    }
    //class Name : BaseClass, Interface1, Interface2, Interface2
    class Worker : Person
    {
        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            set
            { 
                salary = value >= 0? value : 0;    
            }
        }
        public Worker():base()
        {          
            Salary = 0;
        }
        public Worker(string name, DateTime date, decimal salary) : base(name,date)
        {
            Salary = salary;
        }
     
        //override  ... new
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Salary {Salary} ");
        }

        public override void DoWork()
        {
            Console.WriteLine("Doing some work");
        }
    }
    sealed class Programmer : Worker
    {
        public int CodeLines { get;private set; }
        public Programmer():base()
        {
            CodeLines = 0;
        }
        public Programmer(string n, DateTime d, decimal s) : base(n,d,s)
        {
            CodeLines = 0;
        }
        public override void DoWork()
        {
            Console.WriteLine("Write C# code");
        }
        public  override void Print()
        {
            base.Print();
            Console.WriteLine($"Code Lines {CodeLines} ");
        }
        public void WriteLines()
        {
            CodeLines++;
        }
    }
    class TeamLead : Worker
    {
        public int ProjectCount { get; set; }
        //public override void DoWork()
        //{
        //    Console.WriteLine("Manage team project!!!");
        //}
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"ProjectCount {ProjectCount} ");
        }
    }
    class Test
    {
        Person[] people;
        public Test(params Person[] per )
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test test = new Test(new Worker(), new Programmer(), new Person())
            Worker worker = new Worker("Vova",new DateTime(1995,3,3),15000);
            worker.Print();

            Person[] people = new Person[]
            {
                //new Person(),
                worker,
                new Programmer("Bob",new DateTime(2000,12,17),45000)
            };
            Console.WriteLine("----------------------------");
            Programmer pr = null;
            //1 - use cast()
            try
            {
                pr = (Programmer)people[2];
                pr.DoWork();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //2 - use as
            Console.WriteLine("----------------------------");
            pr = people[1] as Programmer;
            if (pr == null)
                Console.WriteLine("Inccorect type");
            else
                pr.DoWork();

            //3 - use as nad is
            if(people[2] is Programmer)
            {
                pr = people[1] as Programmer;
                pr.DoWork();
            }
            else
                Console.WriteLine("Inccorect type");



            /*
            foreach (var person in people)
            {
                Console.WriteLine("------------ Info ------------");
                person.Print();
                
            }

            TeamLead teamLead = new TeamLead();
            teamLead.DoWork();
            teamLead.Print();
            */
        }
    }
}