using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


// test
namespace ChocoDemo.DataProvider.Models
{
    class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string ProductCode { get; set; }

        public string ProductDesription { get; set; }

        public override string ToString()
        {
            return ProductCode + " : " + ProductDesription;
        }
    }
}
