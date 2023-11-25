namespace _11_Delegates
{

    //public class MyClass : MulticastDelegate
    //{

    //}

    public delegate void MyDelegate();
    public delegate int IntDelegate(double b);

    public delegate void SetStringDelegate(string str);
    public delegate double GetDoubleDelegate();
    public delegate void VoidDelegate();

    class SuperClass
    {

        public void Print(string str)
        {
            Console.WriteLine("String : "+ str);
        }
        public static double GetCoef()
        {
            double res = new Random().NextDouble();
            return res;
        }
        public double GetNumber()
        {
            return  new Random().Next();           
        }
        public void DoWork()
        {
            Console.WriteLine("Doing work......");
        }
        public void Test()
        {
            Console.WriteLine("Testing......");
        }
    }
    public delegate double CalcDelegate(double x, double y);
    class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Sub(double x, double y)
        {
            return x - y;
        }
        public double Multy(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            if (y != 0)
                return x / y;
            throw new DivideByZeroException();
        }
    }
    delegate int ChangeDelegate(int value);
    internal class Program
    {
        public static void DoOperation(double a, double b, CalcDelegate operation)
        {
            Console.WriteLine(operation.Invoke(a, b));
        }
        static int Increment(int value)
        {
            return ++value;
        }
        static int Pow(int value)
        {
            return value * value;
        }
        static void ChangeElement(int[]arr, ChangeDelegate change )
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = change(arr[i]);
            }
        }
        static void Main(string[] args)
        {
            
            int[] arr = new int[] { 1, 5, 8, 9, 6, 3, 4, 7, 10 };
            foreach (var item in arr) Console.Write(item + " "); Console.WriteLine();
            ChangeElement(arr, Increment);
            foreach (var item in arr) Console.Write(item + " "); Console.WriteLine();
            ChangeElement(arr, Pow);
            foreach (var item in arr) Console.Write(item + " "); Console.WriteLine();
            ChangeElement(arr, delegate (int v) { return ++v; });
            foreach (var item in arr) Console.Write(item + " "); Console.WriteLine();
            ChangeElement(arr, (v) => ++v);
            foreach (var item in arr) Console.Write(item + " "); Console.WriteLine();



            /*
            Calculator calculator = new Calculator();
            double x, y;
            int key;
            do
            {
                CalcDelegate calcDelegate = null;
                Console.WriteLine("Enter first number ");
                x = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter second number ");
                y = double.Parse(Console.ReadLine());
                Console.WriteLine("Add  - 1 ");
                Console.WriteLine("Sub  - 2 ");
                Console.WriteLine("Mult  - 3 ");
                Console.WriteLine("Divide  - 4 ");
                Console.WriteLine("Exit  - 0 ");
                key = int.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        calcDelegate = new CalcDelegate(calculator.Add);
                        break;
                    case 2:
                        calcDelegate = new CalcDelegate(calculator.Sub);
                        break;
                    case 3:
                        calcDelegate = calculator.Multy;
                        break;
                    case 4:
                        calcDelegate = calculator.Div;
                        break;
                    case 0:
                        Console.WriteLine("Good  Buy");
                        break;
                    default:
                        Console.WriteLine("Error choice......");
                        break;
                }

                Console.WriteLine("Res = " + calcDelegate?.Invoke(x, y));
            } while (key != 0);
            */



            Calculator calculator = new Calculator();
          CalcDelegate operation = calculator.Add;
          operation += calculator.Sub;
          operation += calculator.Multy;
          operation += calculator.Div;
          operation -= calculator.Div;

          Console.WriteLine("Last operation : " + operation(10, 5));
          foreach (CalcDelegate item in operation.GetInvocationList())
          {
              Console.WriteLine($" {item.Method.Name} - Result {item.Invoke(145, 3)}");
          }

          Console.WriteLine("------------------------");
            DoOperation(100, 12, operation);
            DoOperation(100, 12, calculator.Add);
            DoOperation(100, 12, calculator.Sub);
            DoOperation(100, 12, calculator.Multy);

            /*
            Console.WriteLine($" Res = {SuperClass.GetCoef()}");
            //Console.WriteLine($" Res = {SuperClass.GetCoef}");
            //GetDoubleDelegate method = new GetDoubleDelegate(SuperClass.GetCoef);
            GetDoubleDelegate method =  SuperClass.GetCoef;
           
            //Console.WriteLine($" Res = {method()}");
            Console.WriteLine($" Res = {method?.Invoke()}");
            SuperClass super = new SuperClass();
            GetDoubleDelegate[] delArr = new GetDoubleDelegate[]
            {
                SuperClass.GetCoef,
                new GetDoubleDelegate(super.GetNumber)
            };

            Console.WriteLine(delArr[0]?.Invoke()); 
            Console.WriteLine(delArr[1]?.Invoke()); 


            GetDoubleDelegate getDoubleDelegate = SuperClass.GetCoef;
            SetStringDelegate stringDelegate = new SetStringDelegate(super.Print);
            VoidDelegate voidDelegate = new VoidDelegate(super.DoWork);

            Console.WriteLine(getDoubleDelegate.Invoke());
            stringDelegate.Invoke("Hello world");
            voidDelegate.Invoke();


            //Delegate.Combine(getDoubleDelegate, new GetDoubleDelegate(super.GetNumber));
            //getDoubleDelegate += new GetDoubleDelegate(super.GetNumber);
            getDoubleDelegate += super.GetNumber;

            foreach (var item in getDoubleDelegate.GetInvocationList())
            {
                Console.WriteLine("Result = " + ((GetDoubleDelegate)item).Invoke());
            }

            Console.WriteLine("Last delegate result = " + getDoubleDelegate.Invoke());
            */
        }
    }
}