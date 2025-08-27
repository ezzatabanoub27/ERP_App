using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewApp.Generals
{
    public interface IGeneralSettingRepository
    {

        Task<List<GeneralSetting>> GetListAsync(  string? filterText=null , string? pageTitle =null
            ,string?slug =null , string? content=null , DateTime?publishDate=null,bool? hideFromMenue=null,
            string? sorting =null, int maxResultCount=int.MaxValue,int skipCount =0,CancellationToken cancellationToken =default);



        Task<long>GetCountAsync(string? filterText=null,string? pageTitle=null, 
            string? slug = null, string? content = null, DateTime? publishDate = null,
            bool? hideFromMenue = null,CancellationToken cancellationToken =default);


    }
}
