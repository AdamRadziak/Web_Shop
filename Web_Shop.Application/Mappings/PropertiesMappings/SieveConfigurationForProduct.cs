using Sieve.Services;
using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.Application.Mappings.PropertiesMappings
{
    public class SieveConfigurationForProduct : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            mapper.Property<Product>(p => p.Name).CanSort().CanFilter();

            mapper.Property<Product>(p => p.Description).CanSort().CanFilter();

            mapper.Property<Product>(p => p.Price).CanSort().CanFilter();

            mapper.Property<Product>(p => p.Sku).CanSort().CanFilter();

        }
    }
}
