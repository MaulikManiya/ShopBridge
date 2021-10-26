using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge.API.Controllers;
using ShopBridge.API.Infrastructure.Errors;
using ShopBridge.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Test.ControllersTests
{
    public class ItemtestController
    {
        [TestMethod]
        public async Task ReturnBadRequesForGet()
        {
            // Arrange
            var mockItemRepository = ItemsMockRepository.GetItemRepository();
            var controller = new ItemsController(mockItemRepository.Object);

            //Act
            var result = await controller.Get();
            BadRequestObjectResult badRequestResult = result as BadRequestObjectResult;
            var errorResult = badRequestResult.Value as GeneralErrorResultModel;

            //Assert 
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual(ErrorCodes.GetAllItemError, errorResult.ErrorCode);
        }

        [TestMethod]
        public async Task ReturnValidRequesForGet()
        {
            // Arrange
            var mockItemRepository = ItemsMockRepository.GetItemRepository();
            var controller = new ItemsController(mockItemRepository.Object);

            //Act
            var result = await controller.Get();
            BadRequestObjectResult badRequestResult = result as BadRequestObjectResult;
            var errorResult = badRequestResult.Value as GeneralErrorResultModel;

            //Assert 
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual(ErrorCodes.GetAllItemError, errorResult.ErrorCode);
        }
    }
}
