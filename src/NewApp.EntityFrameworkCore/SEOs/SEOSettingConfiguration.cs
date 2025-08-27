using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewApp.SEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp.SEOs
{
    public class SEOSettingConfiguration : IEntityTypeConfiguration<SEOSetting>
    {
        public void Configure(EntityTypeBuilder<SEOSetting> builder)
        {
            builder.ToTable("SEOSetting");
            builder.Property(x => x.MetaDescription).IsRequired();
            builder.Property(x=>x.MetaFollow).IsRequired();
            builder.Property(x => x.MetaIndex).IsRequired();
            builder.Property(x => x.MetaKeyWords).IsRequired();
            builder.Property(x => x.MetaPriority).IsRequired();
            builder.Property(x => x.MetaTitle).IsRequired();


        }
    }
}
