using System.Threading.Tasks;
using Abp.Application.Services;
using Iconiz.Boilerplate.MultiTenancy.Dto;
using Iconiz.Boilerplate.MultiTenancy.Payments.Dto;
using Abp.Application.Services.Dto;

namespace Iconiz.Boilerplate.MultiTenancy.Payments
{
    public interface IPaymentAppService : IApplicationService
    {
        Task<PaymentInfoDto> GetPaymentInfo(PaymentInfoInput input);

        Task<CreatePaymentResponse> CreatePayment(CreatePaymentDto input);

        Task<ExecutePaymentResponse> ExecutePayment(ExecutePaymentDto input);

        Task<PagedResultDto<SubscriptionPaymentListDto>> GetPaymentHistory(GetPaymentHistoryInput input);
    }
}
