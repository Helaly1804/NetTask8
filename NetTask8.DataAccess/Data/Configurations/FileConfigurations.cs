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
    public class FileConfigurations : BaseConfigurations<FileField> , IEntityTypeConfiguration<FileField>
    {
        public new void Configure(EntityTypeBuilder<FileField> builder)
        {
            builder.HasOne(f => f.Employee)
                .WithMany(e => e.Files)
                .HasForeignKey(e => e.SubmittedById);
            base.Configure(builder);
        }
    }
}

