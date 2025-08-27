using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp.Languages
{
    public class LanguagesConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {

            builder.ToTable("Languages");
            builder.Property(x=>x.Title).IsRequired();
            builder.Property(x=>x.Culture).IsRequired();
            builder.Property(x=>x.IsDefault).IsRequired();
            builder.Property(x=>x.Font).IsRequired();
        }
    }
}
