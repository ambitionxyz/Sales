﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicySearchService.Api.Queries.Dtos
{
    public class PolicyDto
    {
        public string PolicyNumber { get; set; }
        public DateTimeOffset PolicyStartDate { get; set; }
        public DateTimeOffset PolicyEndDate { get; set; }
        public string ProductCode { get; set; } 
        public string PolicyHolder { get; set; }
        public decimal PremiumAmount { get; set; }
    }
}
