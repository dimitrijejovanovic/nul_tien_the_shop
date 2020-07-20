using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Models.Entities
{
    public class SupplierOrganisation : Entity
    {
        public List<Supplier> Suppliers { get; private set; }

        public SupplierOrganisation() {
            Suppliers = new List<Supplier>();
        }

        public void AddSupplier(Supplier supplier)
        {
            if (supplier == null)
            {
                throw new Exception("Can't add empty supplier");
            }

            Suppliers.Add(supplier);
            supplier.SetOrganisation(this);
        }

        public Article OrderArticle(int articleId, int maxArticlePrice)
        {
            Article article =
                Suppliers.FirstOrDefault(s => s.HasViableleArticle(articleId, maxArticlePrice))?.GetArticle(articleId);

            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            return article;

        }

    }
}
