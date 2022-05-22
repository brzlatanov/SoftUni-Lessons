using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Services.DTO.Position;
using FastFood.Services.Interfaces;

namespace FastFood.Services
{
    public class PositionService : IPositionService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public PositionService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public ICollection<EmployeeRegisterPositionsAvailable> GetPositionsAvailable()
            => this.dbContext.Positions.ProjectTo<EmployeeRegisterPositionsAvailable>(this.mapper.ConfigurationProvider).ToList();
    }
}