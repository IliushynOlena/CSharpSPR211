namespace _07_Indexers
{
    class Laptop
    {
        //Auto-prop
        public string? Model { get; set; }//null
        public double Price { get; set; }// null
        public override string ToString()
        {
            return $"{Model }  {Price}";
        }
    }
    class Shop
    {
        Laptop[] laptopArr = null;
        public Shop(int size)//5
        {
            laptopArr = new Laptop[size];
        }
        public int Lenght { get { return laptopArr.Length; } }//read only

        public Laptop GetLaptop(int index)
        {
            if(index >= 0 && index < laptopArr.Length)
                return laptopArr[index];  
            throw new IndexOutOfRangeException();
        }
        public void SetLaptop(int index, Laptop value)
        {
            if (index >= 0 && index < laptopArr.Length)
                 laptopArr[index] = value;
            else
            {
                throw new IndexOutOfRangeException();
            }
           
        }
        public Laptop this[int index]
        {
            get 
            {
                if (index >= 0 && index < laptopArr.Length)
                    return laptopArr[index];
                throw new IndexOutOfRangeException();
            }
            set 
            {
                if (index >= 0 && index < laptopArr.Length)
                    laptopArr[index] = value;
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        public Laptop this[string model]//read only
        {
            get 
            {
                foreach (var lep in laptopArr)
                {
                    if (lep.Model == model)
                        return lep;
                }
                return null;
            }
            //private set 
            //{
            //    for (int i = 0; i < laptopArr.Length; i++)
            //    {
            //        if (laptopArr[i].Model== model)
            //        {
            //            laptopArr[i] = value;
            //            break;
            //        }
            //    }
            //}
        }

        public int FindByPrice(double price)
        {
            for (int i = 0; i < laptopArr.Length; i++)
            {
                if (laptopArr[i].Price == price)
                {
                    return i;
                }
            }
            return -1;
        }
        public Laptop this[double price]
        {
            get 
            {
               int index = FindByPrice(price);
                if(index != -1) 
                    return laptopArr[index];
                throw new Exception("Incorrect price");
            }
            set {
                int index = FindByPrice(price);
                if (index != -1) 
                    this[index] = value;
            }
        
        }

        }
    public class MultArray
    {
        private int[,] array;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public MultArray(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            array = new int[rows, cols];
        }
        public int this[int r, int c]
        {
            get { return array[r, c]; }
            set { array[r, c] = value; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            MultArray multArray = new MultArray(2, 3);

            for (int i = 0; i < multArray.Rows; i++)
            {
                for (int j = 0; j < multArray.Cols; j++)
                {
                    multArray[i, j] = i + j;//indexator - set
                    Console.Write($"{multArray[i, j]} ");//indexator - get
                }
                Console.WriteLine();
            }
            */
            Shop shop = new Shop(3);

            shop.SetLaptop(0, new Laptop() { Model = "HP", Price = 25250.99 });
            Console.WriteLine(shop.GetLaptop(0));
            shop[1]=new Laptop() {  Model ="Asus", Price = 32000.33};//setter index
            Laptop laptop = shop[1];//getter index
            Console.WriteLine(laptop);

            shop[2] = new Laptop() { Model = "DELL", Price = 54000.99 };//setter

            try
            {
                for (int i = 0; i < shop.Lenght + 2; i++)
                {
                    Console.WriteLine(shop[i]);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

           // shop["HP"] = new Laptop() { Model = "Mac", Price = 100_000 };//setter name

            Console.WriteLine(shop["HP"]);
            Console.WriteLine("---------------------------");
            for (int i = 0; i < shop.Lenght ; i++)
            {
                Console.WriteLine(shop[i]);
            }

            //shop[54000.99] = new Laptop();
            Console.WriteLine(shop[54000.99]);
            //Console.WriteLine("---------------------------");
            //for (int i = 0; i < shop.Lenght; i++)
            //{
            //    Console.WriteLine(shop[i]);
            //}
        }
    }
}