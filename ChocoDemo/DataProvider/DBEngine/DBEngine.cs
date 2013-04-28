using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ChocoDemo.DataProvider.Models;

namespace ChocoDemo.DataProvider.DBEngine
{
    class DBEngine
    {
        public const string PRODUCTS_TABLE = "products";

        public static async void insertProduct(Product product)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(PRODUCTS_TABLE);

            await conn.CreateTableAsync<Product>();

            await conn.InsertAsync(product);


        }

        public static async Task<List<Product>> getAllProducts()
        {
            List<Product> products = null;

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(PRODUCTS_TABLE);

            products = await conn.Table<Product>().Where(x => true).ToListAsync();



            return products;
        }

        public static async Task<List<Product>> filterProducts(string filter)
        {

            List<Product> products = null;

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(PRODUCTS_TABLE);

            products = await conn.Table<Product>().
                Where(x => x.ProductCode.
                    Contains(filter) ||
                    x.ProductDesription.Contains(filter)).ToListAsync();

            return products;
        }
    }
}