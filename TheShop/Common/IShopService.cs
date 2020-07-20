using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Models.Entities;

namespace TheShop.Common
{
    public interface IShopService
    {
        Article OrderArticle(int idArticle, int maxExpectedPrice);
        void SellArticle(Article article, int buyerId);
        void DisplayArticle(Article article);
        Article GetById(int id);
    }
}
