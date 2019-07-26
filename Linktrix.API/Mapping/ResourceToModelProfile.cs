using AutoMapper;
using Linktrix.API.Domain.Models;
using Linktrix.API.Resources;

namespace Linktrix.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCustomerResource, Customer>();

            CreateMap<SaveTransactionResource, Transaction>();

            CreateMap<FindCustomerResource, Customer>();
        }
    }
}
