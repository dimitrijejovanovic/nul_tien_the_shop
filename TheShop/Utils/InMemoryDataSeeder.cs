using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Common;
using TheShop.Models.Entities;

namespace TheShop.Utils
{
    public sealed class InMemoryDataSeeder
    {
        private DatabaseContext _context;

        public InMemoryDataSeeder(DatabaseContext context)
        {
            _context = context;
        }

        public void AddInitialData()
        {
            var supplier1 = new Supplier("Supplier 1");
            var article1 = new Article(458);
            supplier1.AddArticle(article1);

            _context.Articles.Add(article1);
            _context.Suppliers.Add(supplier1);

            var supplier2 = new Supplier("Supplier 2");
            var article2 = new Article(459);
            supplier2.AddArticle(article2);
            _context.Articles.Add(article2);
            _context.Suppliers.Add(supplier2);

            var article3 = new Article(460);
            var supplier3 = new Supplier("Supplier 3");
            supplier3.AddArticle(article3);
            _context.Articles.Add(article3);
            _context.Suppliers.Add(supplier3);
        }
    }
}
