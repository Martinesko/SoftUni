using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            string stringJson = File.ReadAllText("../../../Datasets/parts.json");

            Console.WriteLine(ImportParts(context,stringJson));
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

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }));
        }

    }
}