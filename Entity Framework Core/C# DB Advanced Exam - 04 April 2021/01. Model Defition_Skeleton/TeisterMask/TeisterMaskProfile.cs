using TeisterMask.Data.Models;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask
{
    using AutoMapper;

    public class TeisterMaskProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TeisterMaskProfile()
        {
            CreateMap<ImportProjectDto, Project>();
            CreateMap<ImportTaskDto, Task>();
            CreateMap<ImportEmployeeDto, Employee>();
        }
    }

}
