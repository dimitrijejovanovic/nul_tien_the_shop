using System;
using TheShop.Common;
using TheShop.Models.Entities;

namespace TheShop.Services
{
    public sealed class ShopService
    {
        private DatabaseContext _context;
        private ILogger _logger;

        public ShopService(DatabaseContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public Article OrderArticle(int idArticle, int maxExpectedPrice)
        {
            var article = _context.Articles.GetById(idArticle);
            if (article != null && article.IsOrderable(maxExpectedPrice))
            {
                return article;
            }
            else
            {
                _logger.Error("Could not order article with id=" + idArticle +
                    ", with price less than " + maxExpectedPrice);
                return null;
            }
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

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error("Could not save article with id=" + article.ID);
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
                return _context.Articles.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
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
