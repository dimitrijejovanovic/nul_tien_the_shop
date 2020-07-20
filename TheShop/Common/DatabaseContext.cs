using TheShop.Models.Entities;

namespace TheShop.Common
{
    public abstract class DatabaseContext
    {
        public IDatabaseSet<SupplierOrganisation> Organisations;
        public IDatabaseSet<Supplier> Suppliers;
        public IDatabaseSet<Article> SoldArticles;

        public abstract void Save();
    }
}
