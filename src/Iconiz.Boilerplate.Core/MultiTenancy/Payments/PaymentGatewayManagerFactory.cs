using System;
using Abp.Dependency;
using Iconiz.Boilerplate.MultiTenancy.Payments.Paypal;

namespace Iconiz.Boilerplate.MultiTenancy.Payments
{
    public class PaymentGatewayManagerFactory : IPaymentGatewayManagerFactory, ITransientDependency
    {
        public IDisposableDependencyObjectWrapper<IPaymentGatewayManager> Create(SubscriptionPaymentGatewayType gateway)
        {
            switch (gateway)
            {
                case SubscriptionPaymentGatewayType.Paypal:
                    return IocManager.Instance.ResolveAsDisposable<PayPalGatewayManager>();
                default:
                    throw new Exception("Can not create IPaymentGatewayManager for given gateway: " + gateway);
            }
        }
    }
}