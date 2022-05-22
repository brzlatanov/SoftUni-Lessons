using System;

namespace CarDealer.DTO.Input
{
    public class CustomerInputDto
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}