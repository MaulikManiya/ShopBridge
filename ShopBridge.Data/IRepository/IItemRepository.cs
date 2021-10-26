using ShopBridge.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Data.IRepository
{
    public interface IItemRepository
    {
        Task<Item> GetById(long id);
        Task<List<Item>> GetAll();
        Task Add(Item entity);
        Task Update(Item entity);
        Task Delete(Item entity);
    }
}
