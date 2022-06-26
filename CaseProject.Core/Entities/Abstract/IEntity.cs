namespace CaseProject.Core.Entities.Abstract
{
    public interface IEntity
    {
        /// <summary>
        /// id ya da sıra şeklinde düşünülebilir.
        /// Denildiği için bu şekilde tutuldu.
        /// </summary>
        Guid Value { get; set; }
    }
}
