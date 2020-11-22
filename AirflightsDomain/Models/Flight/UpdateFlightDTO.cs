using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.Flight
{
    public class UpdateFlightDTO
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public long Delay { get; set; }
        //public bool IsArchive { get; set; }

        public int FromCityId { get; set; }

        public int ToCityId { get; set; }
    }

    public class UpdateFlightValidator : AbstractValidator<UpdateFlightDTO>
    {
        public UpdateFlightValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
            RuleFor(m => m.Delay).GreaterThan(0);
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
