namespace Theatre.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";



        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Deserializer), new XmlRootAttribute("Plays"));



            ImportPlayDto[] importPlayDtos = (ImportPlayDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Play> plays = new List<Play>();

            foreach (var playDto in importPlayDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var play = new Play()
                {
                    Title = playDto.Title,
                    Duration = TimeSpan.Parse(playDto.Duration),
                    Rating = playDto.Rating,
                    Genre = (Genre)Enum.Parse(typeof(Genre), playDto.Genre),
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter,
                };
                if (play.Duration.TotalHours<1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                plays.Add(play);
            }
            context.Plays.AddRange(plays);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            throw new NotImplementedException();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
