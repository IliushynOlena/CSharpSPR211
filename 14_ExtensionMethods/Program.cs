namespace _14_ExtensionMethods
{
    static class ExampleExtensions
    {
        public static int NumberWords(this string data)
        {
            if (string.IsNullOrEmpty(data)) return 0;
            return data.Split(new char[] { ' ', ',', '.' }, 
                StringSplitOptions.RemoveEmptyEntries).Length;
          
        }
        public static int NumberSymbols(this string data, char s)
        {
            if (string.IsNullOrEmpty(data)) return 0;
            int count = 0;
            foreach (char c in data)
            {
                if (c == s) count++;
            }
            return count;
        }

    }
    class ExampleNameOf
    {
        public string Name { get; set; }
        public ExampleNameOf(string FinishAction)
        {
            if(FinishAction == null)
                throw new ArgumentNullException(nameof(FinishAction));

            Name = FinishAction;
        }
       
    }
    internal class Program
    {      
        static void Main(string[] args)
        {
            int a = 5;
            Console.WriteLine(a);
            string str = "1";
            string copy;//null
            if(true)
            {
                int b = 10;
                string str2 = "2";//0c2c2c
                copy = str2;//0c2c2c = 0c2c2c
                Console.WriteLine(b) ;
                Console.WriteLine(str2) ;
            }
            //Console.WriteLine(b);
           // Console.WriteLine(str2);
            Console.WriteLine(copy);
            Console.WriteLine(copy + str);
            /*

            try
            {
                ExampleNameOf nameOf = new ExampleNameOf(null);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }




            Console.WriteLine("Enter string");
            string str = Console.ReadLine();

            Console.WriteLine("Number of words : " + str.NumberWords()); 
            Console.WriteLine("Number of symbol 'o' : " + str.NumberSymbols('o'));
            int[] arr = new int[] { 2, 2, 2, 8,8, 8, 8, 3, 3, 3 };
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            IEnumerable<int> res = arr.Distinct();
            foreach (var item in res)
            {
                Console.Write(item + " ");
            }
            */
        }
    }
}