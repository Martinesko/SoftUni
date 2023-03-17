using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
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

            Console.WriteLine(ImportSales(context,stringJson));
        }
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

    }
}