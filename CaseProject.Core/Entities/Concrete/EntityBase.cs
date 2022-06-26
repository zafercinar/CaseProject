using CaseProject.Core.Entities.Abstract;

namespace CaseProject.Core.Entities.Concrete
{
    public abstract class EntityBase : IEntity
    {
        public Guid Value { get; set; }

        //İhtiyaç halinde Audit özellikler buraya eklenecektir.
    }
}
