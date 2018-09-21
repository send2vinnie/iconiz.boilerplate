using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.Extensions;
using Iconiz.Boilerplate.Validation;

namespace Iconiz.Boilerplate.Authorization.Accounts.Dto
{
    public class RegisterInput : IValidatableObject
    {
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        public string EmailAddressValidateCode { get; set; }

        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        public string PhoneNumberValidateCode { get; set; }

        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EmailAddress.IsNullOrEmpty() && PhoneNumber.IsNullOrEmpty())
                yield return new ValidationResult("请填写邮箱或者手机号!");

            if ((EmailAddress.IsNullOrEmpty() || EmailAddressValidateCode.IsNullOrEmpty()) &&
                (PhoneNumber.IsNullOrEmpty() || PhoneNumberValidateCode.IsNullOrEmpty()))
                yield return new ValidationResult("请填写必要信息!");
        }
    }
}