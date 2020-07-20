using System;
using TheShop.Models.Entities;
using Xunit;

namespace Tests
{
    public class ArticleShould
    {
        [Fact]
        public void SellTest()
        {
            Article article = new Article(200);
            int buyerId = 1;

            article.Sell(buyerId);

            Assert.True(article.IsSold);
            Assert.True(article.BuyerUserId == buyerId);
        }

        [Fact]
        public void SetSupplierTest()
        {
            Article article = new Article(200);
            Supplier supplier = new Supplier1("Sup 1");

            article.SetSuplier(supplier);

            Assert.Equal(article.Supplier, supplier);
        }

        [Fact]
        public void SetSuppliersAddArticleTest()
        {
            Article article = new Article(200);
            Supplier supplier = new Supplier1("Sup 1");

            article.SetSuplier(supplier);

            Assert.True(article.Supplier.Articles.Exists(a => a == article));
        }

        [Fact]
        public void SetSupplierWithNoValueTest()
        {
            Article article = new Article(200);

            Action testCode = () => { article.SetSuplier(null); };
            var exception = Record.Exception(testCode);

            Assert.NotNull(exception);
        }

        [Fact]
        public void SuccesfulIsOrderableTest()
        {
            int articlePrice = 200;
            Article article = new Article(articlePrice);

            Assert.True(article.IsOrderable(articlePrice + 1));
        }

        [Fact]
        public void NoMaxPriceValueIsOrderableTest()
        {
            Article article = new Article(100);

            Assert.True(article.IsOrderable(null));
        }

        [Fact]
        public void GreaterPriceValueThanMaxIsOrderableTest()
        {
            int maxPrice = 200;
            Article article = new Article(maxPrice - 1);

            Assert.False(article.IsOrderable(maxPrice));
        }

        [Fact]
        public void NoMaxPriceNoArticlePriceIsOrderableTest()
        {
            Article article = new Article();

            Assert.True(article.IsOrderable(null));
        }

        [Fact]
        public void SoldArticleIsOrderableTest()
        {
            var articlePrice = 10;
            Article article = new Article(articlePrice);
            article.Sell(12);

            Assert.False(article.IsOrderable(articlePrice + 1));
        }


        [Fact]
        public void SetValidPriceTest()
        {
            Article article = new Article();
            int price = 10;

            article.SetPrice(price);

            Assert.Equal(article.ArticlePrice, price);
        }

        [Fact]
        public void SetNegativePriceValueTest()
        {
            Article article = new Article();
            int price = -10;

            Action testCode = () => { article.SetPrice(price); };
            var exception = Record.Exception(testCode);

            Assert.NotNull(exception);
        }
    }
}
