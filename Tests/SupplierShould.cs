using System;
using TheShop.Models.Entities;
using Xunit;

namespace Tests
{
    public class SupplierShould
    {
        [Fact]
        public void ArticleInInventoryTest()
        {
            var article = new Article
            {
                ID = 2
            };
            var supplier = new Supplier1();
            supplier.AddArticle(article);

            Assert.True(supplier.ArticleInInventory(article.ID));
        }

        [Fact]
        public void SoldArticleInInventoryTest()
        {
            var article = new Article
            {
                ID = 2
            };
            article.Sell(12);
            var supplier = new Supplier1();
            supplier.AddArticle(article);

            Assert.False(supplier.ArticleInInventory(article.ID));
        }

        [Fact]
        public void NoArticleInEmptyInventoryTest()
        {
            var supplier = new Supplier1();

            Assert.False(supplier.ArticleInInventory(23));
        }

        [Fact]
        public void NoArticleInInventoryTest()
        {
            var article = new Article
            {
                ID = 2
            };
            var supplier = new Supplier1();
            supplier.AddArticle(article);

            Assert.False(supplier.ArticleInInventory(23));
        }
        
        [Fact]
        public void GetArticleTest()
        {
            var article = new Article
            {
                ID = 2
            };
            var supplier = new Supplier1();
            supplier.AddArticle(article);

            var articleFromInventory = supplier.GetArticle(article.ID);

            Assert.Equal(articleFromInventory, article);
        }

        [Fact]
        public void GetArticalFromEmptyInventoryTest()
        {
            var supplier = new Supplier1();

            var articleFromInventory = supplier.GetArticle(23);

            Assert.Null(articleFromInventory);
        }

        [Fact]
        public void GetArticleWithNoExestingIdTest()
        {
            var article = new Article
            {
                ID = 2
            };
            var supplier = new Supplier1();
            supplier.AddArticle(article);

            var articleFromInventory = supplier.GetArticle(23);

            Assert.Null(articleFromInventory);
        }

        [Fact]
        public void SuccessfulAddArticleTest()
        {
            var article = new Article
            {
                ID = 2
            };
            var supplier = new Supplier1();

            supplier.AddArticle(article);

            Assert.NotNull(supplier.Articles.Find(a => a == article));
        }

        [Fact]
        public void SuccessfulAddArticleSupplierSetTest()
        {
            var article = new Article
            {
                ID = 2
            };
            var supplier = new Supplier1();

            supplier.AddArticle(article);

            Assert.Equal(supplier.Articles.Find(a => a == article).Supplier, supplier);
        }

        [Fact]
        public void AddNullArticleTest()
        {
            var supplier = new Supplier1();

            Action testCode = () => { supplier.AddArticle(null); };

            Assert.NotNull(Record.Exception(testCode));
        }

        [Fact]
        public void SuccessfulHasViableleArticle()
        {
            int price = 10;
            int idArticle = 2;
            var validArticle = new Article(price) { ID = idArticle };
            var supplier = new Supplier1("Supplier 1");
            supplier.AddArticle(validArticle);

            Assert.True(supplier.HasViableleArticle(idArticle, price + 1));
        }

        [Fact]
        public void HasViableleArticleWithIncorrectArticleId()
        {
            int price = 10;
            int idArticle = 2;
            var validArticle = new Article(price) { ID = idArticle };
            var supplier = new Supplier1("Supplier 1");
            supplier.AddArticle(validArticle);

            Assert.False(supplier.HasViableleArticle(idArticle + 1, price + 1));
        }

        [Fact]
        public void HasViableleArticleWithNoArticle()
        { 
            int price = 10;
            int idArticle = 2;
            var supplier = new Supplier1("Supplier 1");

            Assert.False(supplier.HasViableleArticle(idArticle, price + 1));
        }
    }
}
