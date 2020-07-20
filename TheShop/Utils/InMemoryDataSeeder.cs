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
            Supplier supplier1 = new Supplier1("Supplier 1");
            var article1 = new Article(458);
            supplier1.AddArticle(article1);
            _context.Suppliers.Add(supplier1);

            Supplier supplier2 = new Supplier2("Supplier 2");
            var article2 = new Article(459);
            supplier2.AddArticle(article2);
            _context.Suppliers.Add(supplier2);

            var article3 = new Article(460);
            Supplier supplier3 = new Supplier3("Supplier 3");
            supplier3.AddArticle(article3);

            SupplierOrganisation organisation = new SupplierOrganisation() { ID = 1 };
            organisation.AddSupplier(supplier1);
            organisation.AddSupplier(supplier2);
            organisation.AddSupplier(supplier3);
            _context.Organisations.Add(organisation);

        }
    }
}
