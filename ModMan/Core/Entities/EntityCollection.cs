using System.Collections.ObjectModel;

namespace ModMan.Core.Entities
{
    /// <summary>
    /// An observable collection of entities that implement a known interface.
    /// </summary>
    /// <typeparam name="TInterface">
    /// The interface that the entities implement.
    /// </typeparam>
    /// <typeparam name="TEntity">
    /// The concrete implementation of the entity interface.
    /// </typeparam>
    public class EntityCollection<TInterface, TEntity> : ObservableCollection<TEntity>, IEntityCollection<TInterface> where TInterface : IEntity where TEntity : TInterface
    {
        #region ICollection of Interface Implementation

        void ICollection<TInterface>.Add(TInterface item)
        {
            this.Add((TEntity)item);
        }

        bool ICollection<TInterface>.Contains(TInterface item)
        {
            return this.Contains(item);
        }

        void ICollection<TInterface>.CopyTo(TInterface[] array, int arrayIndex)
        {
            Array.Copy(this.Items.ToArray(), arrayIndex, array, 0, Count);
        }

        IEnumerator<TInterface> IEnumerable<TInterface>.GetEnumerator()
        {
            return this.Cast<TInterface>().GetEnumerator();
        }

        bool ICollection<TInterface>.Remove(TInterface item)
        {
            return this.Remove((TEntity)item);
        }

        bool ICollection<TInterface>.IsReadOnly => false;

        #endregion ICollection of Interface Implementation
    }
}