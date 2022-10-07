using Microservice.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Domain.Entities
{
    public class Category:BaseAuditableEntity
    {
        public string CategoryName { get; set; } = null!;
    }
}
