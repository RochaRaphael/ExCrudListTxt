using ArquiovoTxtListaOrdenada;

namespace ExCrudListTxt
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            bool close = false;
            string path = @"C:\Temp";
            string fileName = "Market List.txt";
            string filePath = path + "\\" + fileName;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (!File.Exists(filePath))
                File.CreateText(filePath);

            while (close == false)
            {
                Console.WriteLine("WELCOME TO YOUR MARKET LIST");
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1- Insert product");
                Console.WriteLine("2- Show List");
                Console.WriteLine("3- Delete a product");
                Console.WriteLine("4- Sort in alphabetical order");
                Console.WriteLine("5- Update product");

                opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        ManipulateTxt.InsertProduct(filePath);
                        break;
                    case 2:
                        ManipulateTxt.ShowTxtFile(filePath);
                        break;
                    case 3:
                        ManipulateTxt.DeleteProduct(filePath);
                        break;
                    case 4:
                        ManipulateTxt.OrderList(filePath);
                        break;
                    case 5:
                        ManipulateTxt.UpdteProduct(filePath);
                        break;
                    default:
                        Console.WriteLine("Good shopping");
                        close = true;
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("YOUR MARKET LIST");
            ManipulateTxt.ShowTxtFile(filePath);
        }
    }
}
