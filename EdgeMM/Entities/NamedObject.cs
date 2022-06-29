using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace EdgeMM.Entities
{
    /// <summary>
    /// Base class for an object that has a name.
    /// </summary>
    public abstract class NamedObject : ObservableObject
    {
        #region Private Fields

        private string name;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the object.
        /// </summary>
        /// <value>
        /// The name of the object.
        /// </value>
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        #endregion Public Properties
    }
}