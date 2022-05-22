using System.Collections.Generic;
using CarDealer.Models;

namespace CarDealer.DTO.Input
{
    public class CarInputDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public int[] PartsId { get; set; }

    }
}