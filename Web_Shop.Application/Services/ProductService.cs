using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web_Shop.Application.DTOs;
using Web_Shop.Application.Services.Interfaces;
using Web_Shop.Persistence.UOW.Interfaces;
using WWSI_Shop.Persistence.MySQL.Model;
using Web_Shop.Application.Extensions;
using Web_Shop.Application.Helpers.PagedList;
using Web_Shop.Application.Mappings;

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
            catch(Exception ex)
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
                var domainEntity = dto.MapProduct();

                domainEntity.IdProduct = id;

                return await UpdateAndSaveAsync(domainEntity, id);


            }
            catch(Exception ex) 
            {
                return LogError(ex.Message);
            }
        }
    }
}
