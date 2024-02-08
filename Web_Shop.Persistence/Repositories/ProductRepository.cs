﻿using Microsoft.EntityFrameworkCore;
using Web_Shop.Persistence.Repositories;
using Web_Shop.Persistence.Repositories.Interfaces;
using WWSI_Shop.Persistence.MySQL.Context;
using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(WwsishopContext dbContext) : base(dbContext) { }



        public async Task<bool> IsProductSkuExistAsync(string sku)
        {
            return await Entities.AnyAsync(e => e.Sku == sku);
        }

    }
    }

