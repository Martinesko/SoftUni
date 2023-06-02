namespace Footballers.DataProcessor
{
    using AutoMapper;
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var mapper = CreateMapper();
           StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCoachesDto[]), new XmlRootAttribute("Coaches"));
            using StringReader stringReader = new StringReader(xmlString);

            var ImportedCoacheDtos = (ImportCoachesDto[])xmlSerializer.Deserialize(stringReader);

            List<Coach> coaches = new List<Coach>();
            foreach (var coachDto in ImportedCoacheDtos)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (string.IsNullOrEmpty(coachDto.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Coach coach = new Coach()
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality
                };

                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime footballerContractStartDate;
                    bool isFootballerContractStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate,"dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out footballerContractStartDate);
                    if (!isFootballerContractStartDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }DateTime footballerContractEndDate;
                    bool isFootballerContractEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate,"dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out footballerContractEndDate);
                    if (!isFootballerContractEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (footballerContractStartDate>=footballerContractEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Footballer footballer = new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = footballerContractStartDate,
                        ContractEndDate = footballerContractEndDate,
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                        PositionType = (PositionType)footballerDto.PositionType
                    };
                    coach.Footballers.Add(footballer);
                }
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
                coaches.Add(coach);
            }
            context.AddRange(coaches);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var importedTeamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);
            
            var teams = new List<Team>();
            foreach (var TeamDto in importedTeamDtos)
            {
                if (!IsValid(TeamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (string.IsNullOrEmpty(TeamDto.Nationality))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var team = new Team() 
                {
                    Name =  TeamDto.Name,
                    Trophies = TeamDto.Trophies
                    ,Nationality = TeamDto.Nationality
                };
                if (team.Trophies == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                foreach (var footballerId in TeamDto.Footballers.Distinct())
                {
                    Footballer fb = context.Footballers.Find(footballerId);
                    if (fb == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    team.TeamsFootballers.Add(new TeamFootballer() { Footballer = fb });
                }
                teams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }
            context.Teams.AddRange(teams);
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
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FootballersProfile>();
            }));
        }
        
    }
}
