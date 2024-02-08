using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace Web_Shop.Application.Mappings.PropertiesMappings
{
    public class ApplicationSieveProcessor : SieveProcessor
    {
        public ApplicationSieveProcessor(
            IOptions<SieveOptions> options,
            ISieveCustomSortMethods customSortMethods,
            ISieveCustomFilterMethods customFilterMethods)
            : base(options, customSortMethods, customFilterMethods)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            // create mapper instance of SievePropertyMapper
            var map = mapper.ApplyConfiguration<SieveConfigurationForCustomer>().
                ApplyConfiguration<SieveConfigurationForProduct>();

            return map;
        }
    }
}
