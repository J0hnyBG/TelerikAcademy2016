namespace _10_ADO.Net.Data
{
    using System.Collections.Generic;

    using Abstract;
    using CommandProviders;
    using ConnectionProviders;
    using Models;

    public class SqlDbEngine : AbstractDbEngine
    {
        public SqlDbEngine(string connectionString)
            : base(connectionString,
                   new SqlCommandProvider(),
                   new SqlConnectionProvider())
        {
        }

        /// <summary>
        ///     Returns the number of rows in a SQL Server table.
        /// </summary>
        /// <param name="tableName">The name of the table.</param>
        /// <returns>The number of rows.</returns>
        public int GetNumberOfRowsFor(string tableName)
        {
            using (this.Connection)
            {
                var command = this.GetCommand($"SELECT COUNT(*) FROM {tableName}");

                var numberOfCategories = (int)command.ExecuteScalar();

                return numberOfCategories;
            }
        }

        /// <summary>
        ///     Returns a string representation of category names and descriptions in the Categories table.
        /// </summary>
        /// <returns>A string for category names and descriptions.</returns>
        public IList<Category> GetCategoryNamesAndDescriptions()
        {
            using (this.Connection)
            {
                var command = this.GetCommand("SELECT CategoryName, Description FROM Categories");
                var reader = command.ExecuteReader();

                var categories = this.ParseDataReader<Category>(reader);
                return categories;
            }
        }

        /// <summary>
        ///     Gets a list of product names grouped by category name.
        /// </summary>
        /// <returns>A string representing the categories and their respective products.</returns>
        public IList<CategoryWithProducts> GetProductsGroupedByCategory()
        {
            using (this.Connection)
            {
                var query = @"SELECT DISTINCT
                    CategoryName
                    , SUBSTRING((SELECT
                            ', ' + p.ProductName AS[text()]
                        FROM dbo.Products p
                        WHERE c.CategoryID = p.CategoryID
                        ORDER BY c.CategoryID
                        FOR XML PATH(''))
                    , 2, 1000)[Products]
                    FROM Categories c";

                var command = this.GetCommand(query);

                var reader = command.ExecuteReader();
                var categoriesWithProducts = this.ParseDataReader<CategoryWithProducts>(reader);
                return categoriesWithProducts;
            }
        }

        /// <summary>
        /// Inserts a new product in the Products table.
        /// </summary>
        public void InsertProduct(string productName,
                                  int supplierId,
                                  int categoryId,
                                  string quantityPerUnit,
                                  decimal unitPrice,
                                  int unitsInStock)
        {
            using (this.Connection)
            {
                var query =
                    @"INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                    VALUES(@ProductName, @SupplierID, @CategoryID, @Quantity, @UnitPrice, @UnitsInStock, DEFAULT, DEFAULT, DEFAULT); ";
                var parameters = new Dictionary<string, object>
                                 {
                                     { "@ProductName", productName },
                                     { "@SupplierID", supplierId },
                                     { "@CategoryID", categoryId },
                                     { "@Quantity", quantityPerUnit },
                                     { "@UnitPrice", unitPrice },
                                     { "@UnitsInStock", unitsInStock }
                                 };
                var command = this.GetCommand(query, parameters);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Gets all images for categories
        /// </summary>
        public IList<PictureContainer> GetAllCategoryImages()
        {
            using (this.Connection)
            {
                var command = this.GetCommand("SELECT Picture FROM Categories;");

                var reader = command.ExecuteReader();
                var pictures = this.ParseDataReader<PictureContainer>(reader);
                return pictures;
            }
        }

        /// <summary>
        /// Searches Products table and outputs each product with a partial match in ProductName.
        /// </summary>
        public IList<Product> SearchProductsByName(string pattern)
        {
            using (this.Connection)
            {
                IDictionary<string, object> parameters = new Dictionary<string, object>
                                                         {
                                                             { "@Pattern", "%" + pattern + "%" }
                                                         };

                var command = this.GetCommand(@"SELECT ProductName FROM Products WHERE ProductName LIKE @Pattern;",
                                              parameters);

                var reader = command.ExecuteReader();
                var products = this.ParseDataReader<Product>(reader);
                return products;
            }
        }
    }
}
