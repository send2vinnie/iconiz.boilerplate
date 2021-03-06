﻿using Iconiz.Boilerplate.Editions;
using Iconiz.Boilerplate.Editions.Dto;
using Iconiz.Boilerplate.Security;
using Iconiz.Boilerplate.MultiTenancy.Payments;
using Iconiz.Boilerplate.MultiTenancy.Payments.Dto;

namespace Iconiz.Boilerplate.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType? Gateway { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public bool ShowPaymentExpireNotification()
        {
            return !string.IsNullOrEmpty(PaymentId);
        }
    }
}
