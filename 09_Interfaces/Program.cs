using System.Text;

namespace _09_Interfaces
{
    class IdCard
    {
        public void Test()
        {
            Console.WriteLine("Hello");
        }
        public static void Work()
        {
            Console.WriteLine("Hello");
        }
    }
    public interface IWorker
    {
       
        //public IdCard IdCard { get; set; }
        public bool IsWorking { get; }
        string Work();
        event EventHandler<EventArgs> WorkCompleted;
    }


    abstract class Human//:Object
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public override string ToString()
        {
            return $"First Name : {FirstName}\nLast Name : {LastName}\n" +
                $"Birthday : {Birthday.ToLongDateString()}";
        }
    }
    abstract class Employee: Human
    {
        public double Salary { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nSalary : {Salary}\nPosition : {Position}\n\n";
        }
    }
    interface IWorkable//public
    {
        bool IsWorking { get; }
        string Work();
    }

    interface IManager
    {
        //List<Employee> ListOfWorkers { get; set; }
        List<IWorkable> ListOfWorkers { get; set; }
        void Organize();
        void MakeBudget();
        void Control();
    }
    class Director : Employee, IManager//implement(realize)
    {
        public List<IWorkable> ListOfWorkers { get ; set ; }

        public void Control()
        {
            Console.WriteLine("Controling work!!!!");
        }

        public void MakeBudget()
        {
            Console.WriteLine("Making budget!!!!");
        }

        public void Organize()
        {
            Console.WriteLine("Organize work!!!");
        }
    }
    class Seller : Employee, IWorkable
    {
        bool isWorking = true;
        public bool IsWorking => isWorking;//get - read only fiel
        //public bool IsWorking
        //{ 
        //    get 
        //    { 
        //        return isWorking;
        //    } 
        //}

        public string Work()
        {
           return "Selling product";
        }
    }
    class Cashier : Employee, IWorkable
    {
        bool isWorking = true;
        public bool IsWorking => isWorking;

        public string Work()
        {
            return "Getting pay for product!!!";
        }
    }
    class Administrator : Employee, IManager, IWorkable
    {
        public bool IsWorking => true;

        public List<IWorkable> ListOfWorkers { get ; set; }

        public void Control()
        {
            Console.WriteLine("Xaxaxaxxaaxxax. I am a BOSS!!!!!");
        }

        public void MakeBudget()
        {
            Console.WriteLine("I have a million!!!!!");
        }

        public void Organize()
        {
            Console.WriteLine("I organize all work in shop!!!");
        }

        public string Work()
        {
            return "I am managing all work!!!((((((((((";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IManager director = new Director
            {
                FirstName = "John",
                LastName = "Grizli",
                Birthday = new DateTime(1990, 10, 25),
                Position = "Director",
                Salary = 300000
            };
            Console.WriteLine(director);

            director.MakeBudget();

            IWorkable seller = new Seller
            {
                FirstName = "Olga",
                LastName = "Ivanchuk",
                Birthday = new DateTime(1995, 5, 17),
                Position = "Seller",
                Salary = 7350
            };
            Console.WriteLine(seller);

            Console.WriteLine(seller.Work());

            if(seller is Seller)
                Console.WriteLine($"Seller salary : { (seller as Seller).Salary}");


            director.ListOfWorkers = new List<IWorkable>
            { 
                 seller,
                  new Administrator
                  {
                      FirstName = "Sasha",
                    LastName = "Oliunuk",
                    Birthday = new DateTime(1985, 5, 17),
                    Position = "Administrator",
                    Salary = 21000
                  },
                  new Cashier
                  {
                      FirstName = "Ivanka",
                    LastName = "Petruc",
                    Birthday = new DateTime(2001, 5, 17),
                    Position = "Cashier",
                    Salary = 1000
                  }
            };

            foreach (var worker in director.ListOfWorkers)
            {
                Console.WriteLine(worker);
                if(worker is Administrator)
                    Console.WriteLine("Administrator");

                if(worker.IsWorking)
                    Console.WriteLine(worker.Work());
            }

            Administrator admin = new Administrator();//address

            IManager manager = admin;//address = address
            manager.Organize();

            IWorkable worker1 = admin;
            worker1.Work();

        }
    }
}