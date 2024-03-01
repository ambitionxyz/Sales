using MediatR;
using PolicyService.Api.Commands;
using PolicyService.Domain;

namespace PolicyService.Commmands
{
    public class CreateOfferByAgentHandler : IRequestHandler<CreateOfferByAgentCommand, CreateOfferResult>
    {
        private readonly IPricingService _pricingService;
        private readonly IUnitOfWork _uow;

        public CreateOfferByAgentHandler(IUnitOfWork uow, IPricingService pricingService)
        {
            _uow = uow;
            _pricingService = pricingService;
        }

        public async Task<CreateOfferResult> Handle(CreateOfferByAgentCommand request, CancellationToken cancellationToken)
        {
            //calculate price
            var priceParams = ConstructPriceParams(request);
            var price = await _pricingService.CalculatePrice(priceParams);
            var o = Offer.ForPriceAndAgent(
                      priceParams.ProductCode,
                      priceParams.PolicyFrom,
                      priceParams.PolicyTo,
                      null,
                      price,
                      request.AgentLogin
                  );

            //create and save offer
            _uow.Offers.Add(o);
            await _uow.CommitChanges();

            //return result
            return ConstructResult(o);
        }

        private CreateOfferResult ConstructResult(Offer o)
        {
            return new CreateOfferResult
            {
                OfferNumber = o.Number,
                TotalPrice = o.TotalPrice,
                CoversPrices = o.Covers.ToDictionary(c => c.Code, c=> c.Price)
            };
        }

        private PricingParams ConstructPriceParams(CreateOfferCommand request)
        {
            return new PricingParams
            {
                ProductCode = request.ProductCode,
                PolicyFrom = request.PolicyFrom,
                PolicyTo = request.PolicyTo,
                SelectedCovers = request.SelectedCovers,
                Answers = request.Answers.Select(a => Answer.Create(a.QuestionType, a.QuestionCode, a.GetAnswer())).ToList(),
            };
        }


    }
}
