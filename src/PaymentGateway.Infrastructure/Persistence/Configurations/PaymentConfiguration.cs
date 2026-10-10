using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGateway.Domain.Payments;


namespace PaymentGateway.Infrastructure.Persistence.Configurations
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
         builder.ToTable("payments");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.MerchantId).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Amount).IsRequired().HasPrecision(18,4);
            builder.Property(p => p.Currency).IsRequired().IsFixedLength().HasMaxLength(3);
            builder.Property(p => p.Status).HasConversion<string>().HasMaxLength(20);
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.HasIndex(p=> p.MerchantId);
        }
    }
}
