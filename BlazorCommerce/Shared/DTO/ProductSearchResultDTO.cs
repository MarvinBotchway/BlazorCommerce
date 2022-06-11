using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCommerce.Shared.DTO
{
    public class ProductSearchResultDTO
    {
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
