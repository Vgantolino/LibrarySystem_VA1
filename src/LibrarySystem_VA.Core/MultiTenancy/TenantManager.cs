using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using LibrarySystem_VA.Authorization.Users;
using LibrarySystem_VA.Editions;

namespace LibrarySystem_VA.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
