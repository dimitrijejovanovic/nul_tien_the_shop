using System;
using TheShop.Common;
using TheShop.Services;
using TheShop.Utils;

namespace TheShop
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region configuration

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
            shopService.DisplayArticle(newArticle);

            Console.ReadKey();
        }
    }
}