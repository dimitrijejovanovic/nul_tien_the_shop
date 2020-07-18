using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Models.Entities
{
    public sealed class Article: Entity
    {
        public string Name { get; private set; }

        public int ArticlePrice { get; private set; }

        public bool IsSold { get; private set; }

        public DateTime SoldDate { get; private set; }

        public int BuyerUserId { get; private set; }

        public Supplier Supplier { get; private set; }

        public Article() { }

        public Article(int price)
        {
            ArticlePrice = price;
        }

        public void Sell(int buyerId)
        {
            SoldDate = DateTime.Now;
            IsSold = true;
            BuyerUserId = buyerId;
        }

        public void SetSuplier(Supplier supplier)
        {
            Supplier = supplier;
            if (!supplier.Articles.Any(a => a == this))
                supplier.Articles.Add(this);

            if (Name == null)
                Name = "Article from " + supplier.Name;
        }

        public bool IsOrderable(int? maxPrice = null)
        {
            return !IsSold && maxPrice.HasValue ? maxPrice < ArticlePrice : true;
        }
    }
}
}
