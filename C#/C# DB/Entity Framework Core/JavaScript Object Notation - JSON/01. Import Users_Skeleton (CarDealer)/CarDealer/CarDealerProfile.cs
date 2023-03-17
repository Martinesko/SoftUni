using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<ImportPartDto, Part>();
            CreateMap<ImportCarDto, Car>()
              .ForMember(dest => dest.PartsCars, opt => opt.MapFrom(x => x.PartsId.Distinct().Select(p => new PartCar { PartId = p })));
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<ImportSaleDto, Sale>();
        }
    }
}
