using NewApp.LanguagesType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewApp.Languages
{
    public interface ILangaugeRepository 
    {

        Task<List<Language>> GetListAsync(string? filterText=null,string?title=null,FontType?font=null,CultureName?culture=null,bool? isDefault=null,
            string? sorting = null, int maxResultCount=int.MaxValue,int skipCount=0, CancellationToken cancellationToken =default);


        Task<long> GetCountAsync(string? filterText=null,string?title=null,FontType?font=null,CultureName?culture=null
            ,bool?isDefault=null, CancellationToken cancellationToken = default);

    }
}
