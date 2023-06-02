namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Castle.Core.Internal;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.DataProcessor.ImportDto;


    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var mapper = CreateMapper();
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportDespatcherDto[]),new XmlRootAttribute("Despatchers"));

            using StringReader stringReader = new StringReader(xmlString);

            ImportDespatcherDto[] despatcherDtos = (ImportDespatcherDto[])xmlSerializer.Deserialize(stringReader);
            var despatchers = new List<Despatcher>();

            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (string.IsNullOrEmpty(despatcherDto.Position))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Despatcher despatcher = mapper.Map<Despatcher>(despatcherDto);

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Truck truck = mapper.Map<Truck>(truckDto);

                    despatcher.Trucks.Add(truck);
                }
                despatchers.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }
            context.Despatchers.AddRange(despatchers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var mapper = CreateMapper();
            var sb = new StringBuilder();

            var importedClientDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);
            var clients = new List<Client>();

            foreach (var clientDto in importedClientDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var client = mapper.Map<Client>(clientDto);
                
                if (clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var truck in clientDto.Trucks.Distinct())
                {
                    if (context.Trucks.Find(truck) == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    client.ClientsTrucks.Add(new ClientTruck { Truck = mapper.Map<Truck>(context.Trucks.Find(truck)) });
                }
                clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }
            context.Clients.AddRange(clients);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<TrucksProfile>(); }));
        }
    }
}