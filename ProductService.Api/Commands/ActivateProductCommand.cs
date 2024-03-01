using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Api.Commands
{
    public class ActivateProductCommand : IRequest<ActivateProductResult>
    {
        public Guid ProductId { get; set; }
    }
}
