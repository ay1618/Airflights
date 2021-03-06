﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public long Delay { get; set; }
        public int UserId { get; set; }
        public bool IsArchive { get; set; }

        public int FromCityId { get; set; }
        public City FromCity { get; set; }

        public int ToCityId { get; set; }
        public City ToCity { get; set; }
    }
}
