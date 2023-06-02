namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Net.WebSockets;
    using System.Text;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCreatorDto[]),new XmlRootAttribute("Creators"));

            using StringReader sr = new StringReader(xmlString);

            ImportCreatorDto[] importedCreatorDtos = (ImportCreatorDto[])xmlSerializer.Deserialize(sr);

            var creators = new List<Creator>();
            foreach (var creatorDto in importedCreatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName 
                };
                foreach (var bordgameDto in creatorDto.BoardGames)
                {
                    if (!IsValid(bordgameDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    Boardgame boardgame = new Boardgame()
                    {
                        Name = bordgameDto.Name,
                        Rating = bordgameDto.Rating,
                        YearPublished = bordgameDto.YearPublished,
                        CategoryType = (CategoryType)bordgameDto.CategoryType,
                        Mechanics = bordgameDto.Mechanics,
                    };
                    creator.Boardgames.Add(boardgame);
                }
                creators.Add(creator);
                output.AppendLine(string.Format(SuccessfullyImportedCreator,creator.FirstName,creator.LastName,creator.Boardgames.Count));
            }
            context.Creators.AddRange(creators);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            ImportSellerDto[] importedSellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            var sellers = new List<Seller>();

            foreach (var sellerDto in importedSellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                Seller seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website
                };
                foreach (var BoardgameId in sellerDto.Boardgames.Distinct())
                {
                    if (!context.Boardgames.Any(b=>b.Id==BoardgameId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    var boardgame = context.Boardgames.First(b => b.Id == BoardgameId);
                    seller.BoardgamesSellers.Add(new BoardgameSeller() {BoardgameId = boardgame.Id });
                }
                sellers.Add(seller);
                output.AppendLine(string.Format(SuccessfullyImportedSeller,seller.Name,seller.BoardgamesSellers.Count));
            }
            context.AddRange(sellers);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
