using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewApp.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace NewApp.Generals
{
    public class GeneralSettingConfiguration : IEntityTypeConfiguration<GeneralSetting>
    {
      

       

        public void Configure(EntityTypeBuilder<GeneralSetting> builder)
        {


            builder.ToTable("GeneralSetting");
            builder.ConfigureByConvention();
            builder.Property(x=>x.PageTitle).IsRequired();
            builder.Property(x=>x.HideFromMenue).IsRequired();
            builder.Property(x=>x.Slug).IsRequired();
            builder.Property(x=>x.PublishDate).IsRequired();
            builder.Property(x=>x.Content).IsRequired();

        }
    }
}
