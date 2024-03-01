using MediatR;
using PolicyService.Api.Commands;
using PolicyService.Api.Commands.Dtos;
using PolicyService.Api.Events;
using PolicyService.Domain;
using PolicyService.Messaging;

namespace PolicyService.Commmands
{
    public class TerminatePolicyHandler : IRequestHandler<TerminatePolicyCommand, TerminatePolicyResult>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IUnitOfWork _uow;

        public TerminatePolicyHandler(IUnitOfWork uow, IEventPublisher eventPublisher)
        {
            _uow = uow;
            _eventPublisher = eventPublisher;
        }

        public async Task<TerminatePolicyResult> Handle(TerminatePolicyCommand request, CancellationToken cancellationToken)
        {
            var policy = await _uow.Policies.WithNumber(request.PolicyNumber);

            var terminationResult = policy.Terminate(request.TerminationDate);

            await _eventPublisher.PublishMessage(PolicyTerminated(terminationResult));

            await _uow.CommitChanges();

            return new TerminatePolicyResult
            {
                PolicyNumber = policy.Number,
                MoneyToReturn = terminationResult.AmountToReturn
            };
        }

        private PolicyTerminated PolicyTerminated(PolicyTerminationResult terminationResult)
        {
            return new PolicyTerminated
            {
                PolicyNumber = terminationResult.TerminalVersion.Policy.Number,
                PolicyFrom = terminationResult.TerminalVersion.CoverPeriod.ValidFrom,
                PolicyTo = terminationResult.TerminalVersion.CoverPeriod.ValidTo,
                ProductCode = terminationResult.TerminalVersion.Policy.ProductCode,
                TotalPremium = terminationResult.TerminalVersion.TotalPremiumAmount,
                AmountToReturn = terminationResult.AmountToReturn,
                PolicyHolder = new PersonDto
                {
                    FirstName = terminationResult.TerminalVersion.PolicyHolder.FirstName,
                    LastName = terminationResult.TerminalVersion.PolicyHolder.LastName,
                    TaxId = terminationResult.TerminalVersion.PolicyHolder.Pesel
                }
            };
        }
    }
}
