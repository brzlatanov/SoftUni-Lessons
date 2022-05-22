using CarDealer.Models;

namespace CarDealer.DTO.Input
{
    public class PartCarInputDto
    {
        public int PartId { get; set; }
        public PartInputIdDto Part { get; set; }
        public int CarId { get; set; }
        public CarInputDto Car { get; set; }
    }
}