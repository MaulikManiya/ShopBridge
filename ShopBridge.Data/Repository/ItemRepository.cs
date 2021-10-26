using Microsoft.EntityFrameworkCore;
using ShopBridge.Data.Data;
using ShopBridge.Data.IRepository;
using ShopBridge.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Data.Repository
{
    public class ItemRepository : IItemRepository
    {
        readonly ShopBridgeDbContext _shopBridgeDbContext;
        public ItemRepository(ShopBridgeDbContext context)
        {
            _shopBridgeDbContext = context;
        }

        public async Task<List<Item>> GetAll()
        {
            return await _shopBridgeDbContext.Items.ToListAsync();
        }

        public async Task<Item> GetById(long id)
        {
            return await _shopBridgeDbContext.Items.FindAsync(id);
        }

        public async Task Add(Item entity)
        {
            _shopBridgeDbContext.Items.Add(entity);
            await _shopBridgeDbContext.SaveChangesAsync();
        }

        public async Task Update(Item entity)
        {
            _shopBridgeDbContext.Update(entity);
            await _shopBridgeDbContext.SaveChangesAsync();
        }

        public async Task Delete(Item entity)
        {
            _shopBridgeDbContext.Items.Remove(entity);
            await _shopBridgeDbContext.SaveChangesAsync();
        }
    }
}
