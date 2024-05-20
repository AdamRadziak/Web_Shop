using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Shop.Application.CustomQueries;
using Web_Shop.Application.DTOs;
using Web_Shop.Application.Mappings.PropertiesMappings;
using Web_Shop.Application.Services;
using Web_Shop.Application.Services.Interfaces;
using Web_Shop.Persistence.Repositories.Interfaces;
using Web_Shop.Persistence.UOW;
using Web_Shop.Persistence.UOW.Interfaces;
using Web_Shop.Tests.Common.Sieve;
using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.UnitTests
{
    public class ProductServiceTest
    {
        private readonly Mock<ILogger<Product>> _loggerMock;

        private readonly Mock<ApplicationSieveProcessor> _processorMock;
        private readonly Mock<SieveOptionsAccessor> _optionsAccessorMock;

        public ProductServiceTest()
        {
            _loggerMock = new Mock<ILogger<Product>>();

            _optionsAccessorMock = new Mock<SieveOptionsAccessor>();

            _processorMock = new Mock<ApplicationSieveProcessor>(_optionsAccessorMock.Object,
                new Mock<SieveCustomSortMethods>().Object,
                new Mock<SieveCustomFilterMethods>().Object);
        }

        [Theory]
        [InlineData(false)]
        public async Task ProductService_CreateNewProductAsync_ReturnsTrue(bool SkuExists)
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(m => m.IsProductSkuExistAsync(It.IsAny<string>())).Returns((string email) => Task.FromResult(SkuExists));

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.ProductRepository).Returns(() => productRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m.Repository<Product>()).Returns(() => productRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(0));

            var productService = new ProductService(_loggerMock.Object, _processorMock.Object, _optionsAccessorMock.Object, unitOfWorkMock.Object);
            // generate random price
            Random rnd = new Random();
            var addUpdateproductDTO = new AddUpdateProductDTO()
            {
                Name = "TestName",
                Description = "TestDesc",
                Price = (decimal)rnd.NextDouble()*100,
                Sku = "TestSku"
            };

            var verifyResult = await productService.CreateNewProductAsync(addUpdateproductDTO);

            Assert.True(verifyResult.IsSuccess);
            Assert.Equal(System.Net.HttpStatusCode.OK, verifyResult.StatusCode);
        }

        [Theory]
        [InlineData(true)]
        public async Task ProductService_CreateNewProductAsync_ReturnsFalse(bool SkuExists)
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(m => m.IsProductSkuExistAsync(It.IsAny<string>())).Returns((string sku) => Task.FromResult(SkuExists));

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.ProductRepository).Returns(() => productRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m.Repository<Product>()).Returns(() => productRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(() => Task.FromResult(0));

            var productService = new ProductService(_loggerMock.Object, _processorMock.Object, _optionsAccessorMock.Object, unitOfWorkMock.Object);
            // generate random price
            Random rnd = new Random();
            var addUpdateproductDTO = new AddUpdateProductDTO()
            {
                Name = "TestName",
                Description = "TestDesc",
                Price = (decimal)rnd.NextDouble() * 100,
                Sku = "TestSku"
            };

            var verifyResult = await productService.CreateNewProductAsync(addUpdateproductDTO);

            Assert.False(verifyResult.IsSuccess);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, verifyResult.StatusCode);
        }





    }
}
