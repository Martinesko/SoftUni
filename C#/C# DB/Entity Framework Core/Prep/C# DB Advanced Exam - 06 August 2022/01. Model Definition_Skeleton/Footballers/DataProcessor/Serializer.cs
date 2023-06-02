namespace Footballers.DataProcessor
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
            });
            var mapper = CreateMapper();
            StringBuilder output = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCoachDto[]),new XmlRootAttribute("Coaches"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(output);

            ExportCoachDto[] coachDtos = context
                .Coaches
                .Where(c => c.Footballers.Any())
                .ProjectTo<ExportCoachDto>(config)
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c=>c.Name)
                .ToArray();
            xmlSerializer.Serialize(sw, coachDtos,namespaces);
            return output.ToString().TrimEnd();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context
                 .Teams
                 .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate>=date))
                 .ToArray()
                 .Select(t => new
                 {
                     t.Name,
                     Footballers = t.TeamsFootballers
                     .Where(tf => tf.Footballer.ContractStartDate>=date)
                     .ToArray()
                     .OrderByDescending(f=>f.Footballer.ContractEndDate)
                     .ThenBy(f=>f.Footballer.Name)
                     .Select(f => new
                     {
                         FootballerName = f.Footballer.Name,
                         ContractStartDate = f.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                         ContractEndDate = f.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                         BestSkillType = f.Footballer.BestSkillType.ToString(),
                         PositionType = f.Footballer.PositionType.ToString(),
                     })
                     .ToArray()
                 })
                 .OrderByDescending(t => t.Footballers.Length)
                 .ThenBy(t => t.Name)
                 .Take(5)
                 .ToArray();
            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
            }));
        }
    }
}
