using MediatR;
using PolicyService.Api.Commands;
using PolicyService.Api.Commands.Dtos;
using PolicyService.Api.Events;
using PolicyService.Domain;
using PolicyService.Messaging;

namespace PolicyService.Commmands
{
    public class CreatePolicyHandler : IRequestHandler<CreatePolicyCommand, CreatePolicyResult>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IUnitOfWork _uow;

        public CreatePolicyHandler( IUnitOfWork uow, IEventPublisher eventPublisher)
        {
            _uow = uow;
            _eventPublisher = eventPublisher;   
        }

        private static PolicyCreated PolicyCreated(Policy policy)
        {
            var version = policy.Versions.First(v => v.VersionNumber == 1);

            return new PolicyCreated
            {
                PolicyNumber = policy.Number,
                PolicyFrom = version.CoverPeriod.ValidFrom,
                PolicyTo = version.CoverPeriod.ValidTo,
                ProductCode = policy.ProductCode,
                TotalPremium = version.TotalPremiumAmount,
                PolicyHolder = new PersonDto
                {
                    FirstName = version.PolicyHolder.FirstName,
                    LastName = version.PolicyHolder.LastName,
                    TaxId = version.PolicyHolder.Pesel
                },
                AgentLogin = policy.AgentLogin
            };
        }


        public async Task<CreatePolicyResult> Handle(CreatePolicyCommand request, CancellationToken cancellationToken)
        {
            var offer = await _uow.Offers.WithNumber(request.OfferNumber);
            var customer = new PolicyHolder
            (
                request.PolicyHolder.FirstName,
                request.PolicyHolder.LastName,
                request.PolicyHolder.TaxId,
                Address.Of
                (
                    request.PolicyHolderAddress.Country,
                    request.PolicyHolderAddress.ZipCode,
                    request.PolicyHolderAddress.City,
                    request.PolicyHolderAddress.Street
                )
            );
            var policy = offer.Buy(customer);

            _uow.Policies.Add(policy);

            await _eventPublisher.PublishMessage(PolicyCreated(policy));

            await _uow.CommitChanges();

            return new CreatePolicyResult
            {
                PolicyNumber = policy.Number
            };
        }
    }
}
