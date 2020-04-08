using Shop.Web.Data.Entities;
using System.Linq;

namespace Shop.Web.Data
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();
    }
}
