using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModMan.Entities
{
    /// <summary>
    /// The interface for a collection of entities by interface.
    /// </summary>
    /// <typeparam name="IEntity">
    /// The type of the entity interface.
    /// </typeparam>
    public interface IEntityCollection<IEntity> : ICollection<IEntity>, INotifyCollectionChanged { }
}
