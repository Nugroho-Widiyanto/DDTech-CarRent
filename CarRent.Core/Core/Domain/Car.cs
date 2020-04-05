using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Core.Core.Domain
{
    public class Car
    {
        public int Id { get; set; }

        [MaxLength(8)]
        public string Plate { get; set; }

        [MaxLength(64)]
        public string Make { get; set; }

        [MaxLength(64)]
        public string Model { get; set; }

        public byte Capacity { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Year { get; set; }
    }
}
