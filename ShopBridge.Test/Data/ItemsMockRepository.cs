using Moq;
using ShopBridge.Data.IRepository;
using ShopBridge.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Test.Data
{
    public class ItemsMockRepository
    {
        public static Mock<IItemRepository> GetItemRepository()
        {
            var mockItemRepository = new Mock<IItemRepository>();
            return mockItemRepository;
        }
    }
}
