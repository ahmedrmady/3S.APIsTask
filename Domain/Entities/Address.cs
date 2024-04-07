﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        public int Id { get; set; }
        public int GovernateId { get; set; }
        public Governate Governate { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public int FlatNumber { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

    }
}
