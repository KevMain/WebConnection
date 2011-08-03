using AutoMapper;
using CCE.WebConnection.BL.Models.Domain.Abstract;
using CCE.WebConnection.BL.Models.ViewModels;
using CCE.WebConnection.DAL;

namespace CCE.WebConnection.BL.EntityMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<ICustomerEntity, ICustomer>();
            Mapper.CreateMap<CustomerViewModel, ICustomer>();
        }
    }
}
