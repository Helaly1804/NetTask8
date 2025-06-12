using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTask8.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask8.DataAccess.Data.Configurations
{
    public class ApprovalConfiguration : IEntityTypeConfiguration<Approval>
    {
        public void Configure(EntityTypeBuilder<Approval> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasOne(d => d.FileField)
                   .WithMany(f => f.Approvals)
                   .HasForeignKey(d => d.FileFieldId)
                   .OnDelete(DeleteBehavior.SetNull);
            builder.Property(d => d.CreatedAt).HasDefaultValueSql("getdate()");
        }
    }
}
