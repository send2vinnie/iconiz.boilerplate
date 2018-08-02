using Iconiz.Boilerplate.Editions.Dto;

namespace Iconiz.Boilerplate.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }
    }
}
