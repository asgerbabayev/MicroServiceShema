using Microservice.Domain.Common;
using System.ComponentModel;

namespace Microservice.Domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public double? UnitInStock { get; set; }
        public int CategoryId { get; set; }
    }
}
