using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Iconiz.Boilerplate.MultiTenancy.Accounting.Dto;

namespace Iconiz.Boilerplate.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
