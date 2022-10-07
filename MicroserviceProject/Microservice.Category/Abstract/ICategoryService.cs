using Microservice.Category.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Category.Abstract
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryWrite categoryWrite);
        Task<IEnumerable<CategoryRead>> GetAllAsync();
        Task<CategoryRead> GetAsync();
        Task RemoveAsync(int id);
    }
}
