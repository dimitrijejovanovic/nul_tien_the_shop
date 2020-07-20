using System;
using TheShop.Models.Entities;
using Xunit;

namespace Tests
{
    public class SupplierOrganisationShould
    {
        [Fact]
        public void SuccessfulAddSupplierTest()
        {
            var supplier = new Supplier1("Supplier 1");
           
            var organisation = new SupplierOrganisation();

            organisation.AddSupplier(supplier);

            Assert.NotNull(organisation.Suppliers.Find(s => s == supplier));
        }

        public void SuccessfulAddSupplierSetOrganisationTest()
        {
            var supplier = new Supplier1("Supplier 1");

            var organisation = new SupplierOrganisation();

            organisation.AddSupplier(supplier);

            Assert.Equal(organisation, supplier.Organisation);
        }

        [Fact]
        public void AddNullSupplierTest()
        {
            var organisation = new SupplierOrganisation();

            Action testCode = () => { organisation.AddSupplier(null); };

            Assert.NotNull(Record.Exception(testCode));
        }

        [Fact]
        public void SuccessfulOrderArticle()
        {
            int price = 10;
            int idArticle = 2;
            var validArticle = new Article(price) { ID = idArticle};
            var supplier = new Supplier1("Supplier 1");
            supplier.AddArticle(validArticle);
            var organisation = new SupplierOrganisation();
            organisation.AddSupplier(supplier);

            var orderedArticle = organisation.OrderArticle(idArticle, price + 1);

            Assert.Equal(orderedArticle, validArticle);
        }

        [Fact]
        public void OrderArticleWithNoSuppliers()
        {
            int price = 10;
            int idArticle = 2;
            var organisation = new SupplierOrganisation();

            Action testCode = () => { organisation.OrderArticle(idArticle, price + 1); };

            Assert.NotNull(Record.Exception(testCode));
        }
    }
}
