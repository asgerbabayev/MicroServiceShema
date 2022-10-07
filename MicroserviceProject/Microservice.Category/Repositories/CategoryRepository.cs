using Microservice.Application.Concrete.Repositories.Base;
using Microservice.Infrastructure.Persistance.Data;

namespace Microservice.Category.Repositories
{
    public class CategoryRepository : GenericRepositoryBase<Domain.Entities.Category, AppDbContext>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
