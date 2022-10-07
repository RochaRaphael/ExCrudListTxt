using System;


namespace ArquiovoTxtListaOrdenada
{
    /// <summary>
    /// Manipulate txt files using list.
    /// </summary>
    public static class ManipulateTxt
    {
        /// <summary>
        /// Get the data from the txt file, and set in the list
        /// </summary>
        /// <param name="filePath">txt file path</param>
        /// <param name="list">List where data will be manipulated</param>
        private static void LoadList(string filePath, List<string> list)
        {
            int cont = 0;
            using (var sw = File.OpenText(filePath))
            {
                while (sw.EndOfStream != true)
                {
                    list.Insert(cont, sw.ReadLine());
                    cont++;
                }
                sw.Close();
            }
        }
        /// <summary>
        /// Get the data from the list, and set in the txt file
        /// </summary>
        /// <param name="filePath">txt file path</param>
        /// <param name="list">List where data will be manipulated</param>
        private static void InsertListInTxt(string filePath, List<string> list)
        {
            using (var fi = File.CreateText(filePath))
            {
                foreach (string item in list)
                {
                    fi.WriteLine(item);
                }
                fi.Close();
            }
        }
        /// <summary>
        /// insert a product directly into the txt file
        /// </summary>
        /// <param name="filePath">txt file path</param>
        public static void InsertProduct(string filePath)
        {
            using (var sw = File.AppendText(filePath))
            {
                Console.Write("Enter the product name: ");
                string item = Console.ReadLine();
                sw.WriteLine(item);
            }
        }
        /// <summary>
        /// Show all products in the txt file
        /// </summary>
        /// <param name="filePath">txt file path</param>
        public static void ShowTxtFile(string filePath)
        {
            using var sr = new StreamReader(filePath);
            {
                string? line;
                Console.WriteLine("    MARKET LIST");
                while ((line = sr.ReadLine()) != null)
                    Console.WriteLine(" -" + line);

                Console.WriteLine();
            }
            sr.Close();
        }
        /// <summary>
        /// Delete a product using the list
        /// </summary>
        /// <param name="filePath">txt file path</param>
        public static void DeleteProduct(string filePath)
        {
            Console.WriteLine("Which product do you want to delete?");
            string? delProduct = Console.ReadLine();
            try
            {
                bool find = false;
                using var sr = new StreamReader(filePath);
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null && find == false)
                    {
                        if (line == delProduct)
                        {
                            find = true;
                        }
                    }
                }
                sr.Close();

                if (find)
                {
                    List<string> list = new List<string>();
                    LoadList(filePath, list);
                    list.Remove(delProduct);
                    InsertListInTxt(filePath, list);
                }
                else
                {
                    Console.WriteLine("Product not found");
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Sort the list of products in alphabetical order, using the list and the sort() method
        /// </summary>
        /// <param name="filePath">txt file path</param>
        public static void OrderList(string filePath)
        {
            List<string> list = new List<string>();
            LoadList(filePath, list);
            list.Sort();
            InsertListInTxt(filePath, list);

            Console.WriteLine("**ORDERED LIST**");
        }
        /// <summary>
        /// Update a product using the list
        /// </summary>
        /// <param name="filePath">txt file path</param>
        public static void UpdteProduct(string filePath)
        {
            int cont = 0;
            bool find = false;
            Console.WriteLine("Which product do you want to update?");
            string oldProduct = Console.ReadLine();
            try
            {
                using (var sr = new StreamReader(filePath))
                {

                    string? line;
                    while ((line = sr.ReadLine()) != null && find == false)
                    {
                        if (line == oldProduct)
                        {
                            find = true;
                        }
                    }
                }

                if (find)
                {
                    Console.WriteLine("Set new product: ");
                    string newProduct = Console.ReadLine();

                    List<string> list = new List<string>();
                    LoadList(filePath, list);

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == oldProduct)
                        {
                            list[i] = newProduct;
                        }
                    }

                    InsertListInTxt(filePath, list);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
