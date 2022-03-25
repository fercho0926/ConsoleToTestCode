using LinQ.EntityClasses;
using LinQ.RepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinQ.ViewModelClasses
{
    public class SamplesViewModel
    {
        #region Constructor
        public SamplesViewModel()
        {
            // Load all Product Data
            Products = ProductRepository.GetAll();

            // Load all Sales Data
            Sales = SalesOrderDetailRepository.GetAll();
        }
        #endregion

        #region Properties
        public bool UseQuerySyntax { get; set; }
        public List<Product> Products { get; set; }
        public List<SalesOrderDetail> Sales { get; set; }

        public string ResultText { get; set; }
        #endregion

        #region GetAllLooping
        /// <summary>
        /// Put all products into a collection via looping, no LINQ
        /// </summary>
        public void GetAllLooping()
        {
            List<Product> list = new List<Product>();

            foreach (Product item in Products)
            {
                list.Add(item);
            }


            ResultText = $"Total Products: {list.Count}";
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Put all products into a collection using LINQ
        /// </summary>
        public void GetAll()
        {
            List<Product> list = new List<Product>();

            if (UseQuerySyntax)
            {
                // Query Syntax
                list = (from prod in Products select prod).ToList();

            }
            else
            {
                // Method Syntax
                list = (Products.Select(prod => prod).ToList());

            }

            ResultText = $"Total Products: {list.Count}";
        }
        #endregion

        #region GetSingleColumn
        /// <summary>
        /// Select a single column
        /// </summary>
        public void GetSingleColumn()
        {
            StringBuilder sb = new StringBuilder(1024);
            List<string> list = new List<string>();

            if (UseQuerySyntax)
            {
                // Query Syntax
                list.AddRange(from prod in Products select prod.Name);
            }
            else
            {
                // Method Syntax
                list.AddRange(Products.Select(prod => prod.Name));

            }

            foreach (string item in list)
            {
                sb.AppendLine(item);
            }

            ResultText = $"Total Products: {list.Count}" + Environment.NewLine + sb.ToString();
            Products.Clear();
        }
        #endregion

        #region GetSpecificColumns
        /// <summary>
        /// Select a few specific properties from products and create new Product objects
        /// </summary>
        public void GetSpecificColumns()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in Products
                            select new Product
                            {
                                ProductID = prod.ProductID,
                                Name = prod.Name,
                                Size = prod.Size
                            }).ToList();


            }
            else
            {
                // Method Syntax
                Products = Products.Select(prod => new Product
                {
                    ProductID = prod.ProductID,
                    Name = prod.Name,
                    Size = prod.Size
                }).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region AnonymousClass
        /// <summary>
        /// Create an anonymous class from selected product properties
        /// </summary>
        public void AnonymousClass()
        {
            StringBuilder sb = new StringBuilder(2048);

            if (UseQuerySyntax)
            {
                // Query Syntax
                var products = (from prod in Products
                                select new
                                {
                                    Identifier = prod.ProductID,
                                    ProductName = prod.Name,
                                    ProductSize = prod.Size
                                });

                // Loop through anonymous class
                foreach (var prod in products)
                {
                    sb.AppendLine($"Product ID: {prod.Identifier}");
                    sb.AppendLine($"   Product Name: {prod.ProductName}");
                    sb.AppendLine($"   Product Size: {prod.ProductSize}");
                }
            }
            else
            {
                // Method Syntax

                var products = Products.Select(prod => new
                {
                    Identifier = prod.ProductID,
                    ProductName = prod.Name,
                    ProductSize = prod.Size
                });


                //Loop through anonymous class
                foreach (var prod in products)
                {
                    sb.AppendLine($"Product ID: {prod.Identifier}");
                    sb.AppendLine($"   Product Name: {prod.ProductName}");
                    sb.AppendLine($"   Product Size: {prod.ProductSize}");
                }
            }

            ResultText = sb.ToString();
            Products.Clear();
        }
        #endregion

        #region OrderBy
        /// <summary>
        /// Order products by Name
        /// </summary>
        public void OrderBy()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in Products
                            orderby prod.Name
                            select prod).ToList();
            }
            else
            {
                // Method Syntax
                Products = Products.OrderBy(prod => prod.Name).ToList();
            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region OrderByDescending Method
        /// <summary>
        /// Order products by name in descending order
        /// </summary>
        public void OrderByDescending()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in Products
                            orderby prod.Name descending
                            select prod).ToList();

            }
            else
            {
                // Method Syntax
                Products = Products.OrderByDescending(prod => prod.Name).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region OrderByTwoFields Method
        /// <summary>
        /// Order products by Color descending, then Name
        /// </summary>
        public void OrderByTwoFields()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in Products
                            orderby prod.Name descending, prod.ProductID
                            select prod).ToList();

            }
            else
            {
                // Method Syntax
                Products = Products.OrderByDescending(prod => prod.Name)
                    .ThenBy(prod => prod.ProductID).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region WhereExpression
        public void WhereExpression()
        {
            string search = "L";

            if (UseQuerySyntax)
            {
                //Query syntax
                Products = (from prod in Products
                            where prod.Name.StartsWith(search)
                            select prod).ToList();
            }
            else
            {
                //method Syntax
                Products = Products.Where(prod => prod.Name.StartsWith(search)).ToList();
            }
            ResultText = $"Total Products : {Products.Count}";
        }

        #endregion

        #region WhereTwoFields
        public void WhereTwoFields()
        {
            string search = "L";
            decimal cost = 100;

            if (UseQuerySyntax)
            {
                //Query syntax
                Products = (from prod in Products
                            where prod.Name.StartsWith(search)
                            && prod.StandardCost > cost
                            select prod).ToList();
            }
            else
            {
                //method Syntax
                Products = Products.Where(prod => prod.Name.StartsWith(search)
                && prod.StandardCost > cost).ToList();
            }
            ResultText = $"Total Products : {Products.Count}";
        }

        #endregion

        #region WhereExtensionMethod
        public void WhereExtensionMethod()
        {
            string search = "Red";

            if (UseQuerySyntax)
            {
                //Query syntax
                Products = (from prod in Products
                            select prod).ByColor(search).ToList();
            }
            else
            {
                //method Syntax
                Products = Products.ByColor(search).ToList();
            }
            ResultText = $"Total Products : {Products.Count}";
        }

        #endregion

        #region Fisrt
        public void Fisrt()
        {
            string search = "Red";
            Product value;

            try
            {
                if (UseQuerySyntax)
                {
                    //Query syntax
                    value = (from prod in Products
                             select prod).First(prod => prod.Color == search);
                }
                else
                {
                    //method Syntax
                    value = Products.First(prod => prod.Color == search);
                }
                ResultText = $"Found {value}";
            }
            catch (Exception)
            {
                ResultText = "Not Found";
            }
            Products.Clear();
        }

        #endregion

        #region FisrtOrDefault
        public void FisrtOrDefault()
        {
            string search = "Red";
            Product value;


            if (UseQuerySyntax)
            {
                //Query syntax
                value = (from prod in Products
                         select prod).FirstOrDefault(prod => prod.Color == search);
            }
            else
            {
                //method Syntax
                value = Products.FirstOrDefault(prod => prod.Color == search);
            }

            if (value == null)
            {
                ResultText = "Not Found";
            }
            else
            {
                ResultText = $"Found {value}";
            }
            Products.Clear();
        }

        #endregion

        #region Last
        public void Last()
        {
            string search = "Red";
            Product value;

            try
            {
                if (UseQuerySyntax)
                {
                    //Query syntax
                    value = (from prod in Products
                             select prod).Last(prod => prod.Color == search);
                }
                else
                {
                    //method Syntax
                    value = Products.Last(prod => prod.Color == search);
                }
                ResultText = $"Found {value}";
            }
            catch (Exception)
            {
                ResultText = "Not Found";
            }
            Products.Clear();
        }

        #endregion

        #region LastOrDefault
        public void LastOrDefault()
        {
            string search = "Red";
            Product value;


            if (UseQuerySyntax)
            {
                //Query syntax
                value = (from prod in Products
                         select prod).LastOrDefault(prod => prod.Color == search);
            }
            else
            {
                //method Syntax
                value = Products.LastOrDefault(prod => prod.Color == search);
            }

            if (value == null)
            {
                ResultText = "Not Found";
            }
            else
            {
                ResultText = $"Found {value}";
            }
            Products.Clear();
        }

        #endregion

        #region single
        public void single()
        {
            int search = 706;
            Product value;

            try
            {
                if (UseQuerySyntax)
                {
                    //Query syntax
                    value = (from prod in Products
                             select prod).Single(prod => prod.ProductID == search);
                }
                else
                {
                    //method Syntax
                    value = Products.Single(prod => prod.ProductID == search);
                }
                ResultText = $"Found {value}";
            }
            catch (Exception)
            {
                ResultText = "Not Found, OR multiple elements";
            }
            Products.Clear();
        }

        #endregion

        #region SingleOrDefault
        public void SingleOrDefault()
        {
            int search = 706;
            Product value;
            try
            {
                if (UseQuerySyntax)
                {
                    //Query syntax
                    value = (from prod in Products
                             select prod).SingleOrDefault(prod => prod.ProductID == search);
                }
                else
                {
                    //method Syntax
                    value = Products.SingleOrDefault(prod => prod.ProductID == search);
                }

                if (value == null)
                {
                    ResultText = "Not Found";
                }
                else
                {
                    ResultText = $"Found {value}";
                }
            }
            catch (Exception)
            {

                ResultText = "Multiple values founded";
            }




            Products.Clear();
        }

        #endregion

        #region ForEach Method
        /// <summary>
        /// ForEach allows you to iterate over a collection to perform assignments within each object.
        /// In this sample, assign the Length of the Name property to a property called NameLength
        /// When using the Query syntax, assign the result to a temporary variable.
        /// </summary>
        public void ForEach()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in Products
                            let tmp = prod.NameLength = prod.Name.Length
                            select prod).ToList();

            }
            else
            {
                // Method Syntax
              Products.ForEach(prod => prod.NameLength = prod.Name.Length);

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region ForEachCallingMethod Method
        /// <summary>
        /// Iterate over each object in the collection and call a method to set a property
        /// This method passes in each Product object into the SalesForProduct() method
        /// In the SalesForProduct() method, the total sales for each Product is calculated
        /// The total is placed into each Product objects' ResultText property
        /// </summary>
        public void ForEachCallingMethod()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in Products
                            let tmp = prod.TotalSales = SalesForProduct(prod)
                            select prod).ToList();
            }
            else
            {
                // Method Syntax
                Products.ForEach(prod => prod.TotalSales = SalesForProduct(prod));

            }

            ResultText = $"Total Products: {Products.Count}";
        }

        /// <summary>
        /// Helper method called by LINQ to sum sales for a product
        /// </summary>
        /// <param name="prod">A product</param>
        /// <returns>Total Sales for Product</returns>
        private decimal SalesForProduct(Product prod)
        {
            return Sales.Where(sale => sale.ProductID == prod.ProductID)
                        .Sum(sale => sale.LineTotal);
        }
        #endregion

        #region Take Method
        /// <summary>
        /// Use Take() to select a specified number of items from the beginning of a collection
        /// </summary>
        public void Take()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in Products
                            orderby prod.Name
                            select prod)
                            .Take(5).ToList();
            }
            else
            {
                // Method Syntax
                Products = Products.OrderBy(prod => prod.Name).Take(5).ToList(); 

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region TakeWhile Method
        /// <summary>
        /// Use TakeWhile() to select a specified number of items from the beginning of a collection based on a true condition
        /// </summary>
        public void TakeWhile()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in Products
                            orderby prod.Name
                            select prod)
                            .TakeWhile(prod => prod.Name.StartsWith("A")).ToList();
            }
            else
            {
                // Method Syntax
                Products = Products.OrderBy(prod => prod.Name)
                    .TakeWhile(prod => prod.Name.StartsWith("A")).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region Skip Method
        /// <summary>
        /// Use Skip() to move past a specified number of items from the beginning of a collection
        /// </summary>
        public void Skip()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in Products
                            orderby prod.Name
                            select prod)
                          .Skip(20).ToList();

            }
            else
            {
                // Method Syntax
                Products = Products.OrderBy(prod => prod.Name)
                    .Skip(20).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region SkipWhile Method
        /// <summary>
        /// Use SkipWhile() to move past a specified number of items from the beginning of a collection based on a true condition
        /// </summary>
        public void SkipWhile()
        {
            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in Products
                            orderby prod.Name
                            select prod)
                           .SkipWhile(prod => prod.Name.StartsWith("A")).ToList();

            }
            else
            {
                // Method Syntax
                Products = Products.OrderBy(prod => prod.Name)
                    .SkipWhile(prod => prod.Name.StartsWith("S")).ToList();

            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region Distinct
        /// <summary>
        /// The Distinct() operator finds all unique values within a collection
        /// In this sample you put distinct product colors into another collection using LINQ
        /// </summary>
        public void Distinct()
        {
            List<string> colors = new List<string>();

            if (UseQuerySyntax)
            {
                // Query Syntax
                colors = (from prod in Products
                          select prod.Color)
                          .Distinct().ToList();

            }
            else
            {
                // Method Syntax
                colors = Products.Select(prod => prod.Color)
                    .Distinct().ToList();

            }

            // Build string of Distinct Colors
            foreach (var color in colors)
            {
                Console.WriteLine($"Color: {color}");
            }
            Console.WriteLine($"Total Colors: {colors.Count}");

            // Clear products
            Products.Clear();
        }
        #endregion

        #region All
        /// <summary>
        /// Use All() to see if all items in a collection meet a specified condition
        /// </summary>
        public void All() {
            string search = " ";
            bool value;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                          select prod)
                          .All(prod => prod.Name.Contains(search));

            }
            else
            {
                // Method Syntax
                value = Products.All(prod => prod.Name.Contains(search));
            }

            // Build string of Distinct Colors

            ResultText = $"Do all Name Properties contain a {search} ? {value}";

            // Clear products
            Products.Clear();
        }
        #endregion

        #region Any
        /// <summary>
        /// Use Any() to see if at least one item in a collection meets a specified condition
        /// </summary>
        public void Any()
        {
            string search = "z";
            bool value;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod)
                          .Any(prod => prod.Name.Contains(search));

            }
            else
            {
                // Method Syntax
                value = Products.Any(prod => prod.Name.Contains(search));
            }

            // Build string of Distinct Colors

            ResultText = $"Do all Name Properties contain a {search} ? {value}";

            // Clear products
            Products.Clear();
        }
        #endregion

        #region LinqContains
        /// <summary>
        /// Use the LINQ Contains operator to see if a collection contains a specific value
        /// </summary>
        public void LinqContains()
        {
            bool value;
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from num in numbers
                         select num).Contains(3);

            }
            else
            {
                // Method Syntax
                value = numbers.Contains(3);
            }

            // Build string of Distinct Colors

            ResultText = $"Is the number in the collection? {value}";

            // Clear products
            Products.Clear();
        }
        #endregion

        #region LINQContainsUsingComparer
        /// <summary>
        /// Use the LINQ Contains operator to see if a collection contains a specific object using an EqualityComparer class to perform the comparison
        /// </summary>
        public void LINQContainsUsingComparer()
        {
            int search = 744;
            bool value = true;
            ProductIdComparer pc = new ProductIdComparer();
            Product prodToFind = new Product { ProductID = search };

            if (UseQuerySyntax)
            {
                value = (from prod in Products
                         select prod)
                          .Contains(prodToFind, pc);

            }
            else
            {
                // Method Syntax
                value = Products.Contains(prodToFind, pc);

            }

            ResultText = $"Product ID: {search} is in Products Collection = {value}";

            // Clear List
            Products.Clear();
        }
        #endregion

        #region SequenceEqualIntegers
        /// <summary>
        /// SequenceEqual() compares two different collections to see if they are equal
        /// When using simple data types such as int, string, a direct comparison between values is performed
        /// </summary>
        public void SequenceEqualIntegers()
        {
            bool value;
            // Create a list of numbers
            List<int> list1 = new List<int> { 5, 2, 3, 4, 5 };
            // Create a list of numbers
            List<int> list2 = new List<int> { 1, 2, 3, 4, 5 };

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from num in list1
                         select num)
                          .SequenceEqual(list2);
            }
            else
            {
                // Method Syntax
                value = list1.SequenceEqual(list2);
            }

            if (value)
            {
                ResultText = "Lists are Equal";
            }
            else
            {
                ResultText = "Lists are NOT Equal";
            }

            // Clear List
            Products.Clear();
        }
        #endregion

        #region SequenceEqualProducts
        /// <summary>
        /// When using a collection of objects, SequenceEqual() performs a comparison to see if the two object references point to the same object
        /// </summary>
        public void SequenceEqualProducts()
        {
            bool value;
            // Create a list of products
            List<Product> list1 = new List<Product> {
        new Product {ProductID= 1, Name = "Product 1"},
        new Product {ProductID= 2, Name = "Product 2"},
      };
            // Create a list of products
            List<Product> list2 = new List<Product> {
        new Product {ProductID= 1, Name = "Product 1"},
        new Product {ProductID= 2, Name = "Product 2"},
      };

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in list1
                         select prod)
                         .SequenceEqual(list2);
            }
            else
            {
                // Method Syntax
                value = list1.SequenceEqual(list2);
            }

            if (value)
            {
                ResultText = "Lists are Equal";
            }
            else
            {
                ResultText = "Lists are NOT Equal";
            }

            // Clear List
            Products.Clear();
        }
        #endregion

        #region SequenceEqualUsingComparer
        /// <summary>
        /// Use an EqualityComparer class to determine if the objects are the same based on the values in properties
        /// </summary>
        public void SequenceEqualUsingComparer()
        {
            bool value;
            ProductComparer pc = new ProductComparer();
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            // Remove an element from 'list1' to make the collections different
            //list1.RemoveAt(0);

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in list1
                         select prod)
                         .SequenceEqual(list2, pc);
            }
            else
            {
                // Method Syntax
                value = list1.SequenceEqual(list2, pc);
            }

            if (value)
            {
                ResultText = "Lists are Equal";
            }
            else
            {
                ResultText = "Lists are NOT Equal";
            }

            // Clear List
            Products.Clear();
        }
        #endregion

        #region ExceptIntegers
        /// <summary>
        /// Except() finds all values in one list that are not in the other list
        /// </summary>
        public void ExceptIntegers()
        {
            List<int> exceptions;
            // Create a list of numbers
            List<int> list1 = new List<int> { 1, 2, 3, 4 };
            // Create a list of numbers
            List<int> list2 = new List<int> { 3, 4, 5 };

            if (UseQuerySyntax)
            {
                // Query Syntax
                exceptions = (from num in list1
                              select num)
                              .Except(list2).ToList();
            }
            else
            {
                // Method Syntax
                exceptions = list1.Except(list2).ToList();
            }

            ResultText = string.Empty;
            foreach (var item in exceptions)
            {
                ResultText += "Number: " + item + Environment.NewLine;
            }

            // Clear List
            Products.Clear();
        }
        #endregion

        #region Except
        /// <summary>
        /// Except() finds all products in one list that are not in the other list using a comparer class
        /// </summary>
        public void Except()
        {
            ProductComparer pc = new ProductComparer();
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            // Remove all products with color = "Black" from 'list2'
            // to give us a difference in the two lists
            list2.RemoveAll(prod => prod.Color == "Black");

            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in list1
                            select prod)
                            .Except(list2, pc).ToList();
            }
            else
            {
                // Method Syntax
                Products = list1.Except(list2, pc).ToList();
            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region Intersect
        /// <summary>
        /// Intersect() finds all products that are in common between two collections using a comparer class
        /// </summary>
        public void Intersect()
        {
            ProductComparer pc = new ProductComparer();
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            // Remove 'black' products from 'list1'
            list1.RemoveAll(prod => prod.Color == "Black");
            // Remove 'red' products from 'list2'
            list2.RemoveAll(prod => prod.Color == "Red");

            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in list1
                            select prod)
                            .Intersect(list2, pc).ToList();
            }
            else
            {
                // Method Syntax
                Products = list1.Intersect(list2, pc).ToList();
            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region Union
        /// <summary>
        /// Union() combines two lists together, but skips duplicates by using a comparer class
        /// This is like the UNION SQL operator
        /// </summary>
        public void Union()
        {
            ProductComparer pc = new ProductComparer();
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in list1
                            select prod)
                            .Union(list2, pc)
                            .OrderBy(prod => prod.Name).ToList();
            }
            else
            {
                // Method Syntax
                Products = list1.Union(list2, pc)
                                .OrderBy(prod => prod.Name).ToList();
            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region LINQConcat
        /// <summary>
        /// The LINQ Concat() combines two lists together and does NOT check for duplicates
        /// This is like the UNION ALL SQL operator
        /// </summary>
        public void LINQConcat()
        {
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            if (UseQuerySyntax)
            {
                // Query Syntax
                Products = (from prod in list1
                            select prod)
                            .Concat(list2)
                            .OrderBy(prod => prod.Name).ToList();
            }
            else
            {
                // Method Syntax
                Products = list1.Concat(list2)
                                .OrderBy(prod => prod.Name).ToList();
            }

            ResultText = $"Total Products: {Products.Count}";
        }
        #endregion

        #region InnerJoin
        /// <summary>
        /// Join a Sales Order Detail collection with Products into anonymous class
        /// NOTE: This is an equijoin or an inner join
        /// </summary>
        public void InnerJoin()
        {
            StringBuilder sb = new StringBuilder(2048);
            int count = 0;

            if (UseQuerySyntax)
            {
                // Query syntax
                var query = (from prod in Products
                             join sale in Sales
                             on prod.ProductID equals sale.ProductID
                             select new
                             {
                                 prod.ProductID,
                                 prod.Name,
                                 prod.Color,
                                 prod.StandardCost,
                                 prod.ListPrice,
                                 prod.Size,
                                 sale.SalesOrderID,
                                 sale.OrderQty,
                                 sale.UnitPrice,
                                 sale.LineTotal
                             });

                foreach (var item in query)
                {
                    count++;
                    sb.AppendLine($"Sales Order: {item.SalesOrderID}");
                    sb.AppendLine($"  Product ID: {item.ProductID}");
                    sb.AppendLine($"  Product Name: {item.Name}");
                    sb.AppendLine($"  Size: {item.Size}");
                    sb.AppendLine($"  Order Qty: {item.OrderQty}");
                    sb.AppendLine($"  Total: {item.LineTotal:c}");
                }
            }
            else
            {
                // Method syntax
                var query = Products.Join(Sales, prod => prod.ProductID,
                  sale => sale.ProductID,
                  (prod, sale) => new
                  {
                      prod.ProductID,
                      prod.Name,
                      prod.Color,
                      prod.StandardCost,
                      prod.ListPrice,
                      prod.Size,
                      sale.SalesOrderID,
                      sale.OrderQty,
                      sale.UnitPrice,
                      sale.LineTotal
                  });

                foreach (var item in query)
                {
                    count++;
                    sb.AppendLine($"Sales Order: {item.SalesOrderID}");
                    sb.AppendLine($"  Product ID: {item.ProductID}");
                    sb.AppendLine($"  Product Name: {item.Name}");
                    sb.AppendLine($"  Size: {item.Size}");
                    sb.AppendLine($"  Order Qty: {item.OrderQty}");
                    sb.AppendLine($"  Total: {item.LineTotal:c}");
                }
            }

            ResultText = sb.ToString() + Environment.NewLine + "Total Sales: " + count.ToString();
        }
        #endregion

        #region InnerJoinTwoFields
        /// <summary>
        /// Join a Sales Order Detail collection with Products using two fields
        /// </summary>
        public void InnerJoinTwoFields()
        {
            short qty = 6;
            int count = 0;

            StringBuilder sb = new StringBuilder(2048);

            if (UseQuerySyntax)
            {
                // Query syntax
                var query = (from prod in Products
                             join sale in Sales on
                               new { prod.ProductID, Qty = qty }
                                 equals
                               new { sale.ProductID, Qty = sale.OrderQty }
                             select new
                             {
                                 prod.ProductID,
                                 prod.Name,
                                 prod.Color,
                                 prod.StandardCost,
                                 prod.ListPrice,
                                 prod.Size,
                                 sale.SalesOrderID,
                                 sale.OrderQty,
                                 sale.UnitPrice,
                                 sale.LineTotal
                             });

                foreach (var item in query)
                {
                    count++;
                    sb.AppendLine($"Sales Order: {item.SalesOrderID}");
                    sb.AppendLine($"  Product ID: {item.ProductID}");
                    sb.AppendLine($"  Product Name: {item.Name}");
                    sb.AppendLine($"  Size: {item.Size}");
                    sb.AppendLine($"  Order Qty: {item.OrderQty}");
                    sb.AppendLine($"  Total: {item.LineTotal:c}");
                }
            }
            else
            {
                // Method syntax
                var query = Products.Join(Sales,
                              prod => new { prod.ProductID, Qty = qty },
                              sale => new { sale.ProductID, Qty = sale.OrderQty },
                              (prod, sale) => new
                              {
                                  prod.ProductID,
                                  prod.Name,
                                  prod.Color,
                                  prod.StandardCost,
                                  prod.ListPrice,
                                  prod.Size,
                                  sale.SalesOrderID,
                                  sale.OrderQty,
                                  sale.UnitPrice,
                                  sale.LineTotal
                              });

                foreach (var item in query)
                {
                    count++;
                    sb.AppendLine($"Sales Order: {item.SalesOrderID}");
                    sb.AppendLine($"  Product ID: {item.ProductID}");
                    sb.AppendLine($"  Product Name: {item.Name}");
                    sb.AppendLine($"  Size: {item.Size}");
                    sb.AppendLine($"  Order Qty: {item.OrderQty}");
                    sb.AppendLine($"  Total: {item.LineTotal:c}");
                }
            }

            ResultText = sb.ToString() + Environment.NewLine + "Total Sales: " + count.ToString();
        }
        #endregion

        #region GroupJoin
        /// <summary>
        /// Use GroupJoin to create a new object with a Sales collection for each Product
        /// This is like a combination of an inner join and left outer join
        /// The 'into' keyword allows you to put the sales into a 'sales' variable 
        /// that can be used to retrieve all sales for a specific product
        /// </summary>
        public void GroupJoin()
        {
            StringBuilder sb = new StringBuilder(2048);
            IEnumerable<ProductSales> grouped;

            if (UseQuerySyntax)
            {
                // Query syntax is simply a 'join...into'
                grouped = (from prod in Products
                           join sale in Sales
                           on prod.ProductID equals sale.ProductID
                           into sales
                           select new ProductSales
                           {
                               Product = prod,
                               Sales = sales
                           });
            }
            else
            {
                // Method syntax uses 'GroupJoin()'
                grouped =
                    Products.GroupJoin(Sales,
                                       prod => prod.ProductID,
                                       sale => sale.ProductID,
                                       (prod, sales) => new ProductSales
                                       {
                                           Product = prod,
                                           Sales = sales.ToList()
                                       });
            }

            // Loop through each product
            foreach (var ps in grouped)
            {
                sb.AppendLine($"Product: {ps.Product}");

                // Loop through the sales for this product
                if (ps.Sales.Count() > 0)
                {
                    sb.AppendLine("   ** Sales **");
                    foreach (var sale in ps.Sales)
                    {
                        sb.Append($"     SalesOrderID: {sale.SalesOrderID}");
                        sb.Append($"     Qty: {sale.OrderQty}");
                        sb.AppendLine($"     Total: {sale.LineTotal}");
                    }
                }
                else
                {
                    sb.AppendLine("   ** NO Sales for Product **");
                }
                sb.AppendLine("");
            }

            ResultText = sb.ToString();
        }
        #endregion

        #region LeftOuterJoin
        /// <summary>
        /// Perform a left join between Products and Sales using DefaultIfEmpty() and SelectMany()
        /// </summary>
        public void LeftOuterJoin()
        {
            StringBuilder sb = new StringBuilder(2048);
            int count = 0;

            if (UseQuerySyntax)
            {
                // Query syntax
                var query = (from prod in Products
                             join sale in Sales
                             on prod.ProductID equals sale.ProductID
                               into sales
                             from sale in sales.DefaultIfEmpty()
                             select new
                             {
                                 prod.ProductID,
                                 prod.Name,
                                 prod.Color,
                                 prod.StandardCost,
                                 prod.ListPrice,
                                 prod.Size,
                                 sale?.SalesOrderID,
                                 sale?.OrderQty,
                                 sale?.UnitPrice,
                                 sale?.LineTotal
                             }).OrderBy(ps => ps.Name);

                foreach (var item in query)
                {
                    count++;
                    sb.AppendLine($"Product Name: {item.Name} ({item.ProductID})");
                    sb.AppendLine($"  Order ID: {item.SalesOrderID}");
                    sb.AppendLine($"  Size: {item.Size}");
                    sb.AppendLine($"  Order Qty: {item.OrderQty}");
                    sb.AppendLine($"  Total: {item.LineTotal:c}");
                }
            }
            else
            {
                // Method syntax
                var query = Products.SelectMany(
                              sale =>
                              Sales.Where(s => sale.ProductID == s.ProductID).DefaultIfEmpty(),
                              (prod, sale) => new
                              {
                                  prod.ProductID,
                                  prod.Name,
                                  prod.Color,
                                  prod.StandardCost,
                                  prod.ListPrice,
                                  prod.Size,
                                  sale?.SalesOrderID,
                                  sale?.OrderQty,
                                  sale?.UnitPrice,
                                  sale?.LineTotal
                              }).OrderBy(ps => ps.Name);

                foreach (var item in query)
                {
                    count++;
                    sb.AppendLine($"Product Name: {item.Name} ({item.ProductID})");
                    sb.AppendLine($"  Order ID: {item.SalesOrderID}");
                    sb.AppendLine($"  Size: {item.Size}");
                    sb.AppendLine($"  Order Qty: {item.OrderQty}");
                    sb.AppendLine($"  Total: {item.LineTotal:c}");
                }
            }

            ResultText = sb.ToString() + Environment.NewLine + "Total Sales: " + count.ToString();
        }
        #endregion

        #region GroupBy
        /// <summary>
        /// Group products by Size property
        /// orderby is optional
        /// </summary>
        public void GroupBy()
        {
            StringBuilder sb = new StringBuilder(2048);
            IEnumerable<IGrouping<string, Product>> sizeGroup;

            if (UseQuerySyntax)
            {
                // Query syntax
                sizeGroup = (from prod in Products
                             orderby prod.Size
                             group prod by prod.Size);
            }
            else
            {
                // Method syntax
                sizeGroup = Products.OrderBy(prod => prod.Size)
                                    .GroupBy(prod => prod.Size);
            }

            // Loop through each size
            foreach (var group in sizeGroup)
            {
                // The value in the 'Key' property is 
                // whatever data you grouped upon
                sb.AppendLine($"Size: {group.Key}  Count: {group.Count()}");

                // Loop through the products in each size
                foreach (var prod in group)
                {
                    sb.Append($"  ProductID: {prod.ProductID}");
                    sb.Append($"  Name: {prod.Name}");
                    sb.AppendLine($"  Color: {prod.Color}");
                }
            }

            ResultText = sb.ToString();
        }
        #endregion

        #region GroupByIntoSelect
        /// <summary>
        /// Group products by Size property using 'into' and 'select'
        /// orderby is optional
        /// </summary>
        public void GroupByIntoSelect()
        {
            StringBuilder sb = new StringBuilder(2048);
            IEnumerable<IGrouping<string, Product>> sizeGroup;

            if (UseQuerySyntax)
            {
                // Query syntax
                sizeGroup = (from prod in Products
                             orderby prod.Size
                             group prod by prod.Size into sizes
                             select sizes);
            }
            else
            {
                // Method syntax
                sizeGroup = Products.OrderBy(prod => prod.Size)
                                    .GroupBy(prod => prod.Size);
            }

            // Loop through each size
            foreach (var group in sizeGroup)
            {
                // The value in the 'Key' property is 
                // whatever data you grouped upon
                sb.AppendLine($"Size: {group.Key}  Count: {group.Count()}");

                // Loop through the products in each size
                foreach (var prod in group)
                {
                    sb.Append($"  ProductID: {prod.ProductID}");
                    sb.Append($"  Name: {prod.Name}");
                    sb.AppendLine($"  Color: {prod.Color}");
                }
            }

            ResultText = sb.ToString();
        }
        #endregion

        #region GroupByOrderByKey
        /// <summary>
        /// Group products by Size property and sort by Size using the Key property
        /// </summary>
        public void GroupByOrderByKey()
        {
            StringBuilder sb = new StringBuilder(2048);
            IEnumerable<IGrouping<string, Product>> sizeGroup;

            if (UseQuerySyntax)
            {
                // Query syntax
                sizeGroup = (from prod in Products
                             group prod by prod.Size into sizes
                             orderby sizes.Key
                             select sizes);
            }
            else
            {
                // Method syntax
                sizeGroup = Products.GroupBy(prod => prod.Size)
                                    .OrderBy(sizes => sizes.Key)
                                    .Select(sizes => sizes);
            }

            // Loop through each size
            foreach (var group in sizeGroup)
            {
                // The value in the 'Key' property is 
                // whatever data you grouped upon
                sb.AppendLine($"Size: {group.Key}  Count: {group.Count()}");

                // Loop through the products in each size
                foreach (var prod in group)
                {
                    sb.Append($"  ProductID: {prod.ProductID}");
                    sb.Append($"  Name: {prod.Name}");
                    sb.AppendLine($"  Color: {prod.Color}");
                }
            }

            ResultText = sb.ToString();
        }
        #endregion

        #region GroupByWhere
        /// <summary>
        /// Group products by Size property and the group has more than 2 members
        /// This simulates a HAVING clause in SQL
        /// </summary>
        public void GroupByWhere()
        {
            StringBuilder sb = new StringBuilder(2048);
            IEnumerable<IGrouping<string, Product>> sizeGroup;

            if (UseQuerySyntax)
            {
                // Query syntax
                sizeGroup = (from prod in Products
                             group prod by prod.Size into sizes
                             where sizes.Count() > 2
                             select sizes);
            }
            else
            {
                // Method syntax
                sizeGroup = Products.GroupBy(prod => prod.Size)
                                    .Where(sizes => sizes.Count() > 2)
                                    .Select(sizes => sizes);
            }

            // Loop through each size
            foreach (var group in sizeGroup)
            {
                // The value in the 'Key' property is 
                // whatever data you grouped upon
                sb.AppendLine($"Size: {group.Key}  Count: {group.Count()}");

                // Loop through the products in each size
                foreach (var prod in group)
                {
                    sb.Append($"  ProductID: {prod.ProductID}");
                    sb.Append($"  Name: {prod.Name}");
                    sb.AppendLine($"  Color: {prod.Color}");
                }
            }

            ResultText = sb.ToString();
        }
        #endregion

        #region GroupedSubquery
        /// <summary>
        /// Group Sales by SalesOrderID, add Products into new Sales Order object using a subquery
        /// </summary>
        public void GroupedSubquery()
        {
            StringBuilder sb = new StringBuilder(2048);
            IEnumerable<SaleProducts> salesGroup;

            // Get all products for a sales order id
            if (UseQuerySyntax)
            {
                // Query syntax
                salesGroup = (from sale in Sales
                              group sale by sale.SalesOrderID into sales
                              select new SaleProducts
                              {
                                  SalesOrderID = sales.Key,
                                  Products = (from prod in Products
                                              join sale in Sales on prod.ProductID equals sale.ProductID
                                              where sale.SalesOrderID == sales.Key
                                              select prod).ToList()
                              });
            }
            else
            {
                // Method syntax
                salesGroup =
                  Sales.GroupBy(sale => sale.SalesOrderID)
                        .Select(sales => new SaleProducts
                        {
                            SalesOrderID = sales.Key,
                            Products = Products.Join(sales,
                                                  prod => prod.ProductID,
                                                  sale => sale.ProductID,
                                                  (prod, sale) => prod).ToList()
                        });
            }

            // Loop through each sales order
            foreach (var sale in salesGroup)
            {
                sb.AppendLine($"Sales ID: {sale.SalesOrderID}");

                if (sale.Products.Count > 0)
                {
                    // Loop through the products in each sale
                    foreach (var prod in sale.Products)
                    {
                        sb.Append($"  ProductID: {prod.ProductID}");
                        sb.Append($"  Name: {prod.Name}");
                        sb.AppendLine($"  Color: {prod.Color}");
                    }
                }
                else
                {
                    sb.AppendLine("   Product ID not found for this sale.");
                }
            }

            ResultText = sb.ToString();
        }
        #endregion

        #region DistinctUsingGroupByFirstOrDefault
        /// <summary>
        /// The Distinct() operator can be simulated using the GroupBy() and FirstOrDefault() operators
        /// In this sample you put distinct product colors into another collection using LINQ
        /// </summary>
        public void DistinctUsingGroupByFirstOrDefault()
        {
            List<string> colors;

            if (UseQuerySyntax)
            {
                // Query Syntax
                colors = (from prod in Products
                          group prod by prod.Color into groupedColors
                          select groupedColors.FirstOrDefault().Color).ToList();
            }
            else
            {
                // Method Syntax
                colors = Products.GroupBy(p => p.Color)
                                 .Select(groupedColors =>
                                         groupedColors.FirstOrDefault().Color).ToList();
            }

            // Build string of Distinct Colors
            foreach (var color in colors)
            {
                Console.WriteLine($"Color: {color}");
            }
            Console.WriteLine($"Total Colors: {colors.Count}");

            // Clear products
            Products.Clear();
        }
        #endregion


        #region Count
        /// <summary>
        /// Gets a total number of products in a collection
        /// </summary>
        public void Count()
        {
            int value;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod).Count();
            }
            else
            {
                // Method Syntax
                value = Products.Count();
            }

            ResultText = $"Total Products = {value}";
        }
        #endregion

        #region CountFiltered
        /// <summary>
        /// You can apply a where clause, or a predicate in Count()
        /// </summary>
        public void CountFiltered()
        {
            string search = "Red";
            int value;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod)
                        .Count(prod => prod.Color == search);

                //value = (from prod in Products
                //         where prod.Color == search
                //         select prod)
                //        .Count();
            }
            else
            {
                // Method Syntax
                value = Products.Count(prod => prod.Color == search);

                // Alternate Syntax
                //value = Products.Where(prod => prod.Color == search).Count();
            }

            ResultText = $"Total Products with a color of 'Red' = {value}";
        }
        #endregion

        #region Minimum
        /// <summary>
        /// Get the minimum value in a collection
        /// </summary>
        public void Minimum()
        {
            decimal? value;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod.ListPrice).Min();

                // Alternate Syntax
                //value = (from prod in Products
                //         select prod)
                //        .Min(prod => prod.ListPrice);
            }
            else
            {
                // Method Syntax
                value = Products.Min(prod => prod.ListPrice);
            }

            if (value.HasValue)
            {
                ResultText = $"Minimum List Price = {value.Value:c}";
            }
            else
            {
                ResultText = "No List Prices Exist.";
            }
        }
        #endregion

        #region Maximum
        /// <summary>
        /// Get the maximum value in a collection
        /// </summary>
        public void Maximum()
        {
            decimal? value;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod.ListPrice).Max();

                // Alternate Syntax
                //value = (from prod in Products
                //         select prod)
                //        .Max(prod => prod.ListPrice);
            }
            else
            {
                // Method Syntax
                value = Products.Max(prod => prod.ListPrice);
            }

            if (value.HasValue)
            {
                ResultText = $"Maximum List Price = {value.Value:c}";
            }
            else
            {
                ResultText = "No List Prices Exist.";
            }
        }
        #endregion

        #region Average
        /// <summary>
        /// Get the average value in a collection
        /// </summary>
        public void Average()
        {
            decimal? value;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod.ListPrice).Average();

                // Alternate Syntax
                //value = (from prod in Products
                //         select prod)
                //        .Average(prod => prod.ListPrice);
            }
            else
            {
                // Method Syntax
                value = Products.Average(prod => prod.ListPrice);
            }

            if (value.HasValue)
            {
                ResultText = $"Average List Price = {value.Value:c}";
            }
            else
            {
                ResultText = "No List Prices Exist.";
            }
        }
        #endregion

        #region Sum
        /// <summary>
        /// Get a total value from a numeric property
        /// </summary>
        public void Sum()
        {
            decimal? value;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod.ListPrice).Sum();

                // Alternate Syntax
                //value = (from prod in Products
                //         select prod)
                //        .Sum(prod => prod.ListPrice);
            }
            else
            {
                // Method Syntax
                value = Products.Sum(prod => prod.ListPrice);
            }

            if (value.HasValue)
            {
                ResultText = $"Total of all List Prices = {value.Value:c}";
            }
            else
            {
                ResultText = "No List Prices Exist.";
            }
        }
        #endregion

        #region AggregateSum
        /// <summary>
        /// Simulate Sum() using the Aggregate method
        /// </summary>
        public void AggregateSum()
        {
            decimal? value = 0;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from prod in Products
                         select prod)
                         .Aggregate(0M, (sum, prod) =>
                                         sum += prod.ListPrice);
            }
            else
            {
                // Method Syntax
                value = Products.Aggregate(0M,
                  (sum, prod) => sum += prod.ListPrice);
            }

            if (value.HasValue)
            {
                ResultText = $"Total of all List Prices = {value.Value:c}";
            }
            else
            {
                ResultText = "No List Prices Exist.";
            }
        }
        #endregion

        #region AggregateCustom
        /// <summary>
        /// Simulate Sum() using the Aggregate method
        /// </summary>
        public void AggregateCustom()
        {
            decimal? value = 0;

            if (UseQuerySyntax)
            {
                // Query Syntax
                value = (from sale in Sales
                         select sale)
                         .Aggregate(0M,
                           (sum, sale) =>
                           sum += (sale.OrderQty * sale.UnitPrice));
            }
            else
            {
                // Method Syntax
                value = Sales.Aggregate(0M,
                  (sum, sale) => sum += (sale.OrderQty * sale.UnitPrice));
            }

            if (value.HasValue)
            {
                ResultText = $"Total of all List Prices = {value.Value:c}";
            }
            else
            {
                ResultText = "No List Prices Exist.";
            }
        }
        #endregion

        #region AggregateUsingGrouping
        /// <summary>
        /// Group products by Size property and calculate min/max/average prices
        /// </summary>
        public void AggregateUsingGrouping()
        {
            StringBuilder sb = new StringBuilder(2048);

            if (UseQuerySyntax)
            {
                // Query syntax
                var stats = (from prod in Products
                             group prod by prod.Size into sizeGroup
                             where sizeGroup.Count() > 0
                             select new
                             {
                                 Size = sizeGroup.Key,
                                 TotalProducts = sizeGroup.Count(),
                                 Max = sizeGroup.Max(s => s.ListPrice),
                                 Min = sizeGroup.Min(s => s.ListPrice),
                                 Average = sizeGroup.Average(s => s.ListPrice)
                             }
                             into result
                             orderby result.Size
                             select result);

                // Loop through each product statistic
                foreach (var stat in stats)
                {
                    sb.AppendLine($"Size: {stat.Size}  Count: {stat.TotalProducts}");
                    sb.AppendLine($"  Min: {stat.Min:c}");
                    sb.AppendLine($"  Max: {stat.Max:c}");
                    sb.AppendLine($"  Average: {stat.Average:c}");
                }
            }
            else
            {
                // Method syntax
                var stats = Products.GroupBy(sale => sale.Size)
                                    .Where(sizeGroup => sizeGroup.Count() > 0)
                                    .Select(sizeGroup => new
                                    {
                                        Size = sizeGroup.Key,
                                        TotalProducts = sizeGroup.Count(),
                                        Max = sizeGroup.Max(s => s.ListPrice),
                                        Min = sizeGroup.Min(s => s.ListPrice),
                                        Average = sizeGroup.Average(s => s.ListPrice)
                                    })
                                    .OrderBy(result => result.Size)
                                    .Select(result => result);

                // Loop through each product statistic
                foreach (var stat in stats)
                {
                    sb.AppendLine($"Size: {stat.Size}  Count: {stat.TotalProducts}");
                    sb.AppendLine($"  Min: {stat.Min:c}");
                    sb.AppendLine($"  Max: {stat.Max:c}");
                    sb.AppendLine($"  Average: {stat.Average:c}");
                }
            }

            ResultText = sb.ToString();
        }
        #endregion

        #region AggregateUsingGroupingMoreEfficient
        /// <summary>
        /// Group products by Size property and calculate min/max/average prices.
        /// Using an accumulator class is more efficient because we don't loop
        /// through once each for Min, Max, Average as in the previous sample.
        /// </summary>
        public void AggregateUsingGroupingMoreEfficient()
        {
            StringBuilder sb = new StringBuilder(2048);

            // Method syntax only
            var stats =
              Products.GroupBy(sale => sale.Size)
                      .Where(sizeGroup => sizeGroup.Count() > 0)
                      .Select(sizeGroup =>
                      {
                          var results = sizeGroup.Aggregate(new ProductStats(),
                                    (acc, prod) => acc.Accumulate(prod),
                                    acc => acc.ComputeAverage());

                          return new
                          {
                              Size = sizeGroup.Key,
                              results.TotalProducts,
                              results.Min,
                              results.Max,
                              results.Average
                          };
                      })
                      .OrderBy(result => result.Size)
                      .Select(result => result);

            // Loop through each product statistic
            foreach (var stat in stats)
            {
                sb.AppendLine($"Size: {stat.Size}  Count: {stat.TotalProducts}");
                sb.AppendLine($"  Min: {stat.Min:c}");
                sb.AppendLine($"  Max: {stat.Max:c}");
                sb.AppendLine($"  Average: {stat.Average:c}");
            }

            ResultText = sb.ToString();
        }
        #endregion

    }
}
