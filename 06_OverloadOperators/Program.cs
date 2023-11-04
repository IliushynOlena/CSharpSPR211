namespace _06_OverloadOperators
{
    class Point3D
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public Point3D(): this(0, 0, 0) { }
       
        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override string ToString()
        {
            return $"Point 3D : {X}:{Y}:{Z}";
        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point() : this(0, 0) { }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"X = {X}:  Y = {Y}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        //ref and out - not allow
        //public static return_type operator[symbol](parameters){//code}
        #region Унарні оператори
        public static Point operator -(Point point)
        {
            Point p = new Point { X= -point.X, Y = -point.Y };
            return p;
        }
        public static Point operator ++(Point point)
        {
            point.X++;
            point.Y++;
            return point;
        }
        public static Point operator --(Point point)
        {
            point.X--;
            point.Y--;
            return point;
        }
        #endregion
        #region Бінарні оператори
        public static Point operator+(Point p1, Point p2)
        {
            Point p = new Point
            {
                X = p1.X + p2.X,
                Y = p1.Y + p2.Y
            };
            return p;
        }
        public static Point operator -(Point p1, Point p2)
        {
            Point p = new Point
            {
                X = p1.X - p2.X,
                Y = p1.Y - p2.Y
            };
            return p;
        }
        public static Point operator *(Point p1, Point p2)
        {
            Point p = new Point
            {
                X = p1.X * p2.X,
                Y = p1.Y * p2.Y
            };
            return p;
        }
        public static Point operator /(Point p1, Point p2)
        {
            Point p = new Point
            {
                X = p1.X / p2.X,
                Y = p1.Y / p2.Y
            };
            return p;
        }
        #endregion
        #region Оператори порівняння
        public static bool operator ==(Point p1, Point p2)
        {
            //return p1.X == p2.X && p1.Y == p2.Y;
            return p1.Equals(p2);
        }
        //in pair
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1==p2);
        }
        #endregion

        #region Логічні Оператори 
        public static bool operator >(Point p1, Point p2)
        {            
            return p1.X + p1.Y > p2.X+ p2.Y;
        }
        //in pair
        public static bool operator < (Point p1, Point p2)
        {
            return p1.X + p1.Y < p2.X + p2.Y;
        }
        public static bool operator >=(Point p1, Point p2)
        {
            return p1.X + p1.Y >= p2.X + p2.Y;
        }
        //in pair
        public static bool operator <=(Point p1, Point p2)
        {
            return p1.X + p1.Y <= p2.X + p2.Y;
        }
        #endregion
        #region true/false operators
        public static bool operator true(Point p)
        {
            return (p.X != 0) || (p.Y != 0);    
        }
        //in pair
        public static bool operator false(Point p)
        {
            return (p.X == 0) && (p.Y == 0);
        }
        #endregion
        #region Overload types
        public static explicit operator int(Point p)
        {
            return p.X + p.Y;
        }
        public static explicit operator double(Point p)
        {
            return p.X * p.Y;
        }
        public static implicit operator Point3D(Point p)
        {
            return new Point3D(p.X, p.Y, 0);
        }
        #endregion
    }



    internal class Program
    {
        //static void MethodWithParams(string name,params int[]marks)
        //{
        //    Console.WriteLine($"--------------{name}--------------");
        //    for (int i = 0; i < marks.Length; i++)
        //    {
        //        Console.Write(marks[i] + " ");
        //    }
        //    Console.WriteLine();
        //}
        static void MethodWithParams(string name,string name2, int a, int b, int c,
            params int[] marks)
        {
            Console.WriteLine($"--------------{name}--------------");
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("c = " + c);
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write(marks[i] + " ");
            }
            Console.WriteLine();
        }
        static void Modify(ref int num,ref string str,ref Point point)
        {
            num += 1;
            str += "!!!";
            point.X++;
            point.Y++;
        }
        static void GetCurrentTime(out int hour,out int minute,out int second)
        {
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;
        }

        static void Main(string[] args)
        {
            int a = 5;//int => int
            double b = 6.7;//double => double

           // b = a;//int => double - implicit 5.00000000000000
            //a = (int) b;//double => int - explicit 
            Point test = new Point(2, 3);

            a =(int) test;//Point => int - implicit
            Console.WriteLine(a);
            b = (double)test;//Point => double - implicit
            Console.WriteLine(b);
            Point3D point3D = test;//Point => Point3D
            Console.WriteLine(point3D);

            object obj = new object();
          
            string str = "Hello";//0x1258
            string str2 = "Hello";//0x1285
            string str4 = "Hello";//0x1285
            string str3 = "Hello";//0x1285
            string str9 = "Hello";//0x1285
            string str8 = "Hello";//0x1285

            str += "!!!!";
            if (str.Equals(str2))
            {
                Console.WriteLine("References is equals");
            }
            else
            {
                Console.WriteLine("References is not equals");
            }



            Point point1 = new Point(5,7);//new dyman memory 0v1455

            Point point2 = new Point(5,7);//new dyman memory 0v1857
            //point1 + point2;
            if(point1)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }



            if(point1 == point2)
                Console.WriteLine("Point is equals");
            else
                Console.WriteLine("Point is not equals");

            if (point1 > point2)
                Console.WriteLine("Point 1 > point 2");
            else
                Console.WriteLine("Point 1 !> point 2");

            if (point1 < point2)
                Console.WriteLine("Point 1 < point 2");
            else
                Console.WriteLine("Point 1 !< point 2");





            Console.WriteLine("Point 1 : "+ point1);
            Console.WriteLine("Point 1 (++point) : "+ ++point1);
            Console.WriteLine("Point 1 (--point) : "+ --point1);
            Console.WriteLine("Point 1 (point++) : "+ point1++);
            Console.WriteLine("Point 1 (point--) : "+ point1--);

            Point res = -point1;
            Console.WriteLine("Res point : " + res);

            res = point1 + point2;
            Console.WriteLine("Res point + : " + res);
            res = point1 - point2;
            Console.WriteLine("Res point - : " + res);
            res = point1 * point2;
            Console.WriteLine("Res point * : " + res);
            res = point1 / point2;
            Console.WriteLine("Res point / : " + res);





            #region Ref Out Params
            /*  //out
            int h, m, s;
            //Console.WriteLine($"{h}:{m}:{s}");
            GetCurrentTime(out h,out m, out s);
            Console.WriteLine($"{h}:{m}:{s}");




            //ref
            int num = 10;
            string str = "Hello academy";

            Point point = new Point(5, 7);
            Console.WriteLine("Num = " + num);
            Console.WriteLine("str = " + str);
            Console.WriteLine("Point = " + point);

            Modify(ref num,ref str,ref point);
            Console.WriteLine();
            Console.WriteLine("Num = " + num);
            Console.WriteLine("str = " + str);
            Console.WriteLine("Point = " + point);
           

            /*
            /////Params
            int[] marks = { 12, 11, 4, 7, 9, 12, 10 };
            //MethodWithParams("Bob", marks);
            //MethodWithParams("Tom", new int[] { 10, 10, 10, 12, 11, 10, 12 });
            MethodWithParams("Tom","Jack",  10, 10, 10, 12, 11, 10, 12 ,1,12,5,9,8,6);
            */
            #endregion


        }
    }
}