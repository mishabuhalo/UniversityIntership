﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RestfulService.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isCapital { get; set; }
        public int Population { get; set; } 

        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
