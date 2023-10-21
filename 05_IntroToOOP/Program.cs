namespace _05_IntroToOOP
{
    /*
     *Access spetificators:
     *private (default for ALL fields)
     *protected
     *protected internal
     *internal
     *public  
     
     */
    public class MyClass// :Object
    {
        //class body
        private int number ;
        private string name ;
        private const float PI = 3.14f;
        private readonly int Id;
        public MyClass()
        {
            Id = 10;
        }
        //void setId(int id)
        //{
        //    Id = id;
        //}
        public void Print()
        {
            Console.WriteLine($"Id {Id}. Name {name}");
        }
        public override string ToString()
        {
            return $"Id {Id}. Name {name}"; //Animal::Print();
        }

    }
    class DerivedClass : MyClass
    {

    }

    partial class Point
    {
        private int xCoord;
        public int XCoord
        {
            get
            {
                return xCoord;
            }
            set // value
            {
                if (value >= 0)
                    xCoord = value;
                else
                    xCoord = 0;
            }
        }
        private int yCoord;
        public int YCoord
        {
            get
            {
                return yCoord;
            }
            set // value
            {
                if (value >= 0)
                    yCoord = value;
                else
                    yCoord = 0;
            }
        }
        //Full Property
        //private string name;
        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}
        //Auto properti - prop + TAB!!!
        public string Name { get; set; }
        public string Type { get; }//read only field
        public string Address { get; private set; }
        public string Color { get; private set; } = "Red";
        //Full prop + Tab
        private int number;
        public int Number
        {
            get { return number; }
            set
            {
                if (value >= 0) number = value;
                else number = 0;
            }
        }
        static int count;
        static Point()
        {
            count = 0;
        }
        public Point() : this(0, 0) { }
        public Point(int value) : this(value, value) { }
        public Point(int x, int y)
        {
            XCoord = x;//setter
            YCoord = y;

            //SetXCoord(x);
            //SetYCoord(y);
        }
      

    }

    struct MyStruct
    {
        public int x;
        public int y;
        public void Print()
        {
            Console.WriteLine($"X : {x}. Y { y}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetCursorPosition(10, 10);
            Point point = new Point(5,-3);
            point.Print();
            Console.WriteLine(point);

            point.SetXCoord(9);
            Console.WriteLine(point);

            Console.WriteLine($"Y =  {point.getY()} . X = { point.getX()}");
            //point.xCoord = value
            point.XCoord = 15;//setter
            int x = point.XCoord;
            Console.WriteLine(x); //getter
            Console.WriteLine(point);

            point.Name = "2D_Point";//setter
            Console.WriteLine(point.Name);//getter
            Console.WriteLine(point);
            Point newP = new Point(50);
            Console.WriteLine(newP);
            /*
            MyClass myClass = new MyClass();
            myClass.Print();
            Console.WriteLine(myClass.ToString());
            */



            MyClass @class = new MyClass();
        }
    }
}