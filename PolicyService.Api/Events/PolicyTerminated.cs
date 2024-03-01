using MediatR;
using PolicyService.Api.Commands.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyService.Api.Events
{
    public class PolicyTerminated : INotification
    {
        public string PolicyNumber { get; set; }
        public string ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public PersonDto PolicyHolder { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal AmountToReturn { get; set; }
    }
}
