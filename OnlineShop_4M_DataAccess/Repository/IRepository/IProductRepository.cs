using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop_4M_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop_4M_DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
        IEnumerable<SelectListItem> GetAllDropDownList(string obj);
    }
}
