using System.Collections;

namespace _10_StandartInterface
{

    class StudentCard : ICloneable
    {
        public int Number { get; set; }
        public string Series { get; set; }

        public object Clone()
        {
            StudentCard copy = this.MemberwiseClone() as StudentCard;
            return copy;
        }

        public override string ToString()
        {
            return $"Number : {Number}. Series : {Series}";
        }
    }
    class Student : IComparable<Student>, ICloneable
    {
        public string FirstName { get; set; }//0x123 - 0x123
        public string LastName { get; set; }//0x147 - 0x147
        public DateTime Birthdate { get; set; }//2000-5-9  - 2000-5-9
        public StudentCard StudentCard { get; set; }//0x336 - 0x336

        public object Clone()
        {
            Student copy = (Student)this.MemberwiseClone();
            //copy.FirstName = (string)this.FirstName.Clone();
            //copy.LastName = (string)this.LastName.Clone();
            //copy.StudentCard = new StudentCard()
            //{
            //    Number = this.StudentCard.Number,
            //    Series = this.StudentCard.Series
            //};
            copy.StudentCard= this.StudentCard.Clone() as StudentCard;


            return copy;
        }

        public int CompareTo(Student? other)
        {
            return FirstName.CompareTo(other.FirstName);
        }
     

        public override string ToString()
        {
            return $"Name : {FirstName}. Last Name : {LastName}. Birthdate : {Birthdate.ToShortDateString()}" +
                $"\n{StudentCard}";
        }
    }
    class LastNameComparer : IComparer<Student>
    {
        //public int Compare(object? x, object? y)
        //{
        //    if (x is Student && y is Student)
        //    {
        //        return (x as Student).LastName.CompareTo((y as Student).LastName);
        //    }
        //    throw new NotImplementedException();
        //}
        public int Compare(Student? x, Student? y)
        {
            return x.LastName.CompareTo(y.LastName);
        }
    }
    class BirthdayComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            return x.Birthdate.CompareTo(y.Birthdate);
        }
    }
    class Auditory : IEnumerable
    {
        Student[] students = null;//Array
        public Auditory()
        {
            students = new Student[]//Array
            {
                new Student
                {
                    FirstName = "Bill",
                    LastName = "Tomson",
                    Birthdate = new DateTime(2005, 4, 7),
                    StudentCard = new StudentCard() { Number = 123456, Series = "AA" }
                },
            new Student
            {
                FirstName = "Olga",
                LastName = "Ivanchuk",
                Birthdate = new DateTime(2003, 10, 17),
                StudentCard = new StudentCard() { Number = 321456, Series = "BA" }
            },
            new Student
            {
                FirstName = "Candice",
                LastName = "Leman",
                Birthdate = new DateTime(2006, 3, 12),
                StudentCard = new StudentCard() { Number = 7412585, Series = "AA" }
            },
            new Student
            {
                FirstName = "Nicol",
                LastName = "Taylor",
                Birthdate = new DateTime(2004, 7, 14),
                StudentCard = new StudentCard() { Number = 963258, Series = "BK" }
            }
             };
        }

        public IEnumerator GetEnumerator()
        {
            
            return students.GetEnumerator();
        }

        public void Sort()
        {
            Array.Sort(students);
        }
        public void Sort(IComparer<Student> comparer)
        {
            Array.Sort(students,comparer);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Student original = new Student
            {
                FirstName = "Bill",
                LastName = "Tomson",
                Birthdate = new DateTime(2005, 4, 7),
                StudentCard = new StudentCard() { Number = 123456, Series = "AA" }
            };
            Console.WriteLine(original);
            Student copy = (original.Clone() as Student)!;
            copy.StudentCard.Number = 3333333;
            copy.FirstName = "Lilia";
            Console.WriteLine(copy);
            Console.WriteLine(original);
            Console.WriteLine("__________________________________________");





            Auditory auditory = new Auditory();
            Console.WriteLine("List of Students");
            foreach (Student st in auditory)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine("-----------------------");
            auditory.Sort();
            foreach (Student st in auditory)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine("-----------------------");
            auditory.Sort(new LastNameComparer());
            foreach (Student st in auditory)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine("-----------------------");
            auditory.Sort(new BirthdayComparer());
            foreach (Student st in auditory)
            {
                Console.WriteLine(st);
            }


        }
    }
}