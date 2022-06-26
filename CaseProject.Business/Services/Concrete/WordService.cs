using AutoMapper;
using CaseProject.Business.Services.Abstract;
using CaseProject.Core.Common.Concrete;
using CaseProject.Core.Entities;
using CaseProject.Core.ViewModels;
using CaseProject.DataAccess.Repositories.Abstract;
using System.Linq.Expressions;

namespace CaseProject.Business.Services.Concrete
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;
        private readonly IMapper _mapper;
        public WordService(IWordRepository wordRepository, IMapper mapper)
        {
            _wordRepository = wordRepository;
            _mapper = mapper;
        }

        public async Task<Result<bool>> AddRandomTextAsync(string randomText)
        {
            try
            {
                await _wordRepository.AddAsync(new Core.Entities.Word { Text = randomText });
                return new Result<bool> { IsSuccess = true, Data = true, Message = "Oluşturulan rastgele değer veritabanına başarılı bir şekilde kaydedilmiştir." };
            }
            catch (Exception exception)
            {
                return new Result<bool> { IsSuccess = false, Data = false, Message = $"Oluşturlan rastgele değer veritabanına eklenirken beklenmedik bir hata oluştu. Detay:{exception.Message}" };
            }
        }

        public async Task<Result<List<WordModel>>> GetRandomTextListAsync(Expression<Func<Word, bool>>? match = null)
        {
            try
            {
                var result = new Result<List<WordModel>>
                {
                    IsSuccess = true,
                    Data = _mapper.Map<List<WordModel>>(await _wordRepository.FindAllAsync()),
                    Message = "Oluşturulan rastgele değer veritabanından başarılı bir şekilde sorgulanmıştır.."
                };

                return result;
            }
            catch (Exception exception)
            {
                return new Result<List<WordModel>>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"Oluşturulan rastgele değer veritabanından listelenirken beklenmedik bir hata oluştu. Detay:{exception.Message}"
                };
            }
        }

        public async Task<Result<List<WordModel>>> GetRandomTextListWithPaginationAsync(Expression<Func<Word, bool>>? filter = null, string? orderBy = null, int page = 1, int limit = 10)
        {
            try
            {
                var result = new Result<List<WordModel>>
                {
                    IsSuccess = true,
                    Data = _mapper.Map<List<WordModel>>(await _wordRepository.GetWithPaginationAsync(filter, orderBy, page, limit)),
                    Message = "Oluşturulan rastgele değer veritabanından başarılı bir şekilde sorgulanmıştır.."
                };

                return result;
            }
            catch (Exception exception)
            {
                return new Result<List<WordModel>>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"Oluşturulan rastgele değer veritabanından listelenirken beklenmedik bir hata oluştu. Detay:{exception.Message}"
                };
            }
        }
    }
}
