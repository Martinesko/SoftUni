namespace TeisterMask
{
    using AutoMapper;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ImportDto;

    public class TeisterMaskProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public TeisterMaskProfile()
        {
            this.CreateMap<ImportProjectDto, Project>();
            this.CreateMap<ImportTaskDto, Task>();
        }
    }
}
