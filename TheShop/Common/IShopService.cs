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
        void OrderAndSellArticle(int idArticle, int maxExpectedPrice, int buyerId);
        void DisplayArticle(Article article);
        Article GetById(int id);
    }
}
