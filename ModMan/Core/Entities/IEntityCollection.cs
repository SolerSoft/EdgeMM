using System.Collections.Specialized;

namespace ModMan.Core.Entities
{
    /// <summary>
    /// The interface for a collection of entities by interface.
    /// </summary>
    /// <typeparam name="TInterface">
    /// The type of the entity interface.
    /// </typeparam>
    public interface IEntityCollection<TInterface> : ICollection<TInterface>, INotifyCollectionChanged where TInterface : IEntity
    { }
}