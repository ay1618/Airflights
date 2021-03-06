﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.Flight
{
    public class UpdateFlightDelayDTO
    {
        public int Id { get; set; }
        public long Delay { get; set; }
    }

    public class UpdateFlightDelayValidator : AbstractValidator<UpdateFlightDelayDTO>
    {
        public UpdateFlightDelayValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
            RuleFor(m => m.Delay).GreaterThan(0);
        }
    }
}
