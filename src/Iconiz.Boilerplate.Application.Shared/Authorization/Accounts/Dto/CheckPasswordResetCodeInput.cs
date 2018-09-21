using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;

namespace Iconiz.Boilerplate.Authorization.Accounts.Dto
{
    public class CheckPasswordResetCodeInput
    {
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        public string EmailAddressValidateCode { get; set; }

        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        public string PhoneNumberValidateCode { get; set; }
    }
    
    public class CheckPasswordResetCodeOutput
    {
        public long UserId { get; set; }

        public bool IsCodeValidate { get; set; }

        public string PasswordResetCode { get; set; }
    }
}