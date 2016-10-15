using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seggu.Domain;
using Seggu.Services.DtoMappers;

namespace Seggu.Services.Tests
{
    [TestClass]
    public class AccesoryDtoMapperTest
    {
        [TestMethod]
        public void GetDtoShouldMapAllProperties()
        {
            // TODO: Validar resto de los campos
            var accessory = new Accessory
            {
                AccessoryTypeId = 10001,
                Stamp = "TestOblea",
                Id = 10001,
                Name = "Test"
            };
            var dto = AccessoryDtoMapper.GetDto(accessory);
            Assert.AreEqual(dto.Name, "Test");
            Assert.AreEqual(dto.AccessoryTypeId, 10001);
            Assert.AreEqual(dto.Id, 10001);
            Assert.AreEqual(dto.Oblea, "TestOblea");
        }
    }
}
