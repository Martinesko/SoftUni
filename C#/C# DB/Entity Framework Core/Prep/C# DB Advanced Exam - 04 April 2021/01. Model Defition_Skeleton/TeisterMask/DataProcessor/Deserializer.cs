// ReSharper disable InconsistentNaming

namespace TeisterMask.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models;
    using System.Text;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));
           
            var ProjectDtos = (ImportProjectDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var Projects = new List<Project>();

            foreach (var projectDto in ProjectDtos)
            {
                if (!IsValid(projectDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime ProjectOpenDate;
                bool isOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ProjectOpenDate);
                
                if (!isOpenDateValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime? projectDueDate = null;
                if (!String.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    DateTime dueDateCheck;
                    bool isDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateCheck);
                    if (!isDueDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    projectDueDate = dueDateCheck;
                }
                Project project = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = ProjectOpenDate,
                    DueDate = projectDueDate
                };
                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime taskOpenDate;
                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);
                    if (!isTaskOpenDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime taskDueDate;
                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);
                    if (!isTaskDueDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (taskOpenDate < ProjectOpenDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (projectDueDate.HasValue && taskDueDate >= projectDueDate.Value)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    Task task = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType
                    };
                    project.Tasks.Add(task);
                }
                Projects.Add(project);
                output.AppendLine(string.Format(SuccessfullyImportedProject,project.Name,project.Tasks.Count));
            }
            context.Projects.AddRange(Projects);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var output = new StringBuilder();
            var ImportedEmployeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var employees = new List<Employee>();

            foreach (var employeeDto in ImportedEmployeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                };
                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    if (context.Tasks.FirstOrDefault(t=>t.Id==taskId) == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    employee.EmployeesTasks.Add(new EmployeeTask()
                    {
                        TaskId = taskId,
                    });
                }
                employees.Add(employee);
                output.AppendLine(string.Format(SuccessfullyImportedEmployee,employee.Username,employee.EmployeesTasks.Count));
            }
            context.AddRange(employees);
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