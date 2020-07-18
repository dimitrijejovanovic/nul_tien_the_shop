using System;

namespace TheShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region confoguration

            DatabaseContext context = new InMemoryDatabaseDatabaseContext();
            ILogger logger = new ConsoleLogger();

            var dataProvider = new InMemoryDataProvider(context);
            dataProvider.AddInitialData();

            var shopService = new ShopService(context, logger);

            #endregion
            
            var orderedArticle = shopService.OrderArticle(1, 500);
            shopService.DisplayArticle(orderedArticle);
            shopService.SellArticle(orderedArticle, 10);

            var article = shopService.GetById(1);
            shopService.DisplayArticle(article);

            var newArticle = shopService.GetById(12);
            Console.WriteLine("Found article with ID: " + article.ID);

            Console.ReadKey();
        }
    }
}