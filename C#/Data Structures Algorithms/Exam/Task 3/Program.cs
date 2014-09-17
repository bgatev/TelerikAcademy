namespace Task_3
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Product : IComparable
    {
        public Product(string name, double price, string type)
        {
            this.ProductName = name;
            this.ProductPrice = price;
            this.ProductType = type;
        }

        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductType { get; set; }

        public override bool Equals(object obj)
        {
            var otherProduct = obj as Product;

            return this.ProductName == otherProduct.ProductName;
        }

        public override int GetHashCode()
        {
            return this.ProductName[0] * 13 + this.ProductName[1] * 17 + this.ProductName[2] * 23;
        }

        public int CompareTo(object obj)
        {
            return this.ProductName.CompareTo((obj as Product).ProductName);
        }
    }

    public class Program
    {
        public static void Main()
        {
            string line = string.Empty;

            SortedSet<Product> allProducts = new SortedSet<Product>();

            StringBuilder finalresult = new StringBuilder();

            do
            {
                line = Console.ReadLine();
                string[] command = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "add")    //add product
                {
                    string productName = command[1];
                    double productPrice = double.Parse(command[2]);
                    string productType = command[3];
                    var currentProduct = new Product(productName, productPrice, productType);

                    if (!allProducts.Contains(currentProduct))
                    {
                        allProducts.Add(currentProduct);
                        finalresult.AppendLine(string.Format("Ok: Product {0} added successfully", currentProduct.ProductName));
                        //Console.WriteLine("Ok: Product {0} added successfully", currentProduct.ProductName);
                    }
                    else
                    {
                        //Console.WriteLine("Error: Product {0} already exists", currentProduct.ProductName);
                        finalresult.AppendLine(string.Format("Error: Product {0} already exists", currentProduct.ProductName));
                    }
                }
                else if (command[0] == "filter" && command[2] == "type") //filter by type
                {
                    string productType = command[3];

                    var result = allProducts.Where(pt => pt.ProductType == productType).OrderBy(p => p.ProductPrice);//.ThenBy(n => n.ProductName).ThenBy(t => t.ProductType);

                    StringBuilder sb = new StringBuilder();
                    sb.Append("Ok: ");

                    int counter = 0;
                    foreach (var product in result)
                    {
                        //if (product.ProductType == productType)
                        //{
                            sb.Append(string.Format("{0}({1}), ", product.ProductName, product.ProductPrice));
                        //}
                        counter++;
                        if (counter == 10) break;
                    }

                    string printLine = sb.ToString();
                    printLine = printLine.Substring(0, printLine.Length - 2);

                    if (printLine.Length > 3) finalresult.AppendLine(printLine);//Console.WriteLine(printLine);
                    else finalresult.AppendLine(string.Format("Error: Type {0} does not exists", productType));// Console.WriteLine("Error: Type {0} does not exists", productType);
                }
                else if (command[0] == "filter" && command[2] == "price" && command[3] == "to") //filter by price to 
                {
                    double maxPrice = double.Parse(command[4]);

                    var result = allProducts.Where(pp => pp.ProductPrice <= maxPrice).OrderBy(p => p.ProductPrice).ThenBy(t => t.ProductType);//.ThenBy(n => n.ProductName).ThenBy(t => t.ProductType);
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Ok: ");

                    int counter = 0;
                    foreach (var product in result)
                    {
                        //if (product.ProductPrice <= maxPrice)
                        //{
                            sb.Append(string.Format("{0}({1}), ", product.ProductName, product.ProductPrice));
                        //}
                        counter++;
                        if (counter== 10) break;
                    }

                    string printLine = sb.ToString();
                    if (printLine.Length > 5) printLine = printLine.Substring(0, printLine.Length - 2);
                    
                    finalresult.AppendLine(printLine);
                    //Console.WriteLine(printLine);
                }
                else if (command[0] == "filter" && command[2] == "price" && command[3] == "from")
                {
                    double minPrice = double.Parse(command[4]);
                    double maxPrice = 0;
                    if (command.Length > 5)
                    {
                        maxPrice = double.Parse(command[6]);
                    }

                    var result = allProducts.Where(pp => pp.ProductPrice >= minPrice).OrderBy(p => p.ProductPrice).ThenBy(t => t.ProductType);//.ThenBy(n => n.ProductName).ThenBy(t => t.ProductType);
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Ok: ");

                    int counter = 0;
                    foreach (var product in result)
                    {
                        if (maxPrice == 0)
                        {
                            //if (product.ProductPrice >= minPrice)
                            //{
                                sb.Append(string.Format("{0}({1}), ", product.ProductName, product.ProductPrice));
                            //}
                            counter++;
                            if (counter == 10) break;
                        }
                        else
                        {
                            //if (product.ProductPrice >= minPrice && product.ProductPrice <= maxPrice)
                            if (product.ProductPrice <= maxPrice)
                            {
                                sb.Append(string.Format("{0}({1}), ", product.ProductName, product.ProductPrice));
                            }
                            else break;

                            counter++;
                            if (counter == 10) break;
                        }
                    }

                    string printLine = sb.ToString();
                    if (printLine.Length > 5) printLine = printLine.Substring(0, printLine.Length - 2);

                    finalresult.AppendLine(printLine);
                    //Console.WriteLine(printLine);

                }
            }
            while (line != "end");

            Console.WriteLine(finalresult.ToString());
        }
    }
}
