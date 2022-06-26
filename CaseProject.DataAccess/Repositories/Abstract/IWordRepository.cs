using CaseProject.Core.DataAccess.Abstract;
using CaseProject.Core.Entities;

namespace CaseProject.DataAccess.Repositories.Abstract
{
    public interface IWordRepository : IEntityRepository<Word>
    {
        //Özel method yazılmak istenirse buraya eklenebilir.
    }
}
