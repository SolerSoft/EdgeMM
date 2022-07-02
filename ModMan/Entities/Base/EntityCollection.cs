using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModMan.Entities
{
    /// <summary>
    /// An observable collection of entities that implement a known interface.
    /// </summary>
    /// <typeparam name="IEntity">
    /// The interface that the entities implement.
    /// </typeparam>
    /// <typeparam name="TEntity">
    /// The concrete implementation of the entity interface.
    /// </typeparam>
    public class EntityCollection<IEntity, TEntity> : ObservableCollection<TEntity>, IEntityCollection<IEntity> where TEntity : IEntity
    {
        #region ICollection of Interface Implementation

        bool ICollection<IEntity>.IsReadOnly => false;

        void ICollection<IEntity>.Add(IEntity item)
        {
            this.Add((TEntity)item);
        }

        bool ICollection<IEntity>.Contains(IEntity item)
        {
            return this.Contains(item);
        }

        void ICollection<IEntity>.CopyTo(IEntity[] array, int arrayIndex)
        {
            Array.Copy(this.Items.ToArray(), arrayIndex, array, 0, Count);
        }

        IEnumerator<IEntity> IEnumerable<IEntity>.GetEnumerator()
        {
            return this.Cast<IEntity>().GetEnumerator();
        }

        bool ICollection<IEntity>.Remove(IEntity item)
        {
            return this.Remove((TEntity)item);
        }
        
        #endregion // ICollection of Interface Implementation
    }
}
