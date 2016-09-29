using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Seggu.Daos.Interfaces;
using Seggu.Domain;
using Seggu.Dtos;

namespace Seggu.Services.Tests
{
    [TestClass]
    public class AccessoryServiceTest
    {
        [TestMethod]
        public void GetByVehicleIdShouldReturnOrderedAccessories()
        {
            var accessoryDaoMock = new Mock<IAccessoryDao>();
            accessoryDaoMock
                .Setup(x => x.GetByVehicleId(It.IsAny<long>()))
                .Returns(new List<Accessory>
                {
                    new Accessory { Name="Yesterday", ExpirationDate = DateTime.Today.AddDays(-1)},
                    new Accessory { Name="Today", ExpirationDate=DateTime.Today },
                    new Accessory { Name="Tomorrow", ExpirationDate=DateTime.Today.AddDays(1) },
                });
            IAccessoryDao accessoryDao = accessoryDaoMock.Object;
            var service = new AccessoryService(accessoryDao);
            var result = service.GetByVehicleId(0).ToList();
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0].Name, "Tomorrow");
            Assert.AreEqual(result[1].Name, "Today");
            Assert.AreEqual(result[2].Name, "Yesterday");
        }

        [TestMethod]
        public void SaveShouldCallDaoSaveWhenIdIsDefaultInt()
        {
            var accessoryDaoMock = new Mock<IAccessoryDao>();
            accessoryDaoMock
                .Setup(x => x.Save(It.IsAny<Accessory>()))
                .Verifiable();
            IAccessoryDao accessoryDao = accessoryDaoMock.Object;
            var service = new AccessoryService(accessoryDao);
            service.Save(new AccessoryDto
            {
                Id = default(int)
            });
            accessoryDaoMock.Verify(x => x.Save(It.IsAny<Accessory>()), Times.Once);
        }

        [TestMethod]
        public void SaveShouldCallDaoUpdateWhenIdIsNotDefaultInt()
        {
            var accessoryDaoMock = new Mock<IAccessoryDao>();
            accessoryDaoMock
                .Setup(x => x.Update(It.IsAny<Accessory>()))
                .Verifiable();
            IAccessoryDao accessoryDao = accessoryDaoMock.Object;
            var service = new AccessoryService(accessoryDao);
            service.Save(new AccessoryDto
            {
                Id = 1000
            });
            accessoryDaoMock.Verify(x => x.Update(It.IsAny<Accessory>()), Times.Once);
        }
    }
}
