using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace core.api.commerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<SubProduct> SubProducts { get; set; }
    }
}
