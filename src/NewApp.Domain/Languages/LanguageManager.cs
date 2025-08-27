using NewApp.LanguagesType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace NewApp.Languages
{
    public class LanguageManager:DomainService
    {
        private readonly IRepository<Language,Guid> _languageRepository;

        public LanguageManager(IRepository<Language,Guid> languageRepository)
        {
            _languageRepository = languageRepository;
        }


        public async Task<Language>CretaeAsync(string title , FontType font , CultureName culture ,bool isDefault)
        {

            if (isDefault)
            { 
            var existed = await _languageRepository.FirstOrDefaultAsync(x=>x.IsDefault);
                if (existed != null) 
                {

                    throw new BusinessException("Only One Language Can Be Default !");
                }
            
            }

            var newLanguage = new Language(GuidGenerator.Create(),title,font,culture,isDefault);
            return await _languageRepository.InsertAsync(newLanguage);
        }


        public async Task<Language>UpdateAsync(Language language)
        {
            return await _languageRepository.UpdateAsync(language);
        }

        public async Task<List<Language>>GetListAsync()
        {
            return await _languageRepository.GetListAsync();
        }


        public async Task DeleteAsync(Guid id)
        {
            var language = await _languageRepository.GetAsync(id);
            if (language == null)
            {
                throw new EntityNotFoundException(typeof(Language), id);
            }
            if (language.IsDefault)
            {
                throw new BusinessException("Default LAnguage can not be deleted !");
            }
            await _languageRepository.DeleteAsync(language);


        }

        public async Task <Language>GetAsync(Guid id)
        {
            var language = await _languageRepository.GetAsync(id);
            if(language == null)
            {
                throw new EntityNotFoundException(typeof(Language),id);
            }
            return language;

        }
    }
}
