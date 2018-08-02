using Iconiz.Boilerplate.Editions;
using Iconiz.Boilerplate.MultiTenancy.Payments;

namespace Iconiz.Boilerplate.Web.Models.Payment
{
    public class CreatePaymentModel
    {
        public int EditionId { get; set; }

        public PaymentPeriodType? PaymentPeriodType { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}
