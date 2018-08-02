using Iconiz.Boilerplate.EntityFrameworkCore;

namespace Iconiz.Boilerplate.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly BoilerplateDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(BoilerplateDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();
            new TestSubscriptionPaymentBuilder(_context, _tenantId).Create();
            new TestEditionsBuilder(_context).Create();

            _context.SaveChanges();
        }
    }
}
