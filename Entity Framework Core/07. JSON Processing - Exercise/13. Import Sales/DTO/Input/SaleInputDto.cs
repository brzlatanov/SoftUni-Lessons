﻿using CarDealer.Models;

namespace CarDealer.DTO.Input
{
    public class SaleInputDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public decimal Discount { get; set; }

    }
}