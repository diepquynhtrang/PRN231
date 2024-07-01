﻿namespace Project_API.Models.DTO
{
    public class FoodDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public byte? Status { get; set; }
    }
}
