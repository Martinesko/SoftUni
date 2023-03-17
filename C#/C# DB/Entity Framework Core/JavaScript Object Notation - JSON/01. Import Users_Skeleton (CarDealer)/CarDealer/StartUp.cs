using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            string stringJson = File.ReadAllText("../../../Datasets/sales.json");

            Console.WriteLine(GetCarsWithTheirListOfParts(context));
        }
        //Import
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var mapper = CreateMapper();

            var supplierDto = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);
            var suppliers = mapper.Map<Supplier[]>(supplierDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}."; ;
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var mapper = CreateMapper();

            var partDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            var parts = new HashSet<Part>();
            foreach (var partDto in partDtos)
            {
                if (!context.Suppliers.Any(s=>s.Id==partDto.SupplierId))
                {
                    continue;
                }
                var part = mapper.Map<Part>(partDto);
                parts.Add(part);
            }
            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var mapper = CreateMapper();

            var carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            var cars = mapper.Map<Car[]>(carDtos);

            context.AddRange(cars);
            context.SaveChanges();
            return $"Successfully imported {cars.Length}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var mapper = CreateMapper();

            var customersDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);
            var customers = mapper.Map<Customer[]>(customersDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var mapper = CreateMapper();

            var saleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);
            var sales = mapper.Map<Sale[]>(saleDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }));
        }

        //Export
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new {
                Name = c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                IsYoungDriver = c.IsYoungDriver,
                });

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars.Where(c => c.Make == "Toyota").OrderBy(c => c.Model).ThenByDescending(c => c.TravelledDistance).Select(c => new {Id = c.Id , Make = c.Make,Model = c.Model, TraveledDistance = c.TravelledDistance,}).AsNoTracking().ToArray();
            
            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(s => !s.IsImporter).Select(s => new { Id=s.Id , Name = s.Name,PartsCount = s.Parts.Count});

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars.Select(c => new { car = new {Make = c.Make, Model = c.Model , TravelledDistance = c.TravelledDistance}, parts= c.PartsCars.Select(p=>new {Name = p.Part.Name , Price = p.Part.Price.ToString("f2")}) }).ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented); 
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {

        }
    }
}   