using TheShop.Models.Entities;

namespace TheShop.Common
{
    public abstract class DatabaseContext
    {
        public IDatabaseSet<Article> Articles;
        public IDatabaseSet<Supplier> Suppliers;

        public abstract void Save();
    }
}
