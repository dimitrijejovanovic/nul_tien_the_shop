using System;
using TheShop.Common;
using TheShop.Models.Entities;

namespace TheShop.Services
{
    public sealed class ShopService : IShopService
    {
        private DatabaseContext _context;
        private ILogger _logger;

        public ShopService(DatabaseContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }


        public void OrderAndSellArticle(int idArticle, int maxExpectedPrice, int buyerId)
        {
            var article = OrderArticle(idArticle, maxExpectedPrice);
            SellArticle(article, buyerId);
        }

        public Article OrderArticle(int idArticle, int maxExpectedPrice)
        {
            try
            {
                var organisation = _context.Organisations.GetById(1) ?? throw new Exception("There is no Organisation");
                return organisation.OrderArticle(idArticle, maxExpectedPrice);

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            _logger.Error("Could not order article with id=" + idArticle +
                ", with price less than " + maxExpectedPrice);

            return null;
        }

        public void SellArticle(Article article, int buyerId)
        {
            if (!_validateArticle(article))
            {
                return;
            }

            try
            {
                _logger.Debug("Trying to sell article with id=" + article.ID);
                article.Sell(buyerId);
                _logger.Info("Article with id=" + article.ID + " is sold.");
                _context.SoldArticles.Add(article);

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error("Could not save article with id=" + article?.ID);
            }
        }

        public void DisplayArticle(Article article)
        {
            if (!_validateArticle(article))
            {
                return;
            }

            _logger.Info("Found article with ID: " + article.ID);
        }

        public Article GetById(int id)
        {
            try
            {
                return _context.SoldArticles.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.Error("Article not found: " + ex.Message);
                return null;
            }
        }

        private bool _validateArticle(Article article)
        {
            if (article == null)
            {
                _logger.Error("There is no article");
                return false;
            }
            return true;
        }
    }
}
