using TheShop.Common;
using TheShop.Models.Entities;

namespace TheShop.Utils
{
    public sealed class InMemoryDatabaseDatabaseContext : DatabaseContext
    {
        public InMemoryDatabaseDatabaseContext()
        {
            Articles = new InMemorySet<Article>();
            Suppliers = new InMemorySet<Supplier>();
        }

        public override void Save()
        {
            // no need for specific implementation because data is already in those collections/sets
            // but it will be possible to implement it for some other type of persistence 
        }
    }
}
