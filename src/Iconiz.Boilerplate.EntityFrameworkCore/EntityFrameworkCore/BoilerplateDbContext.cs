using Abp.IdentityServer4;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Iconiz.Boilerplate.Authorization.Roles;
using Iconiz.Boilerplate.Authorization.Users;
using Iconiz.Boilerplate.Chat;
using Iconiz.Boilerplate.Editions;
using Iconiz.Boilerplate.Friendships;
using Iconiz.Boilerplate.MultiTenancy;
using Iconiz.Boilerplate.MultiTenancy.Accounting;
using Iconiz.Boilerplate.MultiTenancy.Payments;
using Iconiz.Boilerplate.Storage;

namespace Iconiz.Boilerplate.EntityFrameworkCore
{
    public class BoilerplateDbContext : AbpZeroDbContext<Tenant, Role, User, BoilerplateDbContext>, IAbpPersistedGrantDbContext
    {
        /* Define an IDbSet for each entity of the application */

        public virtual DbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual DbSet<Friendship> Friendships { get; set; }

        public virtual DbSet<ChatMessage> ChatMessages { get; set; }

        public virtual DbSet<SubscribableEdition> SubscribableEditions { get; set; }

        public virtual DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }
        
        public virtual DbSet<IconizTeamMember.IconizTeamMember> IconizTeamMembers { get; set; }
        
        public virtual DbSet<IconizFinance.IconizTopic> IconizTopic { get; set; }
        
        public virtual DbSet<IconizFinance.IconizTopicComment> IconizTopicComment { get; set; }

        public BoilerplateDbContext(DbContextOptions<BoilerplateDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BinaryObject>(b =>
            {
                b.HasIndex(e => new { e.TenantId });
            });

            modelBuilder.Entity<ChatMessage>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId, e.ReadState });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.UserId, e.ReadState });
            });

            modelBuilder.Entity<Friendship>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId });
                b.HasIndex(e => new { e.TenantId, e.FriendUserId });
                b.HasIndex(e => new { e.FriendTenantId, e.UserId });
                b.HasIndex(e => new { e.FriendTenantId, e.FriendUserId });
            });

            modelBuilder.Entity<Tenant>(b =>
            {
                b.HasIndex(e => new { e.SubscriptionEndDateUtc });
                b.HasIndex(e => new { e.CreationTime });
            });

            modelBuilder.Entity<SubscriptionPayment>(b =>
            {
                b.HasIndex(e => new { e.Status, e.CreationTime });
                b.HasIndex(e => new { e.PaymentId, e.Gateway });
            });
            
            modelBuilder.Entity<IconizFinance.IconizTopic>(b =>
            {
                b.HasIndex(e => new { e.SourceId });
                b.HasIndex(e => new { e.Source, e.SourceId });
            });

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}
