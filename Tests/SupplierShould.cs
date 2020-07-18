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
            var supplier = new Supplier();
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
            var supplier = new Supplier();
            supplier.AddArticle(article);

            Assert.False(supplier.ArticleInInventory(article.ID));
        }

        [Fact]
        public void NoArticleInEmptyInventoryTest()
        {
            var supplier = new Supplier();

            Assert.False(supplier.ArticleInInventory(23));
        }

        [Fact]
        public void NoArticleInInventoryTest()
        {
            var article = new Article
            {
                ID = 2
            };
            var supplier = new Supplier();
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
            var supplier = new Supplier();
            supplier.AddArticle(article);

            var articleFromInventory = supplier.GetArticle(article.ID);

            Assert.Equal(articleFromInventory, article);
        }

        [Fact]
        public void GetArticalFromEmptyInventoryTest()
        {
            var supplier = new Supplier();

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
            var supplier = new Supplier();
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
            var supplier = new Supplier();

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
            var supplier = new Supplier();

            supplier.AddArticle(article);

            Assert.Equal(supplier.Articles.Find(a => a == article).Supplier, supplier);
        }

        [Fact]
        public void AddNullArticleTest()
        {
            var supplier = new Supplier();

            Action testCode = () => { supplier.AddArticle(null); };

            Assert.NotNull(Record.Exception(testCode));
        }
    }
}
