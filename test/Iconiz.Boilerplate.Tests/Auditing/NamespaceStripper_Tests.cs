using Iconiz.Boilerplate.Auditing;
using Shouldly;
using Xunit;

namespace Iconiz.Boilerplate.Tests.Auditing
{
    public class NamespaceStripper_Tests: AppTestBase
    {
        private readonly INamespaceStripper _namespaceStripper;

        public NamespaceStripper_Tests()
        {
            _namespaceStripper = Resolve<INamespaceStripper>();
        }

        [Fact]
        public void Should_Stripe_Namespace()
        {
            var controllerName = _namespaceStripper.StripNameSpace("Iconiz.Boilerplate.Web.Controllers.HomeController");
            controllerName.ShouldBe("HomeController");
        }

        [Theory]
        [InlineData("Iconiz.Boilerplate.Auditing.GenericEntityService`1[[Iconiz.Boilerplate.Storage.BinaryObject, Iconiz.Boilerplate.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null]]", "GenericEntityService<BinaryObject>")]
        [InlineData("CompanyName.ProductName.Services.Base.EntityService`6[[CompanyName.ProductName.Entity.Book, CompanyName.ProductName.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],[CompanyName.ProductName.Services.Dto.Book.CreateInput, N...", "EntityService<Book, CreateInput>")]
        [InlineData("Iconiz.Boilerplate.Auditing.XEntityService`1[Iconiz.Boilerplate.Auditing.AService`5[[Iconiz.Boilerplate.Storage.BinaryObject, Iconiz.Boilerplate.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],[Iconiz.Boilerplate.Storage.TestObject, Iconiz.Boilerplate.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],]]", "XEntityService<AService<BinaryObject, TestObject>>")]
        public void Should_Stripe_Generic_Namespace(string serviceName, string result)
        {
            var genericServiceName = _namespaceStripper.StripNameSpace(serviceName);
            genericServiceName.ShouldBe(result);
        }
    }
}
