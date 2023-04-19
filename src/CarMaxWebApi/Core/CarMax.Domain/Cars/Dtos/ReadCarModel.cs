using CarMax.Domain.Enums;
using System.Collections.Generic;

namespace CarMax.Domain.Cars.Dtos
{
    public class ReadCarModel
    {
        public IDictionary<string, string>? ImageGallery { get; set; }

        public string? Location { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public int? Year { get; set; }

        public string? Description { get; set; }

        public decimal? RentCost { get; set; }

        public CostType? CostType { get; set; }
    }
}
