using MediatR;
using PolicyService.Api.Commands.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyService.Api.Commands
{
    public class CreatePolicyCommand : IRequest<CreatePolicyResult>
    {
        public string OfferNumber { get; set; }
        public PersonDto PolicyHolder {  get; set; }    
        public AddressDto PolicyHolderAddress { get; set; }
    }
}
