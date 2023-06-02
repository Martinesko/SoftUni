namespace Boardgames.DataProcessor
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.Text;
    using System.Text.Json.Nodes;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            StringBuilder output = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCreatorsDto[]), new XmlRootAttribute("Creators"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(output);

            ExportCreatorsDto[] exportCreators = context.Creators.Where(c => c.Boardgames.Any()).ToArray().Select(c => new ExportCreatorsDto() { CreatorName = $"{c.FirstName} {c.LastName}",
            BoardgamesCount = c.Boardgames.Count,
            Boardgames = c.Boardgames.Select(b => new ExportBoardgamesDto()
                {
                    BoardgameName = b.Name,
                    BoardgameYearPublished = b.YearPublished,
                }).OrderBy(b => b.BoardgameName).ToArray()
            }).OrderByDescending(c => c.Boardgames.Count()).ThenBy(c => c.CreatorName).ToArray();
            xmlSerializer.Serialize(sw,exportCreators, namespaces);
            return output.ToString().TrimEnd();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(b => b.Boardgame.YearPublished>=year && b.Boardgame.Rating<=rating)
                ).ToArray().Select(s=> new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers.Where(b => b.Boardgame.YearPublished>=year && b.Boardgame.Rating<=rating)
                    .ToArray()
                    .OrderByDescending(bs => bs.Boardgame.Rating)
                    .ThenBy(bs => bs.Boardgame.Name)
                    .Select(b=> new
                    {
                        Name = b.Boardgame.Name,
                        Rating = b.Boardgame.Rating,
                        Mechanics = b.Boardgame.Mechanics,
                        Category = b.Boardgame.CategoryType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();
            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}