using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using System.Net;
using Web_Shop.Application.DTOs;
using Web_Shop.Application.Mappings;
using Web_Shop.Application.Services.Interfaces;
using Web_Shop.Persistence.UOW.Interfaces;
using WWSI_Shop.Persistence.MySQL.Model;
using static Sieve.Extensions.MethodInfoExtended;

namespace Web_Shop.Application.Services
{
    public class ProductService : BaseService<Product>, IProductService

    {
        public ProductService(ILogger<Product> logger, ISieveProcessor sieveProcessor,
            IOptions<SieveOptions> sieveOptions,
            IUnitOfWork unitOfWork) : base(logger, sieveProcessor, sieveOptions, unitOfWork)
        {

        }

        public async Task<(bool IsSuccess, Product? entity, HttpStatusCode StatusCode, string ErrorMessage)> CreateNewProductAsync(AddUpdateProductDTO dto)
        {
            try
            {
                // if sku of product exist ( this must be unique)
                if (await _unitOfWork.ProductRepository.IsProductSkuExistAsync(dto.Sku))
                {
                    return (false, default(Product), HttpStatusCode.BadRequest, "this product sku: " + dto.Sku + " exist.");
                }
                var newEntity = dto.MapProduct();
                var result = await AddAndSaveAsync(newEntity);
                return (true, result.entity, HttpStatusCode.OK, string.Empty);
            }
            catch (Exception ex)
            {
                return LogError(ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Product? entity, HttpStatusCode StatusCode, string ErrorMessage)> UpdateExistingProductAsync(AddUpdateProductDTO dto, ulong id)
        {
            try
            {
                var existingEntityResult = await WithoutTracking().GetByIdAsync(id);
                // if not succes get by id
                if (!existingEntityResult.IsSuccess)
                {
                    return existingEntityResult;
                }
                // if sku of product exist ( this must be unique)
                var repository = _unitOfWork.Repository<Product>().Entities.AsNoTracking();
                var same_sku_count = await _unitOfWork.ProductRepository.GetProductSkuCountAsync(repository, dto.Sku);
                if (same_sku_count > 1)
                {
                        return (false, default(Product), HttpStatusCode.BadRequest, "this product sku: " + dto.Sku + " exist.");
                }
                var domainEntity = dto.MapProduct();

                domainEntity.IdProduct = id;

                return await UpdateAndSaveAsync(domainEntity, id);


            }
            catch (Exception ex)
            {
                return LogError(ex.Message);
            }
        }
    }
}
