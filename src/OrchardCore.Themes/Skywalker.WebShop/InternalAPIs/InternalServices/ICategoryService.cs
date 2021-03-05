using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Skywalker.WebShop.InternalAPIs.Domains;

namespace Skywalker.WebShop.InternalAPIs.InternalServices
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
    }
}
