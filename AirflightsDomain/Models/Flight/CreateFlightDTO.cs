using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.Flight
{
    public class CreateFlightDTO
    {
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }

        public int FromCityId { get; set; }

        public int ToCityId { get; set; }
    }

    public class CreateFlightValidator : AbstractValidator<CreateFlightDTO>
    {
        public CreateFlightValidator()
        {
            RuleFor(m => m.FromCityId).NotEmpty();
            RuleFor(m => m.ToCityId).NotEmpty();
            RuleFor(m => m.ArrivalTime)
                .NotEmpty()
                .GreaterThan(m => m.DepartureTime)
                .WithMessage("Arrival date must after departure date");
            RuleFor(m => m.DepartureTime).NotEmpty();
        }
    }
}
