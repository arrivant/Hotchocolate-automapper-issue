using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HC_Automapper_Issue.DbContext;
using HC_Automapper_Issue.Domains.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace HC_Automapper_Issue.GraphQL
{
    [ExtendObjectType(RootQuery.Name)]
    public class AllQueries
    {
        private readonly IMapper _mapper;

        public AllQueries(IMapper mapper)
        {
            _mapper = mapper;
        }

        [UseDbContext(typeof(CustomerDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Address> GetAddresses([ScopedService] CustomerDbContext dbContext,
            IResolverContext resolverContext)
        {
            return dbContext.Addresses;
        }

        [UseDbContext(typeof(CustomerDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<AddressDto> GetAddressesDto([ScopedService] CustomerDbContext dbContext,
            IResolverContext resolverContext)
        {
            return dbContext.Addresses.ProjectTo<AddressDto>(_mapper.ConfigurationProvider);
        }

    }
}