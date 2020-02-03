using EFCore.RepositoryPattern.Generics.Abstractions;
using EFCore.RepositoryPattern.Sample.Data.Entities.Enums;
using System;

namespace EFCore.RepositoryPattern.Sample.Data.Entities
{
    public sealed class Car : AbstractEntity<Guid>
    {
        public Guid DealerId { get; set; }

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string VinNumber { get; set; }
        public BodyType BodyType { get; set; }
        public FuelType FuelType { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
