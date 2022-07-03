using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace ModMan.Core.Entities
{
    /// <summary>
    /// The base class for all entities in the application.
    /// </summary>
    public class Entity : ObservableObject
    {
        #region Private Fields

        private object source;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the source object in the backing store.
        /// </summary>
        /// <value>
        /// The source object in the backing store.
        /// </value>
        public object Source
        {
            get { return source; }
            set { SetProperty(ref source, value); }
        }

        #endregion Public Properties
    }
}