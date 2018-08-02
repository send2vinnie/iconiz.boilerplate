using Abp.AutoMapper;
using Iconiz.Boilerplate.Editions;
using Iconiz.Boilerplate.MultiTenancy.Payments.Dto;

namespace Iconiz.Boilerplate.Web.Areas.AppAreaName.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}