using CaseProject.Core.DataAccess.Concrete.EntityFramework;
using CaseProject.Core.Entities;
using CaseProject.DataAccess.Contexts;
using CaseProject.DataAccess.Repositories.Abstract;

namespace CaseProject.DataAccess.Repositories.Concrete
{
    public class WordRepository : EfEntityRepositoryBase<Word, CaseProjectDbContext>, IWordRepository
    {
        public WordRepository(CaseProjectDbContext context) : base(context)
        {
        }

        //Yazılan ekstra özel methodlar burada override edilerek eklenebilir.
    }
}
