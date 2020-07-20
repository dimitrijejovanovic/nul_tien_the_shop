﻿using System;
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

            var dataProvider = new InMemoryDataSeeder(context);
            dataProvider.AddInitialData();

            IShopService shopService = new ShopService(context, logger);

            #endregion

            shopService.OrderAndSellArticle(1, 20, 10);

            Article article = shopService.GetById(1);
            shopService.DisplayArticle(article);

            Article newArticle = shopService.GetById(12);
            shopService.DisplayArticle(newArticle);

            Console.ReadKey();
        }
    }
}