using System;
using System.Linq;

namespace TheShop.Models.Entities
{
    public class Article: Entity
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
            SetPrice(price);
        }

        public void SetPrice(int price)
        {
            ArticlePrice = price >= 0 ? ArticlePrice = price : throw new Exception("Price can't be negative");
        }

        public void Sell(int buyerId)
        {
            SoldDate = DateTime.Now;
            IsSold = true;
            BuyerUserId = buyerId;
        }

        public void SetSuplier(Supplier supplier)
        {
            Supplier = supplier ?? throw new Exception("No supplier provided to article");

            if (!supplier.Articles.Any(a => a == this))
                supplier.Articles.Add(this);

            if (Name == null)
                Name = "Article from " + supplier.Name;
        }

        public bool IsOrderable(int? maxPrice = null)
        {
            return !IsSold && (maxPrice.HasValue ? maxPrice > ArticlePrice : true);
        }
    }
}

