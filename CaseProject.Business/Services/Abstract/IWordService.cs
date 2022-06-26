using CaseProject.Core.Common.Concrete;
using CaseProject.Core.Entities;
using CaseProject.Core.ViewModels;
using System.Linq.Expressions;

namespace CaseProject.Business.Services.Abstract
{
    public interface IWordService
    {
        Task<Result<bool>> AddRandomTextAsync(string randomText);
        Task<Result<List<WordModel>>> GetRandomTextListAsync(Expression<Func<Word, bool>>? match = null);
        Task<Result<List<WordModel>>> GetRandomTextListWithPaginationAsync(Expression<Func<Word, bool>>? filter = null, string? orderBy = null, int page = 1, int limit = 10);
    }
}
