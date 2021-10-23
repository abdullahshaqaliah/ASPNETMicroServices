using Catalog.API.Entitites;
using MongoDB.Driver;
namespace Catalog.API.Data.Interface
{
    public  interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
