﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyService.Api.Commands.Dtos
{
    public class PersonDto
    {
        public string FirstName { get; set; }   

        public string LastName { get; set; }

        public string TaxId { get; set; }
    }
}
