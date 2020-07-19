using System;
using TheShop.Common;
using TheShop.Models.Entities;
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

            Article orderedArticle = shopService.OrderArticle(3, 500);
            shopService.DisplayArticle(orderedArticle);
            shopService.SellArticle(orderedArticle, 10);

            Article article = shopService.GetById(1);
            shopService.DisplayArticle(article);

            Article newArticle = shopService.GetById(12);
            shopService.DisplayArticle(newArticle);

            Console.ReadKey();
        }
    }
}