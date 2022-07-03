using System.Collections.ObjectModel;

namespace ModMan.Core.Entities
{
    /// <summary>
    /// An observable collection of entities.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The type of entity stored in the collection.
    /// </typeparam>
    public class EntityCollection<TEntity> : ObservableCollection<TEntity> where TEntity : Entity
    {
    }
}