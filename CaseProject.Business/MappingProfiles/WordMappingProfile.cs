using AutoMapper;
using CaseProject.Core.Entities;
using CaseProject.Core.ViewModels;

namespace CaseProject.Business.MappingProfiles
{
    public class WordMappingProfile : Profile
    {
        public WordMappingProfile()
        {
            CreateMap<Word, WordModel>().ReverseMap();
        }
    }
}
