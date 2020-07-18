using Moq;
using System;
using TheShop.Common;
using TheShop.Models.Entities;
using TheShop.Services;
using Xunit;

namespace Tests
{
    public class ShopServiceShould
    {
        [Fact]
        public void SuccessfulOrderingArticleTest()
        {
            int articlePrice = It.IsAny<int>();
            Mock<DatabaseContext> mockContext = new Mock<DatabaseContext>();
            Mock<IDatabaseSet<Article>> mockDbSet = new Mock<IDatabaseSet<Article>>();
            mockContext.Object.Articles = mockDbSet.Object;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockDbSet.Setup(mock => mock.GetById(It.IsAny<int>())).Returns(new Article(articlePrice));
            var shopService = new ShopService(mockContext.Object, mockLogger.Object);

            var article = shopService.OrderArticle(It.IsAny<int>(), articlePrice + 1);

            mockDbSet.Verify(mock => mock.GetById(It.IsAny<int>()), Times.Once);
            Assert.True(article != null);

        }

        [Fact]
        public void OrderingArticleWithoutArticleTest()
        {
            Mock<DatabaseContext> mockContext = new Mock<DatabaseContext>();
            Mock<IDatabaseSet<Article>> mockDbSet = new Mock<IDatabaseSet<Article>>();
            mockContext.Object.Articles = mockDbSet.Object;
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockDbSet.Setup(mock => mock.GetById(It.IsAny<int>())).Throws(new Exception());
            var shopService = new ShopService(mockContext.Object, mockLogger.Object);

            var article = shopService.OrderArticle(It.IsAny<int>(), It.IsAny<int>());

            mockDbSet.Verify(mock => mock.GetById(It.IsAny<int>()), Times.Once);
            Assert.True(article == null);
        }

        [Fact]
        public void SellingWithValidArticleTest()
        {
            Mock<DatabaseContext> mockContext = new Mock<DatabaseContext>();
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(m => m.Info(It.IsAny<string>()));
            var shopService = new ShopService(mockContext.Object, mockLogger.Object);

            shopService.SellArticle(new Article(), It.IsAny<int>());

            mockLogger.Verify(mock => mock.Info(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void SellingWithNoArticleTest()
        {
            Mock<DatabaseContext> mockContext = new Mock<DatabaseContext>();
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(m => m.Info(It.IsAny<string>()));
            mockLogger.Setup(m => m.Error(It.IsAny<string>()));
            var shopService = new ShopService(mockContext.Object, mockLogger.Object);

            shopService.SellArticle(null, It.IsAny<int>());

            mockLogger.Verify(mock => mock.Info(It.IsAny<string>()), Times.Never);
            mockLogger.Verify(mock => mock.Error(It.IsAny<string>()), Times.Once);
        }

    }
}
