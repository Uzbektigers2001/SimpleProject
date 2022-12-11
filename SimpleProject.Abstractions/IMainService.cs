using SimpleProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProject.Interfaces
{
    public interface IMainService
    {
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> DeleteById(long Id);
        Task<Product> GetById(long Id);
        Task<List<Product>> GetAll();

    }
}
