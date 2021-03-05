using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Skywalker.WebShop.InternalAPIs.Domains;

namespace Skywalker.WebShop.InternalAPIs.InternalServices
{
    public class CategoryService : ICategoryService
    {
        public Task<List<Category>> GetAllCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = "1",
                    Name = "Flight"
                },
                new Category()
                {
                    Id = "2",
                    Name = "Car"
                }
            };

            return Task.FromResult(categories);
        }
    }
}
