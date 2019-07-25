using AutoMapper;
using Linktrix.API.Domain.Models;
using Linktrix.API.Resources;

namespace Linktrix.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Customer, CustomerResource>();
            CreateMap<Transaction, TransactionResource>();
        }
    }
}
